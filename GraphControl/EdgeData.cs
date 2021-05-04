using GraphLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GraphControl
{
    public class EdgeData
    {
        private int width, nodeRadius;

        /// <summary>
        /// Координата начала ребра.
        /// </summary>
        public Vector2 P1;
        /// <summary>
        /// Координата конца ребра.
        /// </summary>
        public Vector2 P2;

        /// <summary>
        /// Возвращает или задает ширину ребра.
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="P1">Координата центра начальной вершины ребра.</param>
        /// <param name="P2">Координата центра конечной вершины ребра.</param>
        /// <param name="width">Ширина ребра.</param>
        /// <param name="nodeRadius">Радиус вершин, которые связаны с ребром.</param>
        public EdgeData(Vector2 P1, Vector2 P2, int width, int nodeRadius)
        {
            double angle = Math.Atan2(P1.Y - P2.Y, P1.X - P2.X);
            Vector2 vectorWithinNode = Vector2.CreateByAngle(nodeRadius, angle); // Смещение на границу вершины.
            Vector2 shift = new Vector2((int)(nodeRadius / 2 * Math.Sin(angle)), // Смещение от центральной линии вправо.
                -(int)(nodeRadius / 2 * Math.Cos(angle)));
            this.P1 = P1 - vectorWithinNode + shift;
            this.P2 = P2 + vectorWithinNode + shift;
            this.width = width;
            this.nodeRadius = nodeRadius;
        }

        /// <summary>
        /// Устанавливает новые координаты начала и конца ребра.
        /// </summary>
        /// <param name="P1">Координата начала ребра.</param>
        /// <param name="P2">Координата конца ребра.</param>
        public void SetPosition(Vector2 P1, Vector2 P2)
        {
            double angle = Math.Atan2(P1.Y - P2.Y, P1.X - P2.X);
            Vector2 vectorWithinNode = Vector2.CreateByAngle(nodeRadius, angle);
            Vector2 shift = new Vector2((int)(nodeRadius / 2 * Math.Sin(angle)),
                -(int)(nodeRadius / 2 * Math.Cos(angle)));
            this.P1 = P1 - vectorWithinNode + shift;
            this.P2 = P2 + vectorWithinNode + shift;
        }

        /// <summary>
        /// Определяет, лежит ли заданная точка на прямой
        /// </summary>
        /// <param name="pos"></param>
        /// <returns>True - если заданная точка содержится на прямой, иначе False.</returns>
        public bool Collision(Vector2 pos)
        {
            if (pos.Y < Math.Min(P1.Y, P2.Y) || pos.Y > Math.Max(P1.Y, P2.Y))
                return false;
            float ctg = ((float)P2.Y - P1.Y) / (P2.X - P1.X);
            float predictedY = P1.Y + ctg * (pos.X - P1.X);
            bool located = Math.Abs(pos.Y - predictedY) <= Width;
            //Console.WriteLine($"Ожидается {pos}, получено x = {pos.X} y = ({predictedY - Width};{predictedY + Width})");

            return located;
        }

        /// <summary>
        /// Возвращает координату середины прямой.
        /// </summary>
        public Vector2 Middle
        {
            get { return P1 + (P2 - P1) / 2; }
        }

        public override string ToString()
        {
            return $"Edge: p1({P1}), p2({P2}), width = {Width}";
        }
    }
}
