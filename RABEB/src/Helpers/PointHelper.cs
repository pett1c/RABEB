using System.Drawing;

namespace RABEB
{
    internal static class PointHelper
    {
        public static bool IsClamped(Point point, Point topLeft, Point bottomRight)
        {
            return (
                MathHelper.IsClamped(point.X, topLeft.X, bottomRight.X)
                && MathHelper.IsClamped(point.Y, topLeft.Y, bottomRight.Y)
            );
        }
    }
}
