using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace win2d_procedural_rooms
{
    public static class Statics
    {
        public static int PixelScale = 10;

        public static Random Random = new Random(DateTime.Now.Millisecond);

        public static int CircleRadius = 100;
        public static int CenterScreenX { get; set; }
        public static int CenterScreenY { get; set; }
        public static Vector2 RandomPointInCircle()
        {
            double t = 2 * Math.PI * Random.NextDouble();
            double u = Random.NextDouble() + Random.NextDouble();
            double r = u > 1 ? 2 - u : u;

            return new Vector2((float)(Statics.CenterScreenX - CircleRadius * r * Math.Cos(t)), (float)(Statics.CenterScreenY - CircleRadius * r * Math.Sin(t)));
        }

        public static Color RandomColor()
        {
            byte red = (byte)Random.Next(255);
            byte green = (byte)Random.Next(255);
            byte blue = (byte)Random.Next(255);

            return Color.FromArgb(255, red, green, blue);
        }
    }
}
