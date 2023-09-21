﻿using AsterCell.Application;
using AsterCell.Application.Contrracts.Repositories;
using AsterCell.Application.Contrracts.Services;
using AsterCell.Application.Pipelines;
using AsterCell.Application.Services;
using AsterCell.Persistence;
using AsterCell.Persistence.Repositories;
using FluentValidation;
using MediatR;
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
            @this.AddScoped<IExtensionService, ExtensionService>();

            return @this;
        }

        private static IServiceCollection AddAsterCellRepositories(this IServiceCollection @this)
        {
            @this.AddScoped<IExtensionRepository, ExtensionRepository>();

            return @this;
        }

        private static IServiceCollection AddFluentValidation(this IServiceCollection @this)
        {
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
    }
}