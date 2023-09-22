using IdentityModel.Client;

namespace AsterCell.Application.Common.Models
{
    public class User
    {
        public int Id { get; set; }
        public string TenantId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }

        public User()
        {
        }

        public User(UserInfoResponse userInfoResponse)
        {
            if (HasClaim(userInfoResponse, "sub", out string id))
                Id = int.Parse(id);
            if (HasClaim(userInfoResponse, "tenant_id", out string tenantId))
                TenantId = tenantId;
            if (HasClaim(userInfoResponse, "phone_number", out string phoneNumber))
                PhoneNumber = phoneNumber;
            if (HasClaim(userInfoResponse, "name", out string email))
                Email = email;
            if (HasClaim(userInfoResponse, "role", out string roles))
                Roles = roles.Split(',').ToList();
        }

        private bool HasClaim(UserInfoResponse userInfoResponse,string claimName, out string claimValue)
        {
            claimValue = string.Empty;

            if (userInfoResponse.Claims.Any(f => f.Type == claimName))
            {
                claimValue = string.Join(",",userInfoResponse
                    .Claims
                    .Where(f => f.Type == claimName)
                    .Select(f => f.Value));
                return true;
            }

            return false;
        }
    }
}
