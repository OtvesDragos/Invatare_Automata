using WindowsFormsApplication1;

namespace Converter
{
    public static class CoordonatesConvert
    {
        public static Point GetPoint(int x, int y)
        {
            int xEcran, yEcran;

            if (y < 0)
            {
                yEcran = -y + WindowsFormsApplication1.Constants.MARIME_PICTURE_BOX / 2;
            } else
            {
                yEcran = WindowsFormsApplication1.Constants.MARIME_PICTURE_BOX / 2 - y;
            }

            if (x < 0)
            {
                xEcran = x + WindowsFormsApplication1.Constants.MARIME_PICTURE_BOX / 2;
            } else
            {
                xEcran = WindowsFormsApplication1.Constants.MARIME_PICTURE_BOX / 2 + x;
            }

            if (xEcran < 0 || xEcran > WindowsFormsApplication1.Constants.MARIME_PICTURE_BOX || yEcran < 0 ||
    yEcran > WindowsFormsApplication1.Constants.MARIME_PICTURE_BOX)
            {
                throw new InvalidOperationException();
            }

            return new Point(xEcran, yEcran);
        }

        public static Point GetPoint(Point point)
        {
            int x = point.X, y = point.Y;

            return GetPoint(x, y);
        }
    }
}
