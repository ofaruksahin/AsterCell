using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace AsterCell.AuthorizationServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                   };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("scope1"),
                new ApiScope("scope2"),
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
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    },
                    AllowOfflineAccess = true,
                    AccessTokenLifetime = (int)TimeSpan.FromDays(1).TotalSeconds,
                    RefreshTokenUsage = TokenUsage.ReUse,
                    AbsoluteRefreshTokenLifetime = (int)TimeSpan.FromDays(60).TotalSeconds
                },
            };
    }
}