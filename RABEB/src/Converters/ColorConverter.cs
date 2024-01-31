using System;
using System.Drawing;

namespace RABEB
{
    internal class ColorConverter : IConverter<Color, char>
    {
        private string _charGradient => (
            " `.-':_,^=;><+!rc*/z?sLTv)J7(|Fi{C}fI31tlu[neoZ5Yxjya]2ESwqkP6h9d4VpOGbUAKXHm8RD#$Bg0MNWQ%&@"
        );

        public char Convert(Color color)
        {
            if (color.A == byte.MinValue)
            {
                return CharConstant.Transparent;
            }

            float brightness = (color.A / 255f) * (color.R + color.G + color.B) / 255f / 3f;
            int index = System.Convert.ToInt32(brightness * (_charGradient.Length - 1));
            
            return _charGradient[index];
        }
    }
}
