using Microsoft.AspNetCore.Identity;

namespace AsterCell.AuthorizationServer.Domain.Entities
{
    public class AsterCellRole : IdentityRole<int>
    {
        public string TenantId { get; set; }
    }
}
