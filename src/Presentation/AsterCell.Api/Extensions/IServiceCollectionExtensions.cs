using AsterCell.Application;
using AsterCell.Application.Common.Contracts;
using AsterCell.Application.Common.Models;
using AsterCell.Application.Common.Services;
using AsterCell.Application.Contrracts.Repositories;
using AsterCell.Application.Pipelines;
using AsterCell.Persistence;
using AsterCell.Persistence.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AsterCell.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddAsterCellApplication(this IServiceCollection @this, IConfiguration configuration)
        {
            @this.AddAsterCellDbContext(configuration)
                .AddAsterCellServices()
                .AddAsterCellRepositories()
                .AddFluentValidation()
                .AddMediator()
                .AddMapper();

            var identityServerOptions = @this.AddIdentityServerOptions(configuration);

            @this
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = identityServerOptions.Authority;
                    options.Audience = identityServerOptions.Audience;
                });

            @this.AddHttpContextAccessor();

            return @this;
        }

        private static IServiceCollection AddAsterCellDbContext(this IServiceCollection @this, IConfiguration configuration)
        {
            @this.AddDbContext<AsterCellDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString(nameof(AsterCellDbContext));
                options.UseMySQL(connectionString);
            });

            return @this;
        }

        private static IServiceCollection AddAsterCellServices(this IServiceCollection @this)
        {
            return @this;
        }

        private static IServiceCollection AddAsterCellRepositories(this IServiceCollection @this)
        {
            @this.AddScoped<IExtensionRepository, ExtensionRepository>();

            return @this;
        }

        private static IServiceCollection AddFluentValidation(this IServiceCollection @this)
        {
            @this.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (string.IsNullOrEmpty(type.Namespace))
                        continue;

                    if (!type.Namespace.StartsWith("AsterCell"))
                        continue;

                    var interfaces = type.GetInterfaces().ToList();

                    if (!interfaces.Any())
                        continue;

                    var contractType = interfaces.FirstOrDefault(f => f.Name.Contains(nameof(IValidator)) && f.IsGenericType);

                    if (contractType == null)
                        continue;

                    @this.AddScoped(contractType, type);
                }
            }
            return @this;
        }

        private static IServiceCollection AddMediator(this IServiceCollection @this)
        {
            @this.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(AsterCellApplicationPackageLoader).Assembly));
            @this.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipeline<,>));
            @this.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationPipeline<,>));
            return @this;
        }

        private static IServiceCollection AddMapper(this IServiceCollection @this)
        {
            @this.AddAutoMapper(typeof(AsterCellApplicationPackageLoader).Assembly);
            return @this;
        }

        private static IdentityServerOptions AddIdentityServerOptions(this IServiceCollection @this, IConfiguration configuration)
        {
            IdentityServerOptions identityServerOptions = new IdentityServerOptions();
            configuration.GetSection(IdentityServerOptions.Key).Bind(identityServerOptions);

            if (!identityServerOptions.Validate())
                throw new Exception("IdentityServerOptions not configured");

            @this.AddScoped<IdentityServerOptions>();
            @this.AddScoped<IUserInfo, UserInfo>();

            @this.AddHttpClient<IUserInfo, UserInfo>(options =>
            {
                options.BaseAddress = new Uri(identityServerOptions.Authority);
            });

            return identityServerOptions;
        }
    }
}
