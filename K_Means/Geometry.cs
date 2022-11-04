using WindowsFormsApplication1;

namespace K_Means;

public class Geometry
{
    static List<Cluster> clusters = new();

    public static void GroupPointsToCentroids(List<ColoredPoint> points, List<Centroid> centroids)
    {
        clusters.AddRange(Cluster.GetClusterListFromCentroids(centroids));

        foreach (var coloredPoint in points)
        {
            GroupPointToCentroid(coloredPoint,centroids);
        }

        foreach (var cluster in clusters)
        {
            cluster.GetCentruDeGreutate();
        }
    }
    private static void GroupPointToCentroid(ColoredPoint point, List<Centroid> centroids)
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

        Cluster.GetClusterFromCentroid(clusters, minCentroid).points.Add(point);
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