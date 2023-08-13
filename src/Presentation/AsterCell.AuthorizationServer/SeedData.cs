using AsterCell.AuthorizationServer.Domain.Entities;
using AsterCell.AuthorizationServer.Infrastructure;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Linq;
using System.Security.Claims;

namespace AsterCell.AuthorizationServer
{
    public class SeedData
    {
        public static void EnsureSeedData(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var asterCellAuthorizationDbContext = scope.ServiceProvider.GetService<AsterCellAuthorizationDbContext>();
                var configurationDbContext = scope.ServiceProvider.GetService<ConfigurationDbContext>();
                var persistedGrantDbContext = scope.ServiceProvider.GetService<PersistedGrantDbContext>();
                asterCellAuthorizationDbContext.Database.Migrate();
                configurationDbContext.Database.Migrate();
                persistedGrantDbContext.Database.Migrate();

                var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<AsterCellUser>>();

                foreach (var item in TestUsers.Users)
                {
                    var user = userMgr.FindByNameAsync(item.Username).Result;
                    if (user != null)
                    {
                        Log.Debug("alice already exists");
                        continue;
                    }

                    user = new AsterCellUser
                    {
                        UserName = item.Username,
                        Email = item.Username,
                        EmailConfirmed = true,
                    };
                    var result = userMgr.CreateAsync(user, "Pass123$").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr.AddClaimsAsync(user, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Alice Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Alice"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                }

                foreach (var item in Config.IdentityResources)
                {
                    var hasExists = configurationDbContext.IdentityResources.Any(f => f.Name == item.Name);
                    if (hasExists)
                    {
                        Log.Debug($"{item.Name} Identity resource already exists");
                        continue;
                    }

                    configurationDbContext.IdentityResources.Add(item.ToEntity());
                }

                configurationDbContext.SaveChanges();

                foreach (var item in Config.ApiScopes)
                {
                    var hasExists = configurationDbContext.ApiScopes.Any(f => f.Name == item.Name);
                    if (hasExists)
                    {
                        Log.Debug($"{item.Name} Api scope already exists");
                        continue;
                    }

                    configurationDbContext.ApiScopes.Add(item.ToEntity());
                }

                configurationDbContext.SaveChanges();

                foreach (var item in Config.Clients)
                {
                    var hasExists = configurationDbContext.Clients.Any(f => f.ClientId == item.ClientId);
                    if (hasExists)
                    {
                        Log.Debug($"{item.ClientId} Client id already exists");
                        continue;
                    }

                    configurationDbContext.Clients.Add(item.ToEntity());
                }

                configurationDbContext.SaveChanges();
            }
        }
    }
}
