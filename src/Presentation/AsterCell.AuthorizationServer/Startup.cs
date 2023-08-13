using AsterCell.AuthorizationServer.Domain.Entities;
using AsterCell.AuthorizationServer.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AsterCell.AuthorizationServer
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            var connectionString = Configuration.GetConnectionString("AsterCellAuthorizationConnectionString");
            var migrationAssembly = typeof(AsterCellAuthorizationDbContext).Assembly.FullName;

            services.AddDbContext<AsterCellAuthorizationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<AsterCellUser, AsterCellRole>()
                .AddEntityFrameworkStores<AsterCellAuthorizationDbContext>()
                .AddDefaultTokenProviders();

            var identityServerBuilder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                options.EmitStaticAudienceClaim = true;
            }).AddAspNetIdentity<AsterCellUser>()
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext =
                    context =>
                        context.UseSqlServer(connectionString, sql =>
                            sql.MigrationsAssembly(migrationAssembly));
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext =
                    context =>
                        context.UseSqlServer(connectionString, sql =>
                            sql.MigrationsAssembly(migrationAssembly));
            });

            identityServerBuilder.AddDeveloperSigningCredential();

            services.AddAuthentication();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            SeedData.EnsureSeedData(app);
        }
    }
}