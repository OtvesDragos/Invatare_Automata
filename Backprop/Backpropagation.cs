using System.Reflection.Emit;

namespace Backprop
{
    internal class Backpropagation
    {
        private double[] X1 = { 0, 0, 1, 1 };
        private double[] X2 = { 0, 1, 0, 1 };
        private int nIn = 2;
        private int nHidd = 2;
        private int nOut = 1;
        private double[,] W12 = new double[2, 2];
        private double sumaW12;
        private double[,] W23 = new double[1, 2];
        private double sumaW23;
        private double[] Prag2 = new double[2];
        private double sumaPrag2;
        private double[] Prag3 = new double[1];
        private double sumaPrag3;
        private double[] Out1 = new double[2];
        private double[] Out2 = new double[2];
        private double[] Out3 = new double[1];
        private double[] Scop = { 0.1, 0.9, 0.9, 0.1 };
        private double scop;
        public double Eglobal;
        private double Elocal;

        public void BackPropagationOnline()
        {
            Eglobal = 0;
            var rand = new Random();
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

            for (int i = 0; i < 4; i++)
            {
                Out1[0] = X1[i];
                Out1[1] = X2[i];
                scop = Scop[i];

                Forward();
                Console.WriteLine($"Intrare: {Out1[0]} {Out1[1]}");
                Console.WriteLine($"Iesirea: {Out3[0]}");
                Console.WriteLine($"Eroare: {Elocal}");
                Console.WriteLine("_____________________________________");
                BackwardOnline();
            }

        }
        private void BackwardOnline()
        {
            for (int o = 0; o < nOut; o++)
            {
                Prag3[o] -= 2 * (Out3[o] - scop) * FDerivat(Out3[o]);
            }

            for (int h = 0; h < nHidd; h++)
            {
                double suma = 0.0;
                for (int o = 0; o < nOut; o++)
                {
                    suma += (Out3[o] - scop) * FDerivat(Out3[o]) * W23[o, h];
                }
                Prag2[h] -= 2 * suma * FDerivat(Out2[h]);
            }

            for (int h = 0; h < nHidd; h++)
            {
                for (int i = 0; i < nIn; i++)
                {
                    double suma = 0.0;
                    for (int o = 0; o < nOut; o++)
                    {
                        suma += (Out3[o] - scop) * FDerivat(Out3[o]) * W23[o, h];
                    }
                    W12[h, i] -= 2 * suma * FDerivat(Out2[h]) * Out1[i];
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

        public void BackPropagationOffline()
        {
            Eglobal = 0;
            var rand = new Random();
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

            for (int i = 0; i < 4; i++)
            {
                Out1[0] = X1[i];
                Out1[1] = X2[i];
                scop = Scop[i];

                Forward();
                Console.WriteLine($"Intrare: {Out1[0]} {Out1[1]}");
                Console.WriteLine($"Iesirea: {Out3[0]}");
                Console.WriteLine($"Eroare: {Elocal}");
                Console.WriteLine("_____________________________________");
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

        private void Forward()
        {
            for (int h = 0; h < nHidd; h++)
            {
                double suma = 0.0;
                for (int i = 0; i < nIn; i++)
                {
                    suma += W12[h, i] * Out1[i];
                }
                Out2[h] = FSigmoida(suma + Prag2[h]);
            }

            for (int o = 0; o < nOut; o++)
            {
                double suma = 0.0;
                for (int h = 0; h < nHidd; h++)
                {
                    suma += W23[o, h] * Out2[h];
                }
                Out3[o] = FSigmoida(suma + Prag3[o]);
            }

            Elocal = 0;
            for (int o = 0; o < nOut; o++)
            {
                Elocal += Math.Pow(Out3[o] - scop, 2);
            }
            Eglobal += Elocal;
        }
        private void BackwardOffline()
        {
            sumaPrag2 = 0;
            sumaPrag3 = 0;
            sumaW12 = 0;
            sumaW23 = 0;
            for (int o = 0; o < nOut; o++)
            {
                sumaPrag3 += 2 * (Out3[o] - scop) * FDerivat(Out3[o]);
            }

            for (int h = 0; h < nHidd; h++)
            {
                double suma = 0.0;
                for (int o = 0; o < nOut; o++)
                {
                    suma += (Out3[o] - scop) * FDerivat(Out3[o]) * W23[o, h];
                }
                sumaPrag2 += 2 * suma * FDerivat(Out2[h]);
            }

            for (int h = 0; h < nHidd; h++)
            {
                for (int i = 0; i < nIn; i++)
                {
                    double suma = 0.0;
                    for (int o = 0; o < nOut; o++)
                    {
                        suma += (Out3[o] - scop) * FDerivat(Out3[o]) * W23[o, h];
                    }
                    sumaW12 += 2 * suma * FDerivat(Out2[h]) * Out1[i];
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

        private static double FSigmoida(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x)); 
        }

        private static double FDerivat(double x)
        {
            return x * (1 - x);
        }
    }
}
