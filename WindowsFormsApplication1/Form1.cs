using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Random random;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PictureBox graph = new PictureBox();
            graph.Size = new Size(500, 500);
            graph.Location = new Point(0);
            graph.Paint += new PaintEventHandler(this.pictureBox1_Paint);

            random = new Random();

            this.Controls.Add(graph);

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawAxes(e);
            foreach (Zone zona in Constants.GetZones())
            {
                DrawZone(zona, e);
            }

            Gauss gauss = new Gauss();
            for (int i = 0; i < Constants.NR_PUNCTE; i++)
            {
                var zona = Constants.GetZones()[
                    random.Next(Constants.GetZones().Count())];
                e.Graphics.FillEllipse(new SolidBrush(zona.Color), gauss.GetGaussValue(zona, random));
            }

        }

        private void DrawAxes(PaintEventArgs e)
        {
            var pointX1 = new Point(0, 300);
            var pointX2 = new Point(600, 300);
            var pointY1 = new Point(300, 0);
            var pointY2 = new Point(300, 600);

            e.Graphics.DrawLine(Pens.Red, pointX1, pointX2);
            e.Graphics.DrawLine(Pens.Red, pointY1, pointY2);
        }

        private void DrawZone(Zone zona, PaintEventArgs e)
        {
            Pen pen = new Pen(zona.Color);
            e.Graphics.DrawRectangle(pen, zona.GetZoneDrawing());
        }
    }
}
