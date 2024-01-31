namespace RABEB
{
    internal static class StringExtensions
    {
        public static string RemoveFromEnd(this string str, int count) 
        {
            return str.Remove(str.Length - count, count);
        }
    }
}
