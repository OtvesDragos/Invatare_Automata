namespace K_Means;

public class Centroid
{
    public Point Point { get; set; }
    public readonly Size Size = new(10,10);
    public Color Color { get; set; }

    public static Centroid GetRandomCentroid(Random random)
    {
        return new Centroid
        {
            Point = new Point(random.Next(-300, 300), random.Next(-300,300)),
            Color = Color.FromArgb(random.Next(256),
                random.Next(256),
                random.Next(256))
        };
    }

    public static List<Centroid> GetRandomCentroidList(Random random)
    {
        var index = random.Next(2, 10);
        var list = new List<Centroid>();
        for(int i = 0; i < index; i++)
        {
            list.Add(GetRandomCentroid(random));
        }

        return list;
    }
}