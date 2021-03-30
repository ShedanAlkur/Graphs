using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GraphLib;
using GraphControl;


namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            _Test_VisGraph();

            Console.ReadLine();
        }

        static void _Test_VisGraph()
        {
            //test

            //VisGraph graph = new VisGraph();
            //graph.AddNode(0);
            //graph.AddNode(1);
            //graph.Nodes[0].Data = new NodeData()
            //{
            //    color = Color.Red,
            //};
            //graph.Nodes[1].Data = new NodeData()
            //{
            //    color = Color.Blue,
            //};
            //graph.AddEdge(0, 1);
            //Console.WriteLine(graph.Edges[0]
            //    .Pair<NodeData>(graph.Nodes[0])
            //    .Data.color);
        }

        /// <summary>
        /// Функция определяет, находится ли точка на отрезке заданной ширины.
        /// </summary>
        /// <param name="pos">Точка, для которой выполняется проверка.</param>
        /// <param name="p1">Начальная точка отрезка.</param>
        /// <param name="p2">Конечная точка отрезка.</param>
        /// <param name="width">Ширина отрезка.</param>
        /// <returns>Находится ли точка на отрезке.</returns>
        static public bool PointOnLineCheck(Point pos, Point p1, Point p2, int width)
        {
            if (pos.Y < Min(p1.Y, p2.Y) || pos.Y > Max(p1.Y, p2.Y)) 
                return false;
            float tg = (p2.Y - p1.Y) / (p2.X - p1.X);
            float predictedY = p1.Y + tg * (pos.X - p1.X);
            bool located = Abs(pos.Y - predictedY) <= width;
            return located;
        }
        static private float Abs(float f) => (f < 0) ? -f : f;
        static private int Min(int x1, int x2) => (x1 < x2) ? x1 : x2;
        static private int Max(int x1, int x2) => (x1 < x2) ? x2 : x1;
    }
}
