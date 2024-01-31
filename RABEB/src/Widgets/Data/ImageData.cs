using System.Drawing;

namespace RABEB
{
    internal class ImageData : WidgetData
    {
        public IBuffer<char> CharBuffer { get; set; }
        public PointF Position { get; set; }

        public ImageData(IBuffer<char> charBuffer, PointF position)
        {
            CharBuffer = charBuffer;
            Position = position;
        }
    }
}
