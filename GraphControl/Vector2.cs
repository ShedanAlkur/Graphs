using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GraphControl
{
    public struct Vector2
    {
        /// <summary>
        /// Возвращает или задает координату X вектора.
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Возвращает или задает координату X вектора.
        /// </summary>
        public int Width { get { return X; } set { X = value; } }

        /// <summary>
        /// Возвращает или задает координату Y вектора.
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Возвращает или задает координату Y вектора.
        /// </summary>
        public int Height { get { return Y; } set {Y = value; } }

        /// <summary>
        /// Возвращает длину вектора.
        /// </summary>
        public double Lenght => Math.Sqrt(X * X + Y * Y);
        /// <summary>
        /// Возвращает квадрат длины вектора.
        /// </summary>
        public int SqrLenght => X * X + Y * Y;

        #region --Конструкторы--
        /// <summary>
        /// Инициализирует новый экзмепляр структуры.
        /// </summary>
        /// <param name="x">Возвращает или задает координату X вектора.</param>
        /// <param name="y">Возвращает или задает координату Y вектора.</param>
        public Vector2(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Инициализирует новый экзмепляр структуры по длине вектора и его углу наклона.
        /// </summary>
        /// <param name="radius">Длина вектора.</param>
        /// <param name="angle">Угол (в радианах) между вектором и осью OX.</param>
        /// <returns>Инициадизированый вектор.</returns>
        public static Vector2 CreateByAngle(int radius, double angle)
        {
            return new Vector2((int)(Math.Cos(angle) * radius), (int)(Math.Sin(angle) * radius));
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

        public override string ToString()
        {
            return $"x = {X}, y = {Y}";
        }
    }
}
