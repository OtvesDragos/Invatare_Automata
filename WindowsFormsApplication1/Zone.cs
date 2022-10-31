using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Zone
    {
        public int mx;
        public int my;
        public int sigmaX;
        public int sigmaY;
        Color color;

        public Color Color
        {
            get { return color; }
            set { color = value; }
        } 

        public Zone(int mx, int my, int sigmaX, int sigmaY, Color color)
        {
            this.mx = mx;
            this.my = my;
            this.sigmaX = sigmaX;
            this.sigmaY = sigmaY;
            this.color = color;
        }

        public Rectangle GetZoneDrawing()
        {
            var p1 = CoordonatesConvert.GetPoint(mx,my);
            var size = new Size(2*sigmaX,2*sigmaY);
            return new Rectangle(p1, size);
        }
    }
}
