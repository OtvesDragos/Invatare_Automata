using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1;

namespace K_Means
{
    public class Reader
    {
        private const string Path =
            @"C:\Facultate\Invatare_Automata\WindowsFormsApplication1\bin\Debug\output.txt";

        public List<ColoredPoint> ReadPointsFromFile()
        {
            string[] lines = System.IO.File.ReadAllLines(Path);
            IList<ColoredPoint> points = new List<ColoredPoint>();

            foreach (string line in lines)
            {
                string[] numbers = line.Split(' ');

                if (numbers.Length == 2)
                {
                    var coloredPoint = CoordonatesConvert
                        .GetPoint(int.Parse(numbers[0]), int.Parse(numbers[1]));
                    points.Add(new
                        ColoredPoint(coloredPoint));
                }
            }

            return points.ToList();
        }
    }
}
