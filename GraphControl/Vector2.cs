using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GraphControl
{
    public struct Vector2
    {
        public int X { get; set; }
        public int Width { get { return X; } set { X = value; } }

        public int Y { get; set; }
        public int Height { get { return Y; } set {Y = value; } }

        public float Lenght() => (float)Math.Sqrt(X * X + Y * Y);

        #region --Конструкторы--
        public Vector2(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public Vector2(int x)
        {
            this.X = x;
            this.Y = x;
        }
        public Vector2(Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }
        public Vector2(Size size)
        {
            this.X = size.Width;
            this.Y = size.Height;
        }
        #endregion

        #region --Арифметические операторы--
        public static Vector2 operator +(Vector2 v1, Vector2 v2) =>
    new Vector2(v1.X + v2.X, v1.Y + v2.Y);

        public static Vector2 operator -(Vector2 v1, Vector2 v2) =>
    new Vector2(v1.X - v2.X, v1.Y - v2.Y);

        public static Vector2 operator *(Vector2 v, int multiplier) =>
    new Vector2(v.X * multiplier, v.Y * multiplier);

        public static Vector2 operator /(Vector2 v, int divisor) =>
    new Vector2(v.X / divisor, v.Y / divisor);
        #endregion

        #region --Оператора приведения--
        public static implicit operator Point(Vector2 vector)
        {
            return new Point(vector.X, vector.Y);
        }
        public static implicit operator PointF(Vector2 vector)
        {
            return new Point(vector.X, vector.Y);
        }
        public static implicit operator Size(Vector2 vector)
        {
            return new Size(vector.X, vector.Y);
        }
        public static implicit operator Vector2(Point point)
        {
            return new Vector2(point.X, point.Y);
        }
        public static implicit operator Vector2(Size size)
        {
            return new Vector2(size.Width, size.Height);
        }
        #endregion
    }
}
