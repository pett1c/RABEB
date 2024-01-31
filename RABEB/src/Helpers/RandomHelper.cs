using System;
using System.Linq;

namespace RABEB
{
    internal static class RandomHelper
    {
        private static Random _random = new Random();

        public static int? GetRandomIndex(int[] weights) 
        {
            int totalWeight = weights.Sum();
            int randomNumber = _random.Next(0, totalWeight - 1);

            for (int i = 0; i < weights.Length; i++) 
            {
                if (randomNumber < weights[i]) 
                {
                    return i;
                }
                randomNumber -= weights[i];
            }

            return null;
        }
    }
}
