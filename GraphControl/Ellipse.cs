using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GraphControl
{
    public struct Ellipse
    {
        public int X { get; set; }
        public int Left { get { return X; } set { X = value; } }
        public int Right { get => X + Width; }
        public int Y { get; set; }
        public int Top { get { return Y; } set { Y = value; } }
        public int Bottom { get => Y + Height; }

        public int Width { get; set; }
        public int Height { get; set; }

        public Vector2 TopLeft
        {
            get => new Vector2(X, Y);
            set
            {
                this.X = value.X;
                this.Y = value.Y;
            }
        }

        public Vector2 Middle
        {
            get
            {
                return new Vector2(X + Width / 2, Y + Height / 2);
            }
            set
            {
                this.X = value.X - Width / 2;
                this.Y = value.Y - Height / 2;
            }
        }

        public Ellipse(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public bool Contains(int x, int y) =>
            x >= this.Left &&
            x <= this.Right &&
            y >= this.Top &&
            y <= this.Bottom;
        public bool Contains(Vector2 vector) => 
            Contains(vector.X, vector.Y);

        public void SetSize(int width, int height)
        {
            Vector2 originalMiddle = Middle;
            this.Width = width;
            this.Height = height;
            Middle = originalMiddle;
        }
        public void SetSize(int width) => 
            SetSize(width, width);
        public void SetSize(Vector2 size) => 
            SetSize(size.Width, size.Height);

        public void Shift(int x, int y)
        {
            this.X += x;
            this.Y += y;
        }
        public void Shift(Vector2 vector) =>
            Shift(vector.X, vector.Y);


        public static implicit operator Rectangle(Ellipse ell)
        {
            return new Rectangle(ell.Left, ell.Top, ell.Width, ell.Height);
        }

        public static implicit operator Ellipse(Rectangle rect)
        {
            return new Ellipse(rect.X, rect.Y, rect.Width, rect.Height);
        }

    }
}
