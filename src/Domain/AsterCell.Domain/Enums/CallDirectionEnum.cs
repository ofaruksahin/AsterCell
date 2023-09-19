using AsterCell.Common.Enums;

namespace AsterCell.Domain.Enums
{
    public class CallDirectionEnum : BaseEnum<CallDirectionEnum, int>
    {
        public static readonly CallDirectionEnum Inbound = new CallDirectionEnum(1, "Gelen Arama");
        public static readonly CallDirectionEnum Outbound = new CallDirectionEnum(2, "Giden Arama");

        protected CallDirectionEnum(int value, string name) : base(value, name)
        {
        }
    }
}
