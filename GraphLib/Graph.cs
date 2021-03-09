using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLib
{
    /// <summary>
    /// Класс графа.
    /// </summary>
    /// <typeparam name="N">Тип элементов в вершинах графа.</typeparam>
    public class Graph<N>
    { 
        /// <summary>
        /// Список вершин графа.
        /// </summary>
        public List<N> Nodes { get;  private set; }

        /// <summary>
        /// Матрица инцидентности графа.
        /// Индексы ячеек массива соответствуют номеру вершиы в списке Nodes.
        /// </summary>
        public byte[][] IncidenceMatrix { get; private set; }

        /// <summary>
        /// Взвешен ли граф.
        /// </summary>
        public bool WeightedGraphs { get; private set; }

        /// <summary>
        /// Матрица весов ребер графа.
        /// Индексы ячеек массива соответствуют номеру вершиы в списке Nodes.
        /// </summary>
        public float WeightMatrix { get; private set; }

        /// <summary>
        /// Функция нахождения кратчайшего пути между двумя вершинами графа.
        /// </summary>
        /// <param name="node1">Номер вершины начала пути.</param>
        /// <param name="node2">Номер вершины окончания пути.</param>
        /// <returns>Перечень номеров вершин, входящих в путь.</returns>
        public ushort[] ShortestPath(ushort node1, ushort node2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Функция нахождения хроматического числа графа.
        /// </summary>
        /// <returns>Массив с номерами цветов для каждой вершины графа./returns>
        public byte[] Coloring()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Функция нахождения сильных компонент связности графа.
        /// </summary>
        /// <returns></returns>
        public ushort[][] ConnectedComponents()
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Функция нахожденя локальных степеней вершин графа.
        /// </summary>
        /// <returns>Массив с локальными степениями для каждой вершины графа.</returns>
        public ushort[] VerticesDegree()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Функция нахождения объединения двух графов.
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="g2"></param>
        /// <returns>Результат объединения двух графов.</returns>
        public static Graph<N> Union(Graph<N> g1, Graph<N> g2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Функция нахождения пересечения двух графов.
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="g2"></param>
        /// <returns>Результат пересечения двух графов.</returns>
        public static Graph<N> Intersection(Graph<N> g1, Graph<N> g2)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Функция нахождения композиции двух графов g1(g2).
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="g2"></param>
        /// <returns>Результат композиции двух графов.</returns>
        public static Graph<N> LexicographicalProduct(Graph<N> g1, Graph<N> g2)
        {
            throw new NotImplementedException();
        }
    }
}
