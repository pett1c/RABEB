using System;

namespace RABEB
{
    internal static class MathHelper
    {
        public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
        {
            T result = value;

            if (value.CompareTo(max) > 0)
            {
                result = max;
            }
            else if (value.CompareTo(min) < 0)
            {
                result = min;
            }

            return result;
        }

        public static bool IsClamped<T>(T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0) 
            {
                return false;
            }

            return true;
        }
    }
}
