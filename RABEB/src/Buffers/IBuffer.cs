using System.Drawing;

namespace RABEB
{
    internal interface IBuffer<T>
    {
        T this[int x, int y] { get; set; }

        int Height { get; }
        Point Size { get; }
        int Width { get; }

        T[,] ToArray();
    }
}
