using System.Drawing;

namespace RABEB
{
    internal class ImageRenderer : WidgetRenderer<ImageData>
    {
        public ImageRenderer(ImageData imageData) 
            : base(imageData) 
        {
        }

        protected override void RenderIfVisible(IBuffer<char> buffer)
        {
            if (_widgetData.CharBuffer == null)
            {
                return;
            }

            Point topLeft = GetTopLeft(buffer.Size);

            ImageDrawer imageDrawer = new ImageDrawer(topLeft, _widgetData.CharBuffer);
            imageDrawer.Draw(buffer);
        }

        private Point GetOffset() 
        {
            return new Point(
                _widgetData.CharBuffer.Width / 2,
                _widgetData.CharBuffer.Height / 2
            );
        }

        private Point GetScaledPosition(Point bufferSize)
        {
            return _widgetData.Position.Multiply(bufferSize).Truncate();
        }

        private Point GetTopLeft(Point bufferSize) 
        {
            Point scaledPosition = GetScaledPosition(bufferSize);
            return scaledPosition.Subtract(GetOffset());
        }
    }
}
