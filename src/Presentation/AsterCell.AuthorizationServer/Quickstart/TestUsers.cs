using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServerHost.Quickstart.UI
{
    public class TestUsers
    {
        public static List<TestUser> Users = new List<TestUser>
        {
            new TestUser{SubjectId = "818727", Username = "alice", Password = "alice",
                Claims =
                {
                    new Claim(JwtClaimTypes.NickName, "alice"),
                    new Claim(JwtClaimTypes.PreferredUserName, "alice"),
                    new Claim(JwtClaimTypes.Email, "alice"),
                    new Claim(JwtClaimTypes.EmailVerified, "alice"),
                    new Claim(JwtClaimTypes.PhoneNumber, "905300000000"),
                    new Claim(JwtClaimTypes.PhoneNumberVerified,"905300000000"),
                    new Claim("tenant_id","1001"),
                    new Claim("role","admin")
                },
            },
            new TestUser{SubjectId = "88421113", Username = "bob", Password = "bob",
                Claims =
                {
                    new Claim(JwtClaimTypes.NickName, "bob"),
                    new Claim(JwtClaimTypes.PreferredUserName, "bob"),
                    new Claim(JwtClaimTypes.Email, "bob"),
                    new Claim(JwtClaimTypes.EmailVerified, "bob"),
                    new Claim(JwtClaimTypes.PhoneNumber, "905300000000"),
                    new Claim(JwtClaimTypes.PhoneNumberVerified,"905300000000"),
                    new Claim("tenant_id","1001"),
                    new Claim("role","admin")
                }
            },
            new TestUser
            {
                SubjectId = "88421114",
                Username="ofaruksahin@outlook.com.tr",
                Password="123456789fF@",
                Claims =
                {
                    new Claim(JwtClaimTypes.NickName, "ofaruksahin@outlook.com.tr"),
                    new Claim(JwtClaimTypes.PreferredUserName, "ofaruksahin@outlook.com.tr"),
                    new Claim(JwtClaimTypes.Email, "ofaruksahin@outlook.com.tr"),
                    new Claim(JwtClaimTypes.EmailVerified, "ofaruksahin@outlook.com.tr"),
                    new Claim(JwtClaimTypes.PhoneNumber, "905300000000"),
                    new Claim(JwtClaimTypes.PhoneNumberVerified,"905300000000"),
                    new Claim("tenant_id","1001"),
                    new Claim("role","admin")
                }
            }
        };
    }
}