using System.Drawing;

namespace WindowsFormsApplication1
{
    class Constants
    {
        public const int NR_PUNCTE = 100000;

        public static Zone[] GetZones()
        {
            Zone[] zones = new Zone[3];
            zones[0] = new Zone(180, 120, 10, 10, Color.Red);
            zones[1] = new Zone(-110, 110, 15, 10, Color.Green);
            zones[2] = new Zone(210, -150, 5, 20, Color.Blue);

            return zones;
        }
    }
}
