using System.Security.Cryptography.X509Certificates;

namespace Self_Organizing_Map;

public class Neuron
{
    public Point Point;
    public List<Neuron> Neighbourhood;

    public Neuron()
    {
    }
    public Neuron(int x, int y)
    {
        Point = new Point(x, y);
        Neighbourhood = new();
    }

    public double GetEuclidianDistance(Point point)
    {
        return Math.Sqrt(Math.Pow(point.X - this.Point.X, 2) + 
                         Math.Pow(point.Y - this.Point.Y, 2));
    }

    public void UpdateNeuronsWithKohonen(Point input, double learningRate)
    {
        Point.X = (int)(Point.X + learningRate * (input.X - Point.X));
        Point.Y = (int)(Point.Y + learningRate * (input.Y - Point.Y));

    }
}