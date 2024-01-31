using System.Collections.Generic;
using System.Linq;

namespace RABEB
{
    internal static class EnumerableExtensions
    {
        public static T ElementAtOrDefault<T>(this IEnumerable<T> data, int? index)
        {
            if (index == null) 
            {
                return default;
            }
            return Enumerable.ElementAtOrDefault(data, (int)index);
        }
    }
}
