namespace Self_Organizing_Map;

public class Neurons
{
    private Neuron[,] coordonates;
    public readonly int length;
    public Neurons(int length)
    {
        this.length = length;
        coordonates = new Neuron[length, length];
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                coordonates[i, j] = new Neuron(-300 + 60 * i, 300 - 60 * j );
            }
        }

        AddNeighbourhoods();
    }

    public List<Neuron> GetNeighbourhood(int x, int y)
    {
        return coordonates[x, y].Neighbourhood;
    }

    private void AddNeighbourhoods()
    {
        for (int i = 1; i < length - 1; i++)
        {
            for (int j = 1; j < length - 1; j++)
            {
                coordonates[i, j].Neighbourhood.Add(coordonates[i + 1, j]);
                coordonates[i, j].Neighbourhood.Add(coordonates[i, j + 1]);
                coordonates[i, j].Neighbourhood.Add(coordonates[i - 1, j]);
                coordonates[i, j].Neighbourhood.Add(coordonates[i, j - 1]);
            }
        }

        for (int i = 1; i < length - 1; i++)
        {
            coordonates[i, 0].Neighbourhood.Add(coordonates[i + 1, 0]);
            coordonates[i, 0].Neighbourhood.Add(coordonates[i, 1]);
            coordonates[i, 0].Neighbourhood.Add(coordonates[i - 1, 0]);
            coordonates[i, length - 1].Neighbourhood.Add(coordonates[i + 1, length - 1]);
            coordonates[i, length - 1].Neighbourhood.Add(coordonates[i, length - 2]);
            coordonates[i, length - 1].Neighbourhood.Add(coordonates[i - 1, length - 1]);
        }

        for (int i = 1; i < length - 1; i++)
        {
            coordonates[0, i].Neighbourhood.Add(coordonates[0, i + 1]);
            coordonates[0, i].Neighbourhood.Add(coordonates[1, i]);
            coordonates[0, i].Neighbourhood.Add(coordonates[0, i - 1]);
            coordonates[length - 1, i].Neighbourhood.Add(coordonates[length - 1, i + 1]);
            coordonates[length - 1, i].Neighbourhood.Add(coordonates[length - 2, i]);
            coordonates[length - 1, i].Neighbourhood.Add(coordonates[length - 1, i - 1]);
        }

        coordonates[0, 0].Neighbourhood.Add(coordonates[1, 0]);
        coordonates[0, 0].Neighbourhood.Add(coordonates[0, 1]);
        coordonates[0, length - 1].Neighbourhood.Add(coordonates[0, length - 2]);
        coordonates[0, length - 1].Neighbourhood.Add(coordonates[1, length - 1]);
        coordonates[length - 1, 0].Neighbourhood.Add(coordonates[length - 2, 0]);
        coordonates[length - 1, 0].Neighbourhood.Add(coordonates[length - 1, 1]);
        coordonates[length - 1, length - 1].Neighbourhood.Add(coordonates[length - 1, length - 2]);
        coordonates[length - 1, length - 1].Neighbourhood.Add(coordonates[length - 2, length - 1]);
    }

    public Point GetPoint(int x, int y)
    {
        return coordonates[x, y].Point;
    }
}

public class Neuron
{
    public Point Point;
    public List<Neuron> Neighbourhood;

    public Neuron(int x, int y)
    {
        Point = new Point(x, y);
        Neighbourhood = new();
    }
}