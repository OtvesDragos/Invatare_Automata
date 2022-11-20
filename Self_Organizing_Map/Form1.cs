using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace Self_Organizing_Map
{
    public partial class Form1 : Form
    {
        private readonly Random random = new Random();
        private List<Point>? points;
        private Neurons neurons = new(10);
        private PictureBox? graph;
        private SOMaps algoritm;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graph = new PictureBox();
            graph.Size = new Size(Constants.MarimePictureBox+10, Constants.MarimePictureBox+10);
            graph.Location = new Point(0);

            points = new List<Point>();
            Reader reader = new Reader();
            points.AddRange(reader.ReadPointsFromFile());

            graph.Paint += pictureBox1_Paint!;

            this.Controls.Add(graph);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawAxes(e);
            DrawPoints(e);
            DrawNeurons(e);
        }

        private void DrawNeurons(PaintEventArgs e)
        {
            for (int i = 0; i < neurons.length; i++)
            {
                for (int j = 0; j < neurons.length; j++)
                {
                    foreach (var neuron in neurons.GetNeighbourhood(i,j))
                    {
                        e.Graphics.DrawLine(Pens.Crimson, CoordonatesConvert.GetPoint(neurons.GetPoint(i, j)),
                            CoordonatesConvert.GetPoint(neuron.Point));
                    }
                }
            }
        }

        private void DrawPoints(PaintEventArgs e)
        {
            if (points == null)
            {
                throw new ArgumentNullException(nameof(points));
            }

            foreach (var point in points)
            {
                var rect = new Rectangle(CoordonatesConvert.GetPoint(point), Constants.PointSize);
                e.Graphics.FillEllipse(new SolidBrush(Constants.DefaultPointColor), rect);
                e.Graphics.DrawEllipse(Pens.BlueViolet, rect);
            }
        }

        private void DrawAxes(PaintEventArgs e)
        {
            var pointX1 = new Point(0, Constants.MarimePictureBox / 2);
            var pointX2 = new Point(Constants.MarimePictureBox, Constants.MarimePictureBox / 2);
            var pointY1 = new Point(Constants.MarimePictureBox / 2, 0);
            var pointY2 = new Point(Constants.MarimePictureBox / 2, Constants.MarimePictureBox);

            Pen pen = new Pen(Color.Brown, 3);
            e.Graphics.DrawLine(pen, pointX1, pointX2);
            e.Graphics.DrawLine(pen, pointY1, pointY2);
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            algoritm = new SOMaps(points, neurons, 18);
            double learning = 10;
            double iteration = 0;
            labelCountEpochs.Text = "0";
            while (learning > 0)
            {
                learning = algoritm.Train(iteration);
                labelCountEpochs.Text = iteration.ToString();
                labelCountEpochs.Refresh();
                graph.Refresh();
                iteration++;
            }

            labelTime.Text += ": " + timer.Elapsed;
            timer.Stop();
        }
    }
}