using System;
using System.Linq;

namespace RABEB
{
    internal static class ArrayExtensions
    {
        public static T[] Flatten<T>(this Array array)
        {
            return array.Cast<T>().ToArray();
        }

        public static bool IsNullOrEmpty(this Array array) 
        {
            return (array == null) || (array.Length == 0);
        }
    }
}
