using System.Drawing;

namespace RABEB
{
    internal static class PointExtensions
    {
        public static Point Add(this Point augend, Point addend)
        {
            return new Point(
                augend.X + addend.X,
                augend.Y + addend.Y
            );
        }
        
        public static PointF Add(this PointF augend, PointF addend)
        {
            return new PointF(
                augend.X + addend.X,
                augend.Y + addend.Y
            );
        }

        public static Point Divide(this Point dividend, Point divisor)
        {
            return new Point(
                dividend.X / divisor.X,
                dividend.Y / divisor.Y
            );
        }

        public static PointF Divide(this PointF dividend, PointF divisor)
        {
            return new PointF(
                dividend.X / divisor.X,
                dividend.Y / divisor.Y
            );
        }

        public static Point Multiply(this Point multiplier, Point multiplicand)
        {
            return new Point(
                multiplier.X * multiplicand.X,
                multiplier.Y * multiplicand.Y
            );
        }

        public static PointF Multiply(this PointF multiplier, PointF multiplicand)
        {
            return new PointF(
                multiplier.X * multiplicand.X,
                multiplier.Y * multiplicand.Y
            );
        }

        public static Point Subtract(this Point minuend, Point subtrahend)
        {
            return new Point(
                minuend.X - subtrahend.X,
                minuend.Y - subtrahend.Y
            );
        }

        public static PointF Subtract(this PointF minuend, PointF subtrahend)
        {
            return new PointF(
                minuend.X - subtrahend.X,
                minuend.Y - subtrahend.Y
            );
        }

        public static Point Truncate(this PointF point)
        {
            return Point.Truncate(point);
        }
    }
}
