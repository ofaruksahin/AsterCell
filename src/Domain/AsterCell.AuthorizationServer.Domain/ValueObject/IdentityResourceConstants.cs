using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace AsterCell.AuthorizationServer.Domain.ValueObject
{
    public class IdentityResourceConstants
    {
        public static IdentityResource OpenId = new IdentityResources.OpenId();
        public static IdentityResource Profile = new IdentityResources.Profile();
        public static IdentityResource TenantId = new IdentityResource(
            "tenantId",
            "Müşteriler için oluşturulmuş eşsiz nuamaradır",
            new List<string> { "tenantId" });
        public static IdentityResource Roles = new IdentityResource(
            "roles",
            "Kullanıcıya atanmış rolleri gösterir",
            new List<string> { "role" });
        public static IdentityResource PhoneNumber = new IdentityResource(
            "phoneNumber",
            "Kullanıcının telefon nuamarası",
            new List<string>
            {
                JwtClaimTypes.PhoneNumber,
                JwtClaimTypes.PhoneNumberVerified
            });
    }
}
