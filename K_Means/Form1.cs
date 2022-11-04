using System;
using System.Drawing;
using WindowsFormsApplication1;

namespace K_Means
{
    public partial class Form1 : Form
    {
        private readonly Random random = new Random();
        private List<ColoredPoint> points;
        private List<Centroid> centroids;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PictureBox graph = new PictureBox();
            graph.Size = new Size(WindowsFormsApplication1.Constants.MARIME_PICTURE_BOX, WindowsFormsApplication1.Constants.MARIME_PICTURE_BOX);
            graph.Location = new Point(0);

            points = new List<ColoredPoint>();
            Reader reader = new Reader();
            points.AddRange(reader.ReadPointsFromFile());

            centroids = Centroid.GetRandomCentroidList(random);
            Geometry.GroupPointsToCentroids(points,centroids);

            graph.Paint += pictureBox1_Paint!;

            this.Controls.Add(graph);

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawAxes(e);
            DrawPoints(e);
            DrawCentroids(e);
        }

        private void DrawCentroids(PaintEventArgs e)
        {
            foreach (var cendroid in centroids)
            {
                var rect = new Rectangle(CoordonatesConvert.GetPoint(cendroid.Point), cendroid.Size);
                e.Graphics.FillEllipse(new SolidBrush(cendroid.Color), rect);
            }
        }

        private void DrawPoints(PaintEventArgs e)
        {
            foreach (var point in points)
            {
                var rect = new Rectangle(point.point, point.size);
                e.Graphics.FillEllipse(new SolidBrush(point.Color), rect);
            }
        }

        private void DrawAxes(PaintEventArgs e)
        {
            var pointX1 = new Point(0, WindowsFormsApplication1.Constants.MARIME_PICTURE_BOX / 2);
            var pointX2 = new Point(WindowsFormsApplication1.Constants.MARIME_PICTURE_BOX, WindowsFormsApplication1.Constants.MARIME_PICTURE_BOX / 2);
            var pointY1 = new Point(WindowsFormsApplication1.Constants.MARIME_PICTURE_BOX / 2, 0);
            var pointY2 = new Point(WindowsFormsApplication1.Constants.MARIME_PICTURE_BOX / 2, WindowsFormsApplication1.Constants.MARIME_PICTURE_BOX);

            e.Graphics.DrawLine(Pens.Red, pointX1, pointX2);
            e.Graphics.DrawLine(Pens.Red, pointY1, pointY2);
        }
    }
}