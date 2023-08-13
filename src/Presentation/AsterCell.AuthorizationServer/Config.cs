using AsterCell.AuthorizationServer.Domain.ValueObject;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace AsterCell.AuthorizationServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            IdentityResourceConstants.OpenId,
            IdentityResourceConstants.Profile,
            IdentityResourceConstants.TenantId,
            IdentityResourceConstants.Roles,
            IdentityResourceConstants.PhoneNumber
        };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RedirectUris =           { "http://localhost:5173/callback" },
                    PostLogoutRedirectUris = { "http://localhost:5173" },
                    AllowedCorsOrigins =     { "http://localhost:5173" },
                    AllowedScopes =
                    {
                        IdentityResourceConstants.OpenId.Name,
                        IdentityResourceConstants.Profile.Name,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityResourceConstants.TenantId.Name,
                        IdentityResourceConstants.Roles.Name,
                        IdentityResourceConstants.PhoneNumber.Name
                    },
                    AllowOfflineAccess = true,
                    AccessTokenLifetime = (int)TimeSpan.FromDays(1).TotalSeconds,
                    RefreshTokenUsage = TokenUsage.ReUse,
                    AbsoluteRefreshTokenLifetime = (int)TimeSpan.FromDays(60).TotalSeconds,
                },
            };
    }
}