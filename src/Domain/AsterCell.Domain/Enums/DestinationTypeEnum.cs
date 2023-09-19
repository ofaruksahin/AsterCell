using AsterCell.Common.Enums;

namespace AsterCell.Domain.Enums
{
    public class DestinationTypeEnum : BaseEnum<DestinationTypeEnum, int>
    {
        public static readonly DestinationTypeEnum Extension = new DestinationTypeEnum(1, "Extension");

        protected DestinationTypeEnum(int value, string name) : base(value, name)
        {
        }
    }
}
