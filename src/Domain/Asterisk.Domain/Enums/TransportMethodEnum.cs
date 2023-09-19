using AsterCell.Common.Enums;

namespace Asterisk.Domain.Enums
{
    public class TransportMethodEnum : BaseEnum<TransportMethodEnum, string>
    {
        public static readonly TransportMethodEnum Default = new TransportMethodEnum("default", "Default");
        public static readonly TransportMethodEnum Unspecified = new TransportMethodEnum("unspecified", "Unspecified");
        public static readonly TransportMethodEnum Tlsv1 = new TransportMethodEnum("tlsv1", "Tlsv1");
        public static readonly TransportMethodEnum Sslv2 = new TransportMethodEnum("sslv2", "Sslv2");
        public static readonly TransportMethodEnum Sslv3 = new TransportMethodEnum("sslv3", "Sslv3");
        public static readonly TransportMethodEnum Sslv23 = new TransportMethodEnum("sslv23", "Sslv23");

        protected TransportMethodEnum(string value, string name) : base(value, name)
        {
        }
    }
}
