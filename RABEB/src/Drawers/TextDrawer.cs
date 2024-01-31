using System;
using System.Drawing;

namespace RABEB
{
    internal class TextDrawer : IDrawer
    {
        private Point _position;
        private string _text;

        public TextDrawer(Point position, string text)
        {
            _position = position;
            _text = text;
        }

        public void Draw(IBuffer<char> buffer)
        {
            if (string.IsNullOrEmpty(_text)
                || _position.X > buffer.Width - 1
                || MathHelper.IsClamped(_position.Y, 0, buffer.Height - 1) == false)
            {
                return;
            }

            int leftIndex = Math.Max(0, Math.Max(0, _position.X) - _position.X);
            int rightIndex = Math.Min(_position.X + _text.Length, buffer.Width) - _position.X;

            for (int i = leftIndex; i < rightIndex; i++) 
            {
                if (_text[i] == CharConstant.Transparent) 
                {
                    continue;
                }

                buffer[_position.X + i, _position.Y] = _text[i];
            }
        }
    }
}
