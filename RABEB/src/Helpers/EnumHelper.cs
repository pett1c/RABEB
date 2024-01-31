using System;

namespace RABEB
{
    internal static class EnumHelper
    {
        public static TEnum EnumFromInt<TEnum>(int number) where TEnum : Enum
        {
            if (Enum.IsDefined(typeof(TEnum), number))
            {
                return (TEnum)Enum.ToObject(typeof(TEnum), number);
            }

            throw new ArgumentException($"The value {number} is not a valid enum value for {typeof(TEnum)}.");
        }
    }
}
