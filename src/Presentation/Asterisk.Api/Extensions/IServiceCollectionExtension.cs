using Asterisk.Application;
using Asterisk.Application.Contracts.Repositories;
using Asterisk.Persistence;
using Asterisk.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Asterisk.Api.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddAsteriskApplication(
            this IServiceCollection @this,
            IConfiguration configuration)
        {
            @this.AddAsteriskDbContext(configuration)
                .AddAsteriskRepository()
                .AddMediator();

            @this.AddHttpContextAccessor();

            return @this;
        }

        private static IServiceCollection AddAsteriskDbContext(
            this IServiceCollection @this, 
            IConfiguration configuration)
        {
            @this.AddDbContext<AsteriskDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString(nameof(AsteriskDbContext));
                options.UseMySQL(connectionString);
            });

            return @this;
        }

        private static IServiceCollection AddAsteriskRepository(
            this IServiceCollection @this)
        {
            @this.AddScoped<IEndpointRepository, EndpointRepository>();
            @this.AddScoped<IEndpointAorRepository, EndpointAorRepository>();
            @this.AddScoped<IEndpointAuthRepository, EndpointAuthRepository>();
            return @this;
        }

        private static IServiceCollection AddMediator(this IServiceCollection @this)
        {
            @this.AddMediatR(options => options.RegisterServicesFromAssemblies(typeof(AsteriskApplicationPackageLoader).Assembly));
            return @this;
        }
    }
}
