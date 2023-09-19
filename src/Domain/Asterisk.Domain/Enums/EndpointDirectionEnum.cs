using AsterCell.Common.Enums;

namespace Asterisk.Domain.Enums
{
    public class EndpointDirectionEnum : BaseEnum<EndpointDirectionEnum, string>
    {
        public static readonly EndpointDirectionEnum None = new EndpointDirectionEnum("none", "none");
        public static readonly EndpointDirectionEnum Outgoing = new EndpointDirectionEnum("outgoing", "outgoing");
        public static readonly EndpointDirectionEnum Incoming = new EndpointDirectionEnum("incoming", "incoming");

        protected EndpointDirectionEnum(string value, string name) : base(value, name)
        {
        }
    }
}
