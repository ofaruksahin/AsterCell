using AsterCell.Common.Enums;

namespace Asterisk.Domain.Enums
{
    public class TransportProtocolEnum : BaseEnum<TransportProtocolEnum, string>
    {
        public static readonly TransportProtocolEnum Udp = new TransportProtocolEnum("udp", "UDP");
        public static readonly TransportProtocolEnum Tcp = new TransportProtocolEnum("tcp", "TCP");
        public static readonly TransportProtocolEnum Tls = new TransportProtocolEnum("tls", "TLS");
        public static readonly TransportProtocolEnum Ws = new TransportProtocolEnum("ws", "WS");
        public static readonly TransportProtocolEnum Wss = new TransportProtocolEnum("wss", "WSS");
        public static readonly TransportProtocolEnum Flow = new TransportProtocolEnum("flow", "Flow");

        protected TransportProtocolEnum(string value, string name) : base(value, name)
        {
        }
    }
}
