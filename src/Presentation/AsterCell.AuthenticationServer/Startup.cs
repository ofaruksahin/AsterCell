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

            identityServerBuilder.AddOperationalStore(options =>
            {
                options.ConfigureDbContext = builder =>
                    builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(typeof(AsterCellAuthenticationServerDbContext).Assembly.FullName));
            }).AddConfigurationStore(options =>
                options.ConfigureDbContext = builder =>
                    builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(typeof(AsterCellAuthenticationServerDbContext).Assembly.FullName)));

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

                var clients = new List<Client>();

                clients.Add(new Client
                {
                    ClientId = "oauthClient",
                    ClientName = "Example client application using client credentials",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> { new Secret("SuperSecretPsasword".Sha256()) },
                    AllowedScopes = new List<string> { "api1.read" }
                });

                clients.Add(new Client
                {
                    ClientId = "oidClient",
                    ClientName = "Example Client Application",
                    ClientSecrets = new List<Secret> { new Secret("SuperSecretPassword".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string> { "https://localhost:5002/signin-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "api1.read"
                    },
                    RequirePkce = true,
                    AllowPlainTextPkce = false
                });

                if (!context.Clients.Any())
                {
                    foreach (var client in clients)
                        context.Clients.Add(client.ToEntity());
                }

                var identityResources = new List<IdentityResource>();
                identityResources.Add(new IdentityResources.OpenId());
                identityResources.Add(new IdentityResources.Profile());
                identityResources.Add(new IdentityResources.Email());
                identityResources.Add(new IdentityResource("role", new List<string> { "role" }));

                if (!context.IdentityResources.Any())
                {
                    foreach (var identityResource in identityResources)
                        context.IdentityResources.Add(identityResource.ToEntity());
                }

                var apiScopes = new List<ApiScope>();

                apiScopes.Add(new ApiScope("api1.read", "Read Access to API 1"));
                apiScopes.Add(new ApiScope("api1.write", "Write Access to API 1"));

                if (!context.ApiScopes.Any())
                {
                    foreach (var apiScope in apiScopes)
                        context.ApiScopes.Add(apiScope.ToEntity());
                }

                if (!userManager.Users.Any())
                {
                    var user = new AsterCellUser
                    {
                        UserName = "ofaruksahin@outlook.com.tr",
                        Email = "ofaruksahin@outlook.com.tr"
                    };
                    userManager.CreateAsync(user, "Password123!").Wait();
                    userManager.AddClaimsAsync(user, new List<Claim>
                    {
                        new Claim(JwtClaimTypes.Email,user.Email),
                        new Claim(JwtClaimTypes.Role, "admin")
                    }).Wait();
                }

                context.SaveChanges();
            }
        }
    }
}
