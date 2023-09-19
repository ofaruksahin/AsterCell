namespace AsterCell.Common.Enums
{
    public class RecordStatusEnum : BaseEnum<RecordStatusEnum, int>
    {
        public static readonly RecordStatusEnum Passive = new RecordStatusEnum(0, "Pasif");
        public static readonly RecordStatusEnum Active = new RecordStatusEnum(1, "Aktif");

        protected RecordStatusEnum(int value, string name)
            : base(value, name)
        {
        }
    }
}
