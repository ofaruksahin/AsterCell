using AsterCell.Common.Models;

namespace AsterCell.Domain.Models
{
    public class Cdr : BaseEntity<int>
    {
        public string TenantId { get; set; }
        public int DestinationType { get; set; }
        public int DestinationId { get; set; }
        public string Number { get; set; }
        public int Direction { get; set; }
        public DateTime CallStartDate { get; set; }
        public DateTime CallEndDate { get; set; }
        public double TotalDuration { get; set; }
        public int ParentCdrId { get; set; }
    }
}
