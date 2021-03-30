using GraphLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GraphControl
{
    public struct NodeData
    {
        public Ellipse Ellipse;
        public Vector2 Position
        {
            get => Ellipse.Middle;
            set { Ellipse.Middle = value; }        
        }
        
        public void SetPosition(Vector2 value)
        {
            Ellipse.Middle = value;
        }
        public int Top { get => Ellipse.Top; }
        public int Left { get => Ellipse.Left; }
        public int Right { get => Ellipse.Right; }
        public int Bottom { get => Ellipse.Bottom; }
        public int Width { get => Ellipse.Width; }
        public int Height { get => Ellipse.Height; }

        public bool Collision(Vector2 point) =>
            Ellipse.Contains(point);

        internal void SetDiameter(int diameter)
        {
            Ellipse.SetSize(diameter);
        }

        public NodeData(Vector2 position, int diameter)
        {
            this.Ellipse = new Ellipse(0, 0, diameter, diameter);
            this.Position = position;
        }
    }
}
