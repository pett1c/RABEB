using System.Drawing;

namespace RABEB
{
    internal class BitmapConverter : IConverter<Bitmap, IBuffer<char>>
    {
        private IConverter<Color, char> _colorConverter;

        public BitmapConverter(IConverter<Color, char> colorConverter) 
        {
            _colorConverter = colorConverter;
        }

        public IBuffer<char> Convert(Bitmap image)
        {
            IBuffer<char> buffer = new Buffer<char>(image.Height, image.Width);

            for (int x = 0; x < buffer.Width; x++) 
            {
                for (int y = 0; y < buffer.Height; y++) 
                {
                    Color color = image.GetPixel(x, y);
                    buffer[x, y] = _colorConverter.Convert(color);
                }
            }

            return buffer;
        }
    }
}
