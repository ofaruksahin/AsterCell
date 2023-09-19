using System.Collections.Concurrent;
using System.Reflection;

namespace AsterCell.Common.Enums
{
    public class BaseEnum<TEnum, TValue>
        where TEnum : BaseEnum<TEnum, TValue>
    {
        private static readonly ConcurrentDictionary<TValue, TEnum> _items = new ConcurrentDictionary<TValue, TEnum>();

        public string Name { get; }
        public TValue Value { get; }

        protected BaseEnum(TValue value, string name)
        {
            Value = value;
            Name = name;
        }

        static BaseEnum()
        {
            var fields = typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var field in fields)
            {
                var item = (TEnum)field.GetValue(null);
                if (item is null)
                    throw new Exception($"Enum Value {field.Name} is null");
                Register(item);
            }
        }

        public static TEnum FromValue(TValue value)
        {
            return _items[value];
        }

        public static bool TryFromValue(TValue value, out TEnum result)
        {
            return _items.TryGetValue(value, out result);
        }

        public static IEnumerable<TEnum> GetAll()
        {
            return _items.Values;
        }

        protected static TEnum Register(TEnum item)
        {
            return _items.GetOrAdd(item.Value, item);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
