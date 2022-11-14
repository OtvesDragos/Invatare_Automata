namespace Self_Organizing_Map
{
    public class Reader
    {
        private const string Path =
            @"C:\Facultate\Invatare_Automata\WindowsFormsApplication1\bin\Debug\output.txt";

        public List<Point> ReadPointsFromFile()
        {
            string[] lines = System.IO.File.ReadAllLines(Path);
            IList<Point> points = new List<Point> ();

            foreach (string line in lines)
            {
                string[] numbers = line.Split(' ');

                if (numbers.Length == 2)
                {
                    var x = int.Parse(numbers[0]);
                    var y = int.Parse(numbers[1]);
                    if (x < -300 || x > 300 || y < -300 || y > 300)
                    {
                        throw new InvalidOperationException();
                    }

                    points.Add(new
                        Point(x,y));
                }
            }

            return points.ToList();
        }
    }
}
