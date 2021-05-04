using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLib
{
    /// <summary>
    /// Вершина графа Graph.
    /// </summary>
    /// <typeparam name="N">Тип данных, хранящихся в вершинах графа.</typeparam>
    /// <typeparam name="E">Тип данных, хранящихся в ребрах графа.</typeparam>
    public class Node<N, E>
    {

        /// <summary>
        /// Данные, хранящиеся в вершине графа.
        /// </summary>
        public N Data { get; set; }

        /// <summary>
        /// Ребра, связанные с вершиной.
        /// </summary>
        internal List<Edge<N, E>> edges = new List<Edge<N, E>>();

        /// <summary>
        /// Соседние по общим ребрам вершины.
        /// </summary>
        internal List<Node<N, E>> nears = new List<Node<N, E>>();

        /// <summary>
        /// Уникальный номер вершины в графе.
        /// </summary>
        public ushort Id { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса c указанным номером.
        /// </summary>
        /// <param name="Id">Уникальный номер вершины.</param>
        public Node(ushort Id)
        {
            this.Id = Id;
        }

        /// <summary>
        /// Связывает с вершиной ребро-параметр. Если ребро уже связано, вызывает ArgumentException.
        /// </summary>
        /// <param name="edge">Ребро, которое связывается с вершиной.</param>
        internal void AddEdge(Edge<N, E> edge)
        {
            if (!edge.Сontain(this)) throw new ArgumentException();

            edges.Add(edge);
        }

        /// <summary>
        /// Добавляет с список соседей вершину-параметр.
        /// </summary>
        /// <param name="node">Сосед, который связывается с вершиной.</param>
        internal void AddNear(Node<N, E> node)
        {
            if (nears.Contains(node)) return;

            nears.Add(node);
        }

        /// <summary>
        /// Метод считает степени полузахода и полувыхода вершины.
        /// </summary>
        /// <param name="negativeDeg">Степень полузаходв вершины.</param>
        /// <param name="positiveDeg">Степень полувыхода вершины.</param>
        public void Degree(out ushort negativeDeg, out ushort positiveDeg)
        {
            positiveDeg = 0;
            negativeDeg = 0;
            foreach (var edge in edges)
                if (edge.Node1 == this) positiveDeg++;
                else negativeDeg++;
        }

        /// <summary>
        /// Метод считает степень вершины.
        /// </summary>
        /// <returns>Степень вершины.</returns>
        public ushort Degree()
        {
            return (ushort)edges.Count;
        }

        public override string ToString()
        {
            return $"Node: id = {this.Id}";
        }
    }

}
