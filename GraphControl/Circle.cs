using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GraphControl
{
    public struct Circle
    {
        #region --Поля и свойства--
        private int x;
        /// <summary>
        /// Возвращает или задает координату по оси X левого верхнего угла прямоугольника, в который вписана структура.
        /// </summary>
        public int X 
        {
            get { return x; } 
            set { x = value; }
        }
        /// <summary>
        /// Возвращает и координату по оси X левого края прямоугольника, в который вписана структура.
        /// </summary>
        public int Left { get => X; }
        /// <summary>
        /// Возвращает или задает координату по оси X правого края прямоугольника, в который вписана структура.
        /// </summary>
        public int Right { get => X + diameter; }

        private int y;
        /// <summary>
        /// Возвращает или задает координату по оси Y левого верхнего угла прямоугольника, в который вписана структура.
        /// </summary>
        public int Y 
        {
            get { return y; }
            set { y = value; }
        }
        /// <summary>
        /// Возвращает и координату по оси Y верхнего края прямоугольника, в который вписана структура.
        /// </summary>
        public int Top { get => Y; }
        /// <summary>
        /// Возвращает и координату по оси Y нижнего края прямоугольника, в который вписана структура.
        /// </summary>
        public int Bottom { get => Y + diameter; }

        public int diameter;
        /// <summary>
        /// Возвращает или задает диаметр структуры.
        /// </summary>
        public int Diameter
        {
            get { return diameter; }
            set 
            { 
                Vector2 originalMiddle = Middle;
                this.diameter = value;
                Middle = originalMiddle;
            }
        }

        /// <summary>
        /// Возвращает или задает координаты левого верхнего угла структуры.
        /// </summary>
        public Vector2 TopLeft
        {
            get => new Vector2(x, y);
            set
            {
                this.x = value.X;
                this.y = value.Y;
            }
        }

        /// <summary>
        /// Возвращает или задает координаты центра структуры.
        /// </summary>
        public Vector2 Middle
        {
            get
            {
                return new Vector2(x + diameter / 2, y + diameter / 2);
            }
            set
            {
                this.x = value.X - diameter / 2;
                this.y = value.Y - diameter / 2;
            }
        }
        #endregion

        /// <summary>
        /// Инициализирует новый экзмепляр структуры.
        /// </summary>
        /// <param name="x">Координата по оси X левого верхнего угла прямоугольника, в который вписана структура.</param>
        /// <param name="y">Координата по оси Y левого верхнего угла прямоугольника, в который вписана структура.</param>
        /// <param name="diameter">Диаметр структуры.</param>
        public Circle(int x, int y, int diameter)
        {
            this.x = x;
            this.y = y;
            this.diameter = diameter;
        }

        /// <summary>
        /// Определяет,содержится ли заданная точка в структуре.
        /// </summary>
        /// <param name="x">Координата тестируемой точки по оси X.</param>
        /// <param name="y">Координата тестируемой точки по оси Y.</param>
        /// <returns>True - если заданная точка содержится в структуре, иначе False.</returns>
        public bool Contains(int x, int y) =>
            x >= this.Left &&
            x <= this.Right &&
            y >= this.Top &&
            y <= this.Bottom;
        /// <summary>
        /// Определяет,содержится ли заданная точка в структуре.
        /// </summary>
        /// <param name="vector">Координата тестируемой точки.</param>
        /// <returns>True - если заданная точка содержится в структуре, иначе False.</returns>
        public bool Contains(Vector2 vector) => 
            Contains(vector.X, vector.Y);

        /// <summary>
        /// Изменяет положение структуры на заданную величину.
        /// </summary>
        /// <param name="x">Горизонтальное смещение.</param>
        /// <param name="y">Вертикальное смещение.</param>
        public void Offset(int x, int y)
        {
            this.x += x;
            this.y += y;
        }
        /// <summary>
        /// Изменяет положение структуры на заданную величину.
        /// </summary>
        /// <param name="vector">Величина, на которую смещается положение.</param>
        public void Offset(Vector2 vector) =>
            Offset(vector.X, vector.Y);


        public static implicit operator Rectangle(Circle ell)
        {
            return new Rectangle(ell.Left, ell.Top, ell.Diameter, ell.Diameter);
        }

        public static explicit operator Circle(Rectangle rect)
        {
            return new Circle(rect.X, rect.Y, rect.Width);
        }

        public override string ToString()
        {
            return $"x = {X}, y = {Y}, diameter = {diameter}";
        }
    }
}
