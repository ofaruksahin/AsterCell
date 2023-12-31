﻿using Microsoft.AspNetCore.Identity;

namespace AsterCell.AuthorizationServer.Domain.Entities
{
    public class AsterCellUser : IdentityUser<int>
    {
        public string TenantId { get; set; }
        public bool IsMaster { get; set; }
    }
}
