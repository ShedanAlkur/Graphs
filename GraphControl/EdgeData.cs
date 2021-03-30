using GraphLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GraphControl
{
    public struct EdgeData
    {
        public int Width;
        public Vector2 P1, P2;

        public bool Collision(Vector2 pos)
        {
            if (pos.Y < Math.Min(P1.Y, P2.Y) || pos.Y > Math.Max(P1.Y, P2.Y))
                return false;
            float tg = (P2.Y - P1.Y) / (P2.X - P1.X);
            float predictedY = P1.Y + tg * (pos.X - P1.X);
            bool located = Math.Abs(pos.Y - predictedY) <= Width;
            return located;
        }
    }
}
