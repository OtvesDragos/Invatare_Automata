namespace Self_Organizing_Map
{
    public static class CoordonatesConvert
    {
        public static Point GetPoint(int x, int y)
        {
            int xEcran, yEcran;

            if (y < 0)
            {
                yEcran = -y + Constants.MarimePictureBox / 2;
            } else
            {
                yEcran = Constants.MarimePictureBox / 2 - y;
            }

            if (x < 0)
            {
                xEcran = x + Constants.MarimePictureBox / 2;
            } else
            {
                xEcran = Constants.MarimePictureBox / 2 + x;
            }

            if (xEcran < 0 || xEcran > Constants.MarimePictureBox || yEcran < 0 ||
    yEcran > Constants.MarimePictureBox)
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
