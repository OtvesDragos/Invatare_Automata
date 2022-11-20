namespace Self_Organizing_Map;

public class SOMaps
{
    private List<Point>? points;
    private Neurons neurons;
    private double finalIteration;
    private double learnRate;

    public SOMaps(List<Point>? points, Neurons neurons, double finalIteration)
    {
        this.points = points;
        this.neurons = neurons;
        this.finalIteration = finalIteration;
    }
    public void Train()
    {
        for (double iteration = 0; iteration < finalIteration; iteration++)
        {
            var currentRank = CalculateNeighborhoodRank(iteration);
            learnRate = CalculateLearningRate(iteration);

            foreach (var point in points)
            {
                int coordX, coordY;
                var winningNeuron = neurons.GetWinningNeuron(point, out coordX, out coordY);
                UpdatePositions(coordX, coordY, currentRank, point);
            }
        }
    }

    private void UpdatePositions(int coordX, int coordY, double currentRank, Point input)
    {
        var xStart = (int)(coordX - currentRank - 1);
        xStart = (xStart < 0) ? 0 : xStart;

        var xEnd = (int)(xStart + (currentRank * 2) + 1);
        if (xEnd > neurons.length) xEnd = neurons.length;

        var yStart = (int)(coordY- currentRank - 1);
        yStart = (yStart < 0) ? 0 : yStart;

        var yEnd = (int)(yStart + (currentRank * 2) + 1);
        if (yEnd > neurons.length) yEnd = neurons.length;

        for (int i = xStart; i < xEnd; i++)
        {
            for (int j = yStart; j < yEnd; j++)
            {
                var processingNeuron = neurons.GetNeuron(i, j);
                var distance = processingNeuron.GetEuclidianDistance(input);
                if (distance <= Math.Pow(currentRank, 2))
                {
                    processingNeuron.UpdateNeuronsWithKohonen(input, learnRate);
                }
            }
        }
    }

    private double CalculateNeighborhoodRank(double iteration)
    {
        return 6.1 * Math.Pow(Math.E, -iteration / finalIteration) + 1;
    }

    private double CalculateLearningRate(double iteration)
    {
        return 0.6 * Math.Pow(Math.E, -iteration / finalIteration);
    }
}