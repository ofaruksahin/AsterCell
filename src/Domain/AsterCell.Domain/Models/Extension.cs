using AsterCell.Common.Models;

namespace AsterCell.Domain.Models
{
    public class Extension : BaseEntity<int>
    {
        public string TenantId { get; set; }
        public string Exten { get; set; }
        public string ExtenNormalized { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
