using AsterCell.Common.Contracts;
using AsterCell.Common.Enums;
using System.Text.Json.Serialization;

namespace AsterCell.Common.Models
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreateUser { get; set; }
        public string ModifyUser { get; set; }
        public int Status { get; set; }

        [JsonIgnore]
        private List<IDomainEvent> _domainEvents;

        [JsonIgnore]
        public IEnumerable<IDomainEvent> DomainEvents
        {
            get
            {
                if (_domainEvents is null)
                    _domainEvents = new List<IDomainEvent>();
                return _domainEvents;
            }
        }

        public BaseEntity()
        {
            Status = RecordStatusEnum.Active.Value;

            _domainEvents = new List<IDomainEvent>();
        }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            if (_domainEvents is null)
                _domainEvents = new List<IDomainEvent>();

            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            if (_domainEvents is null)
                _domainEvents = new List<IDomainEvent>();

            _domainEvents.Clear();
        }
    }

    public abstract class BaseEntity<TId> : BaseEntity
    {
        public TId Id { get; set; }
    }
}
