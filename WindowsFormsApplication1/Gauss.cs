using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Gauss
    {
        double prag;
        StreamWriter writer = new StreamWriter("output.txt");

        public Rectangle GetGaussValue(Zone zona, Random random)
        {
            int x, y;
            var mx = zona.mx;
            var sigmaX = zona.sigmaX;
            var my = zona.my;
            var sigmaY = zona.sigmaY;
            double resultX,resultY;
            double numarator;
            double numitor;
            
            do
            {
                x = random.Next(600) - 300;
                resultX = CalculateGauss(x, mx, sigmaX, out numarator, out numitor);

                prag = (double)random.Next(100000) / 100000;
            } while (resultX < prag);

            do
            {
                y = random.Next(600) - 300;
                resultY = CalculateGauss(y, my, sigmaY, out numarator, out numitor);

                prag = (double)random.Next(100000) / 100000;
            } while (resultY < prag);

            var point = CoordonatesConvert.GetPoint(x,y);
            writer.WriteLine(x + " " + y);
           
            var size = new Size(2, 2);
            var rectangle = new Rectangle(point,size);
            return rectangle;
        }

        private static double CalculateGauss(double x, double mx, double sigma, out double numarator, out double numitor)
        {
            numarator = Math.Pow(mx - x, 2);
            numitor = 2 * Math.Pow(sigma, 2);
            return Math.Pow(Math.E, -(numarator / numitor));
        }
    }
}
