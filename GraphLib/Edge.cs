using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLib
{
    /// <summary>
    /// Ребро графа Graph.
    /// </summary>
    /// <typeparam name="N">Тип данных, хранящихся в вершинах графа.</typeparam>
    /// <typeparam name="E">Тип данных, хранящихся в ребрах графа.</typeparam>
    public class Edge<N, E>
    {
        /// <summary>
        /// Данные, хранящиеся в ребре графа.
        /// </summary>
        public E Data { get; set; }

        /// <summary>
        /// Вершина, их которой исходит ребро.
        /// </summary>
        public Node<N, E> Node1 { get; private set; }

        /// <summary>
        /// Вершина, в которую входит ребро.
        /// </summary>
        public Node<N, E> Node2 { get; private set; }

        /// <summary>
        /// Ориентировано ли ребро.
        /// </summary>
        public bool Directed { get; private set; }

        /// <summary>
        /// Взвешенно ли ребро.
        /// </summary>
        public bool Weighed { get; private set; }

        /// <summary>
        /// Вес ребра.
        /// </summary>
        public float Weight { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса. Ребро взвешено.
        /// </summary>
        /// <param name="node1">Вершина, их которой исходит ребро.</param>
        /// <param name="node2">Вершина, в которую входит ребро.</param>
        /// <param name="directed">Ориентировано ли ребро.</param>
        /// <param name="weight">Вес ребра.</param>
        public Edge(Node<N, E> node1, Node<N, E> node2, bool directed, float weight)
        {
            this.Node1 = node1;
            this.Node2 = node2;
            this.Directed = directed;
            this.Weighed = true;
            this.Weight = weight;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса. Ребро не взвешено.
        /// </summary>
        /// <param name="node1">Вершина, их которой исходит ребро.</param>
        /// <param name="node2">Вершина, в которую входит ребро.</param>
        /// <param name="directed">Ориентировано ли ребро.</param>
        public Edge(Node<N, E> node1, Node<N, E> node2, bool directed)
        {
            this.Node1 = node1;
            this.Node2 = node2;
            this.Directed = directed;
            this.Weighed = false;
        }

        /// <summary>
        /// Находит смежную вершину.
        /// </summary>
        /// <param name="node">Вершина, для которой ищется смежная.</param>
        /// <returns>Смежная вершина или null, если не найдено смежной вершины.</returns>
        public Node<N, E> Pair(Node<N, E> node)
        {
            if (Node1 == node) return Node2;
            if (Node2 == node) return Node1;
            return null;
        }

        /// <summary>
        /// Определяет, связывает ли ребро указанную вершину.
        /// </summary>
        /// <param name="node">Вершина, наличие которой проверяется в ребре.</param>
        /// <returns>Связывает ли ребро указанную вершину.</returns>
        public bool Сontain(Node<N, E> node) 
            => (node == Node1 || node == Node2);

        /// <summary>
        /// Определяет, связывает ли ребро две указанные вершины.
        ///  Для ориентированного ребра важен порядок параметров.
        /// </summary>
        /// <param name="node1">Первая вершина, наличие которой проверяется в ребре.</param>
        /// <param name="node2">Вторая вершина, наличие которой проверяется в ребре.</param>
        /// <returns>Связывает ли ребро указанные вершины.</returns>
        public bool Сontain(Node<N, E> node1, Node<N, E> node2) => 
            (node1 == Node1 && node2 == Node2) || (!Directed && node1 == Node2 && node2 == Node1);

        /// <summary>
        /// Определяет, связывает ли ребро указанную вершину.
        /// </summary>
        /// <param name="id">id вершины, наличие которой проверяется в ребре.</param>
        /// <returns>Связывает ли ребро указанную вершину.</returns>
        public bool Сontain(byte id) => (id == Node1.Id || id == Node2.Id);

        /// <summary>
        /// Определяет, связывает ли ребро две указанные вершины.
        ///  Для ориентированного ребра важен порядок параметров.
        /// </summary>
        /// <param name="id1">id первой вершины, наличие которой проверяется в ребре.</param>
        /// <param name="id2">id второй вершины, наличие которой проверяется в ребре.</param>
        /// <returns>Связывает ли ребро указанные вершины.</returns>
        public bool Сontain(byte id1, byte id2) => 
            (id1 == Node1.Id && id2 == Node2.Id || id1 == Node2.Id && id2 == Node1.Id);
    }

}
