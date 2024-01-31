using System.Drawing;

namespace RABEB
{
    internal class ImageDrawer : IDrawer
    {
        private IBuffer<char> _charImage;
        private Point _position;

        public ImageDrawer(Point position, IBuffer<char> charImage) 
        {
            _position = position;
            _charImage = charImage;
        }

        public void Draw(IBuffer<char> buffer)
        {
            for (int x = 0; x < _charImage.Width; x++) 
            {
                for(int y = 0; y < _charImage.Height; y++) 
                {
                    if (_charImage[x, y] == CharConstant.Transparent) 
                    {
                        continue;
                    }

                    bool isClamped = PointHelper.IsClamped(
                        _position,
                        new Point(0, 0),
                        new Point(buffer.Width, buffer.Height)
                    );

                    if (isClamped)
                    {
                        buffer[_position.X + x, _position.Y + y] = _charImage[x, y];
                    }
                }
            }
        }
    }
}
