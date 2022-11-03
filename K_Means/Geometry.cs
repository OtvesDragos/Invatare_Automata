using WindowsFormsApplication1;

namespace K_Means;

public class Geometry
{
    public static void GroupPointsToCentroids(List<ColoredPoint> points, List<Centroid> centroids)
    {
        foreach (var coloredPoint in points)
        {
            GroupPointsToCentroid(coloredPoint,centroids);
        }
    }
    private static void GroupPointsToCentroid(ColoredPoint point, List<Centroid> centroids)
    {
        double min = double.MaxValue;
        Centroid minCentroid = new Centroid();
        foreach (var centroid in centroids)
        {
            var distance = GetPointCentroidEuclideanDistance(point, centroid);
            if (distance < min)
            {
                min = distance;
                minCentroid = centroid;
            }
        }

        point.Color = minCentroid.Color;
    }
    private static double GetPointCentroidEuclideanDistance(ColoredPoint point, Centroid centroid)
    {
        var pointToCheck = CoordonatesConvert.GetPoint(point.point.X, point.point.Y);
        var centroidToCheck = CoordonatesConvert.GetPoint(centroid.Point.X, centroid.Point.Y);

        return Math.Sqrt(Math.Pow(pointToCheck.X - centroidToCheck.X, 2) +
                  Math.Pow(pointToCheck.Y - centroidToCheck.Y, 2));
    }
}