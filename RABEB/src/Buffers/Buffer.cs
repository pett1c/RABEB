using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace RABEB
{
    internal class Buffer<T> : IBuffer<T>
    {
        public T this[int x, int y] 
        {
            get => _array[y, x];
            set => _array[y, x] = value;
        }

        public int Height { get; private set; }
        public Point Size => new Point(Width, Height);
        public int Width { get; private set; }

        private T[,] _array;

        public Buffer(int height, int width) 
        {
            Height = height;
            Width = width;

            _array = new T[height, width];
        }

        public Buffer(int height, int width, T value)
            : this(height, width) 
        {
            Fill(value);
        }

        public Buffer(T[,] array) 
            : this(array.GetLength(1), array.GetLength(0))
        {
            _array = array;
        }

        public void Fill(T value) 
        {
            for (int y = 0; y < Height; y++) 
            {
                for (int x = 0; x < Width; x++) 
                {
                    _array[y, x] = value;
                }
            }
        }
        public T[,] ToArray() 
        {
            return _array;
        }
    }
}
