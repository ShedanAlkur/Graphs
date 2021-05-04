using GraphLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GraphControl
{
    public class NodeData
    {
        /// <summary>
        /// Круг для заливки вершины.
        /// </summary>
        public Circle FillEllipse;

        /// <summary>
        /// Круг для обводки вершины;
        /// </summary>
        public Circle OutlineEllipse;

        private int diameter;
        private int outlineWidth;


        //public int Top { get => FillEllipse.Top; }
        //public int Left { get => FillEllipse.Left; }
        //public int Right { get => FillEllipse.Right; }
        //public int Bottom { get => FillEllipse.Bottom; }
        //public int Diameter
        //{ 
        //    get => this.diameter;
        //    set
        //    {
        //        FillEllipse.Diameter = diameter;
        //        OutlineEllipse.Diameter = diameter - outlineWidth;
        //    }
        //}
        //public int OutlineWidth
        //{
        //    get { return outlineWidth; }
        //    set
        //    {
        //        outlineWidth = value;
        //        OutlineEllipse.Diameter = diameter - outlineWidth;
        //    }
        //}

        /// <summary>
        /// Воозвращает или задает координату центра вершины.
        /// </summary>
        public Vector2 Middle 
        { 
            get => FillEllipse.Middle;
            set
            {
                FillEllipse.Middle = value;
                OutlineEllipse.Middle = value;
            }
        }

        /// <summary>
        /// Определяет,содержится ли заданная точка в вершине.
        /// </summary>
        /// <param name="point">Координата тестируемой точки</param>
        /// <returns>True - если заданная точка содержится в вершине, иначе False.</returns>
        public bool Collision(Vector2 point) =>
            FillEllipse.Contains(point);

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="middle">Воозвращает или задает координату центра вершины.</param>
        /// <param name="diameter">Диаметр вершины.</param>
        /// <param name="outlineWidth">Ширина обводки вершины.</param>
        public NodeData(Vector2 middle, int diameter, int outlineWidth)
        {
            this.outlineWidth = outlineWidth;
            this.diameter = diameter;
            int fillRadius = diameter / 2;
            int halfOutlineWidth = this.outlineWidth / 2;

            this.FillEllipse =
                new Circle(middle.X - fillRadius, middle.Y - fillRadius, diameter);
            this.OutlineEllipse =
                new Circle(middle.X - fillRadius  + halfOutlineWidth, middle.Y - fillRadius + halfOutlineWidth, 
                diameter - outlineWidth);

        }

        public override string ToString()
        {
            return $"FillEllipse: {FillEllipse}";
        }
    }
}
