using AsterCell.Common.Enums;

namespace AsterCell.Common.Enums
{
    public class SortDirectionEnum : BaseEnum<SortDirectionEnum, string>
    {
        public static readonly SortDirectionEnum Ascending = new SortDirectionEnum("ASC", "Ascending");
        public static readonly SortDirectionEnum Descending = new SortDirectionEnum("DESC", "Descending");

        protected SortDirectionEnum(string value, string name) : base(value, name)
        {
        }
    }
}
