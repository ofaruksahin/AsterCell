using AsterCell.Common.Enums;

namespace Asterisk.Domain.Enums
{
    public class EndpointAuthTypeEnum : BaseEnum<EndpointAuthTypeEnum, string>
    {
        public static EndpointAuthTypeEnum MD5 = new EndpointAuthTypeEnum("md5", "MD5");
        public static EndpointAuthTypeEnum Userpass = new EndpointAuthTypeEnum("userpass", "Userpass");
        public static EndpointAuthTypeEnum GoogleOAuth = new EndpointAuthTypeEnum("google_oauth", "Google Oauth");
        protected EndpointAuthTypeEnum(string value, string name) : base(value, name)
        {
        }
    }
}
