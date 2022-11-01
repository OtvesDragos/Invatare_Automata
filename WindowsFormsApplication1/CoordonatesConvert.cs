using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public static class CoordonatesConvert
    {
        public static Point GetPoint(int x, int y)
        {
            int xEcran, yEcran;

            if (y < 0)
            {
                yEcran = -y + Constants.MARIME_PICTURE_BOX / 2;
            } else
            {
                yEcran = Constants.MARIME_PICTURE_BOX / 2 - y;
            }

            if (x < 0)
            {
                xEcran = x + Constants.MARIME_PICTURE_BOX / 2;
            } else
            {
                xEcran = Constants.MARIME_PICTURE_BOX / 2 + x;
            }

            return new Point(xEcran, yEcran);
        }
    }
}
