using AsterCell.Common.Enums;

namespace Asterisk.Domain.Enums
{
    public class EndpointInviteReInviteEnum : BaseEnum<EndpointInviteReInviteEnum, string>
    {
        public static readonly EndpointInviteReInviteEnum Invite = new EndpointInviteReInviteEnum("invite", "invite");
        public static readonly EndpointInviteReInviteEnum ReInvite = new EndpointInviteReInviteEnum("reinvite", "reinvite");
        public static readonly EndpointInviteReInviteEnum Update = new EndpointInviteReInviteEnum("update", "update");

        protected EndpointInviteReInviteEnum(string value, string name) : base(value, name)
        {
        }
    }
}
