using WindowsFormsApplication1;

namespace K_Means;

public class ColoredPoint
{
    public Point point;
    public Color Color { get; set; }
    public readonly Size size;

    public ColoredPoint(int x, int y)
    {
        point = new Point(x, y);
        Color = WindowsFormsApplication1.Constants.DefaultPointColor;
        size = new Size(4, 4);
    }

    public ColoredPoint(Point point)
    {
        this.point = point;
        Color = WindowsFormsApplication1.Constants.DefaultPointColor;
        size = new Size(2, 2);
    }
}