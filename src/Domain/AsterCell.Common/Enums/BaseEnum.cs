namespace AsterCell.Common.Enums
{
    public abstract class BaseEnum<TEnum, TValue>
        where TEnum : BaseEnum<TEnum, TValue>
    {
        public string Name { get; }
        public TValue Value { get; }

        protected BaseEnum(TValue value, string name)
        {
            Value = value;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
