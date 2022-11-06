using WindowsFormsApplication1;

namespace K_Means;

public class Geometry
{
    public static List<Cluster> Clusters { get; } = new();

    public static List<Cluster> GroupPointsToCentroids(List<ColoredPoint> points, List<Centroid> centroids)
    {
        Clusters.AddRange(Cluster.GetClusterListFromCentroids(centroids));

        foreach (var coloredPoint in points)
        {
            GroupPointToCentroid(coloredPoint,centroids);
        }

        return Clusters;
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

        Cluster.GetClusterFromCentroid(Clusters, minCentroid).points.Add(point);
        point.Color = minCentroid.Color;
    }
    public static double GetPointCentroidEuclideanDistance(ColoredPoint point, Centroid centroid)
    {

        return Math.Sqrt(Math.Pow(point.point.X - centroid.Point.X, 2) +
                  Math.Pow(point.point.Y - centroid.Point.Y, 2));
    }
}