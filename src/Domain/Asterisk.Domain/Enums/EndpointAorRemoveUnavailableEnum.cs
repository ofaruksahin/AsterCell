using AsterCell.Common.Enums;

namespace Asterisk.Domain.Enums
{
    public class EndpointAorRemoveUnavailableEnum : BaseEnum<EndpointAorRemoveUnavailableEnum, string>
    {
        public static readonly EndpointAorRemoveUnavailableEnum Zero = new EndpointAorRemoveUnavailableEnum("0", "0");
        public static readonly EndpointAorRemoveUnavailableEnum One = new EndpointAorRemoveUnavailableEnum("1", "1");
        public static readonly EndpointAorRemoveUnavailableEnum Off = new EndpointAorRemoveUnavailableEnum("off", "off");
        public static readonly EndpointAorRemoveUnavailableEnum On = new EndpointAorRemoveUnavailableEnum("on", "on");
        public static readonly EndpointAorRemoveUnavailableEnum False = new EndpointAorRemoveUnavailableEnum("false", "false");
        public static readonly EndpointAorRemoveUnavailableEnum True = new EndpointAorRemoveUnavailableEnum("true", "true");
        public static readonly EndpointAorRemoveUnavailableEnum No = new EndpointAorRemoveUnavailableEnum("no", "no");
        public static readonly EndpointAorRemoveUnavailableEnum Yes = new EndpointAorRemoveUnavailableEnum("yes", "yes");
        protected EndpointAorRemoveUnavailableEnum(string value, string name) : base(value, name)
        {
        }
    }
}
