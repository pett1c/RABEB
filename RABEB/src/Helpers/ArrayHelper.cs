namespace RABEB
{
    internal static class ArrayHelper
    {
        public static T[,] To2dArray<T>(T[] input, int height, int width) 
        {
            if (height * width != input.Length) 
            {
                return null;
            }

            T[,] output = new T[height, width];

            for (int i = 0; i < height; i++) 
            {
                for (int j = 0; j < width; j++) 
                {
                    output[i, j] = input[i * width + j];
                }
            }

            return output;
        }
    }
}
