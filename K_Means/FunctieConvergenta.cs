namespace K_Means;

public class FunctieConvergenta
{
    public double CalculFunctieConvergenta()
    {
        double suma = 0;

        foreach (var cluster in Geometry.Clusters)
        {
            foreach (var p in cluster.points)
            {
                suma += Geometry.GetPointCentroidEuclideanDistance(p, cluster.centroid);
            }
        }

        return suma;
    }
}