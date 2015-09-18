using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;

namespace win2d_procedural_rooms
{
    class Room
    {
        public Vector2 Position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color Color { get; set; }

        public void Draw(CanvasAnimatedDrawEventArgs args)
        {
            args.DrawingSession.FillRectangle(new Rect(Position.X, Position.Y, Width * Statics.PixelScale, Height * Statics.PixelScale), Color);
        }

        public static Room CreateRandomRoom()
        {
            Room room = new Room();
            room.Width = 2 + Statics.Random.Next(9);
            room.Height = 2 + Statics.Random.Next(9);
            room.Color = Statics.RandomColor();
            room.Position = Statics.RandomPointInCircle();
            return room;
        }
    }
}
