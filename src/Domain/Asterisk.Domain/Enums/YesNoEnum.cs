using AsterCell.Common.Enums;

namespace Asterisk.Domain.Enums
{
    public class YesNoEnum : BaseEnum<YesNoEnum, string>
    {
        public static readonly YesNoEnum Yes = new YesNoEnum("yes", "Yes");
        public static readonly YesNoEnum No = new YesNoEnum("no", "No");

        protected YesNoEnum(string value, string name) : base(value, name)
        {
        }
    }
}
