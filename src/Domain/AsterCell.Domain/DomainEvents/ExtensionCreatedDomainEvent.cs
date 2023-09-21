using AsterCell.Common.Contracts;
using AsterCell.Domain.Models;

namespace AsterCell.Domain.DomainEvents
{
    public class ExtensionCreatedDomainEvent : IDomainEvent
    {
        public Extension Extension { get; set; }

        public ExtensionCreatedDomainEvent()
        {
        }

        public ExtensionCreatedDomainEvent(Extension extension)
        {
            Extension = extension;
        }
    }
}
