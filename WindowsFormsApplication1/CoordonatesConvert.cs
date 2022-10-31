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
            return new Point(x + 250, y + 250);
        }
    }
}
