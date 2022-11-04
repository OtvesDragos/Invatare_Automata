namespace K_Means;

public class Cluster
{
    public List<ColoredPoint> points;
    public Centroid centroid;

    public Cluster(Centroid centroid)
    {
        this.centroid = centroid;
        points = new();
    }

    public static List<Cluster> GetClusterListFromCentroids(List<Centroid> centroids)
    {
        List<Cluster> list = new();

        foreach (var centroid in centroids)
        {
            list.Add(new Cluster(centroid));
        }

        return list;
    }

    public static Cluster GetClusterFromCentroid(List<Cluster> clusters, Centroid centroid)
    {
        foreach (var cluster in clusters)
        {
            if (cluster.centroid.Equals(centroid))
            {
                return cluster;
            }
        }

        throw new AbandonedMutexException("Nu se puate!");
    }

    public void GetCentruDeGreutate()
    {
        int xAvg = 0;
        int yAvg = 0;
        foreach (var point in points)
        {
            xAvg += point.point.X;
            yAvg += point.point.Y;
        }

        xAvg = xAvg/points.Count;
        yAvg = yAvg/points.Count;

        centroid.Point = new Point(xAvg, yAvg);
    }
}