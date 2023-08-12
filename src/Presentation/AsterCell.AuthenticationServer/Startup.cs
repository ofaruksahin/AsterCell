using AsterCell.AuthenticationServer.Domain.Entities;
using AsterCell.AuthenticationServer.Infrastructure;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Client = IdentityServer4.Models.Client;

namespace AsterCell.AuthenticationServer
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }

        public Startup(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            const string connectionString = @"Server=.;Database=AsterCellAuthentication;User Id=sa;Password=123456789F@;";

            services.AddDbContext<AsterCellAuthenticationServerDbContext>();

            services.AddIdentity<AsterCellUser, AsterCellRole>()
                .AddEntityFrameworkStores<AsterCellAuthenticationServerDbContext>();

            var identityServerBuilder = services.AddIdentityServer(options =>
            {
                options.EmitStaticAudienceClaim = true;
            });

            string migrationAssembly = typeof(AsterCellAuthenticationServerDbContext).Assembly.FullName;

            identityServerBuilder.AddOperationalStore(options =>
            {
                options.ConfigureDbContext = builder =>
                    builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(migrationAssembly));
            }).AddConfigurationStore(options =>
                options.ConfigureDbContext = builder =>
                    builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(migrationAssembly)));

            identityServerBuilder.AddAspNetIdentity<AsterCellUser>();

            identityServerBuilder.AddDeveloperSigningCredential();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            InitializeSeedData(app);

            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        private void InitializeSeedData(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
                scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>().Database.Migrate();
                scope.ServiceProvider.GetRequiredService<AsterCellAuthenticationServerDbContext>().Database.Migrate();

                var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AsterCellUser>>();

                if (!context.Clients.Any())
                {
                    foreach (var client in Config.GetClients())
                        context.Clients.Add(client.ToEntity());
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var identityResource in Config.GetIdentityResources())
                        context.IdentityResources.Add(identityResource.ToEntity());
                }

                if (!context.ApiScopes.Any())
                {
                    foreach (var apiScope in Config.GetApiScopes())
                        context.ApiScopes.Add(apiScope.ToEntity());
                }

                if (!userManager.Users.Any())
                {
                    foreach (var item in Config.GetUsers())
                    {
                        var user = new AsterCellUser
                        {
                            UserName = item.Username,
                            Email = item.Username
                        };
                        var userCreateUser = userManager.CreateAsync(user, item.Password).ConfigureAwait(false).GetAwaiter().GetResult();

                        if (userCreateUser.Succeeded)
                        {
                            userManager.AddClaimsAsync(user, new List<Claim>
                            {
                                new Claim(JwtClaimTypes.Email,user.Email),
                                new Claim(JwtClaimTypes.Role, "admin")
                            }).Wait();
                        }
                    }                        
                }

                context.SaveChanges();
            }
        }
    }
}
