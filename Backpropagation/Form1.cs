using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IA_laborator4
{
    public partial class Form1 : Form
    {
        public double[] X1 = { 0, 0, 1, 1 };
        public double[] X2 = { 0, 1, 0, 1 };
        public int nIn = 2;
        public int nHidd = 2;
        public int nOut = 1;
        public double[,] W12 = new double[2, 2];
        public double sumaW12;
        public double[,] W23 = new double[1, 2];
        public double sumaW23;
        public double[] Prag2 = new double[2];
        public double sumaPrag2;
        public double[] Prag3 = new double[1];
        public double sumaPrag3;
        public double[] Out1 = new double[2];
        public double[] Out2 = new double[2];
        public double[] Out3 = new double[1];
        public Random rand = new Random();
        public double[] Scop = { 0.1, 0.9, 0.9, 0.1 };
        public double scop;
        public double Eglobal;
        public double Elocal;

        public Form1()
        {
            InitializeComponent();
            timer.Start();
            for (int i = 0; i < nIn; i++)
            {
                for (int j = 0; j < nHidd; j++)
                {
                    W12[i, j] = rand.NextDouble();
                }
                Prag2[i] = rand.NextDouble();
            }
            for (int i = 0; i < nOut; i++)
            {
                for (int j = 0; j < nHidd; j++)
                {
                    W23[i, j] = rand.NextDouble();
                }
                Prag3[i] = rand.NextDouble();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void BackPropagationOnline()
        {
        
            for (int i = 0; i < 4; i++)
            {
                 Out1[0] = X1[i];
                 Out1[1] = X2[i];
                 scop = Scop[i];

                 Forward();
                 label1.Text = "INTRARE: " + Out1[0].ToString() + "   " + Out1[1].ToString();
                 label2.Text = "IESIRE:  " + Out3[0].ToString();
                 label3.Text = "EROARE:  " + Elocal.ToString();
                 BackwardOnline();
            }
      
        }
        public void BackPropagationOffline()
        { 
                for (int i = 0; i < 4; i++)
                {
                    Out1[0] = X1[i];
                    Out1[1] = X2[i];
                    scop = Scop[i];

                    Forward();
                    label1.Text = "INTRARE: " + Out1[0].ToString() + "   " + Out1[1].ToString();
                    label2.Text = "IESIRE:  " + Out3[0].ToString();
                    label3.Text = "EROARE:  " + Elocal.ToString();
                    BackwardOffline();
                }
                for (int o = 0; o < nOut; o++)
                {
                    Prag3[o] -= sumaPrag3;
                }
                for (int h = 0; h < nHidd; h++)
                {
                    Prag2[h] -= sumaPrag2;
                }
                for (int h = 0; h < nHidd; h++)
                {
                    for (int i = 0; i < nIn; i++)
                    {
                        W12[h, i] -= sumaW12;
                    }
                }

                for (int o = 0; o < nOut; o++)
                {
                    for (int h = 0; h < nHidd; h++)
                    {
                        W23[o, h] -= sumaW23;
                    }
                }
        }

        private void BackPropagationButton_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                BackPropagationOffline();
            }
            else if (checkBox2.Checked == true)
            {
                BackPropagationOnline();
            }
            else MessageBox.Show("Select online or offline!!!");
        }
        public double F(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        public double FDerivat(double x)
        {
            double a = x;
            return a * (1 - a);
        }

        public void Forward()
        {
            for (int h = 0; h < nHidd; h++)
            {
                double x = 0.0;
                for (int i = 0; i < nIn; i++) 
                {
                    x += W12[h, i] * Out1[i];
                }
                Out2[h] = F(x + Prag2[h]);
            }

            for (int o = 0; o < nOut; o++) 
            {
                double x = 0.0;
                for (int h = 0; h < nHidd; h++)
                {
                    x += W23[o, h] * Out2[h];
                }
                Out3[o] = F(x + Prag3[o]);
            }

            Elocal = 0;
            for (int o = 0; o < nOut; o++) 
            {
                Elocal += Math.Pow(Out3[o] - scop, 2);
            }
            Eglobal += Elocal;
        }
        public void BackwardOnline()
        {
            for (int o = 0; o < nOut; o++)
            {
                Prag3[o] -= 2 * (Out3[o] - scop) * FDerivat(Out3[o]);
            }

            for (int h = 0; h < nHidd; h++)
            {
                double x = 0.0;
                for (int o = 0; o < nOut; o++)
                {
                    x += (Out3[o] - scop) * FDerivat(Out3[o]) * W23[o, h];
                }
                Prag2[h] -= 2 * x * FDerivat(Out2[h]);
            }

            for (int h = 0; h < nHidd; h++)
            {
                for (int i = 0; i < nIn; i++)
                {
                    double x = 0.0;
                    for (int o = 0; o < nOut; o++)
                    {
                        x += (Out3[o] - scop) * FDerivat(Out3[o]) * W23[o, h];
                    }
                    W12[h, i] -= 2 * x * FDerivat(Out2[h]) * Out1[i]; 
                }
            }

            for (int o = 0; o < nOut; o++)
            {
                for (int h = 0; h < nHidd; h++)
                {
                    W23[o, h] -= 2 * ((Out3[o] - scop) * FDerivat(Out3[o])) * Out2[h];
                }
            }
        }
        public void BackwardOffline()
        {
            for (int o = 0; o < nOut; o++)
            {
                sumaPrag3 += 2 * (Out3[o] - scop) * FDerivat(Out3[o]);
            }

            for (int h = 0; h < nHidd; h++)
            {
                double x = 0.0;
                for (int o = 0; o < nOut; o++)
                {
                    x += (Out3[o] - scop) * FDerivat(Out3[o]) * W23[o, h];
                }
               sumaPrag2 += 2 * x * FDerivat(Out2[h]);
            }

            for (int h = 0; h < nHidd; h++)
            {
                for (int i = 0; i < nIn; i++)
                {
                    double x = 0.0;
                    for (int o = 0; o < nOut; o++)
                    {
                        x += (Out3[o] - scop) * FDerivat(Out3[o]) * W23[o, h];
                    }
                    sumaW12 += 2 * x * FDerivat(Out2[h]) * Out1[i];
                }
            }

            for (int o = 0; o < nOut; o++)
            {
                for (int h = 0; h < nHidd; h++)
                {
                   sumaW23 += 2 * ((Out3[o] - scop) * FDerivat(Out3[o])) * Out2[h];
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            label1.Text = "INTRARE: " + Out1[0].ToString() + "   " + Out1[1].ToString();
            label2.Text = "IESIRE:  " + Out3[0].ToString();
            label3.Text = "EROARE:  " + Elocal.ToString();
            if (Eglobal <= Math.Pow(10, -28))
                timer.Stop();
        }
    }
}
