using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GraphLib
{
    /// <summary>
    /// Класс математической модели графа.
    /// </summary>
    /// <typeparam name="N">Тип данных, хранящихся в вершинах графа.</typeparam>
    /// <typeparam name="E">Тип данных, хранящихся в ребрах графа.</typeparam>
    public partial class Graph<N, E>
    {
        private List<Node<N, E>> nodes = new List<Node<N, E>>();

        /// <summary>
        /// Список вершин графа.
        /// </summary>
        public ReadOnlyCollection<Node<N, E>> Nodes;

        private List<Edge<N, E>> edges = new List<Edge<N, E>>();

        /// <summary>
        /// Список ребер графа.
        /// </summary>
        public ReadOnlyCollection<Edge<N, E>> Edges;

        /// <summary>
        /// Все ли ребра графа взвешены.
        /// </summary>
        public bool Weighted
        {
            get
            {
                foreach (var edge in edges)
                    if (!edge.Weighed) return false;
                return true;
            }
        }

        /// <summary>
        /// Все ли ребра графа не взвешены.
        /// </summary>
        public bool Unweighted
        {
            get
            {
                foreach (var edge in edges)
                    if (edge.Weighed) return false;
                return true;
            }
        }

        /// <summary>
        /// Все ли ребра графа ориентированы.
        /// </summary>
        public bool Directed
        {
            get
            {
                foreach (var edge in edges)
                    if (!edge.Directed) return false;
                return true;
            }
        }

        /// <summary>
        /// Все ли ребра графа не ориентированы.
        /// </summary>
        public bool Undirected
        {
            get
            {
                foreach (var edge in edges)
                    if (edge.Directed) return false;
                return true;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса, который является пустым.
        /// </summary>
        public Graph()
        {
            Nodes = nodes.AsReadOnly();
            Edges = edges.AsReadOnly();
        }

        /// <summary>
        /// Метод добавления в граф новой вершины.
        /// </summary>
        /// <returns>Экземпляр добавленной в граф вершины.</returns>
        public Node<N, E> AddNode()
        {
            if (nodes.Count >= ushort.MaxValue) 
                throw new InvalidOperationException("В графе достигнуто максимальное количество вершин.");

            for (ushort id = 0; id <= ushort.MaxValue; id++)
                if (!nodes.Exists(x => (x.Id == id)))
                {
                    nodes.Add(new Node<N, E>(id));
                    break;
                }
            return nodes.Last();
        }

        /// <summary>
        /// Метод добавления в граф новой вершины.
        /// </summary>
        /// <param name="Id">id добавляемой вершины.</param>
        /// <returns>Удалось ли добавить вершину с указаным id.</returns>
        public bool AddNode(ushort Id)
        {
            if (nodes.Count >= ushort.MaxValue) throw new OverflowException();

            if (nodes.Exists(x => (x.Id == Id))) return false;
            nodes.Add(new Node<N, E>(Id));
            return true;            
        }

        /// <summary>
        /// Метод добавления в граф нового ребра.
        /// </summary>
        /// <param name="node1">Первая вершина ребра.</param>
        /// <param name="node2">Вторая вершины ребра.</param>
        /// <param name="directed">Ориентировано ли ребро.</param>
        /// <param name="weight">Вес ребра.</param>
        /// <returns>Экземпляр добавленного ребра.</returns>
        public Edge<N, E> AddEdge(Node<N, E> node1, Node<N, E> node2, bool directed, float weight)
        {
            if (edges.Exists(x => x.Сontain(node1, node2))) throw new ArgumentException("Граф уже содержит добавляемое ребро.");

            Edge<N, E> edge = new Edge<N, E>(node1, node2, directed, weight);
            node1.AddEdge(edge);
            node2.AddEdge(edge);
            node1.AddNear(node2);
            node2.AddNear(node1);
            edges.Add(edge);

            return edge;
        }

        /// <summary>
        /// Метод добавления в граф нового ребра.
        /// </summary>
        /// <param name="id1">id первой вершина ребра.</param>
        /// <param name="id2">id второй вершины ребра.</param>
        /// <param name="directed">Ориентировано ли ребро.</param>
        /// <param name="weight">Вес ребра.</param>
        /// <returns>Экземпляр добавленного ребра.</returns>
        public Edge<N, E> AddEdge(ushort id1, ushort id2, bool directed, float weight)
        {
            Node<N, E> node1 = nodes.Find(x => (x.Id == id1));
            Node<N, E> node2 = nodes.Find(x => (x.Id == id2));
            return AddEdge(node1, node2, directed, weight);
        }

        /// <summary>
        /// Метод добавления в граф нового ребра.
        /// </summary>
        /// <param name="node1">Первая вершина ребра.</param>
        /// <param name="node2">Вторая вершины ребра.</param>
        /// <param name="directed">Ориентировано ли ребро.</param>
        /// <returns>Экземпляр добавленного ребра.</returns>
        public Edge<N, E> AddEdge(Node<N, E> node1, Node<N, E> node2, bool directed)
        {
            if (edges.Exists(x => x.Сontain(node1, node2))) throw new ArgumentException("Граф уже содержит добавляемое ребро.");

            Edge<N, E> edge = new Edge<N, E>(node1, node2, directed);
            node1.AddEdge(edge);
            node2.AddEdge(edge);
            node1.AddNear(node2);
            node2.AddNear(node1);
            edges.Add(edge);

            return edge;
        }

        /// <summary>
        /// Метод добавления в граф нового ребра.
        /// </summary>
        /// <param name="id1">id первой вершина ребра.</param>
        /// <param name="id2">id второй вершины ребра.</param>
        /// <param name="directed">Ориентировано ли ребро.</param>
        /// <returns>Экземпляр добавленного ребра.</returns>
        public Edge<N, E> AddEdge(ushort id1, ushort id2, bool directed)
        {
            Node<N, E> node1 = nodes.Find(x => (x.Id == id1));
            Node<N, E> node2 = nodes.Find(x => (x.Id == id2));
            return AddEdge(node1, node2, directed);
        }

        /// <summary>
        /// Метод удаления из графа вершины.
        /// </summary>
        /// <param name="id">id удаляемой вершины.</param>
        public void RemoveNode(ushort id)
        {
            for (int j = 0; j < nodes.Count(); j++)
                if (nodes[j].Id == id)
                {
                    RemoveNode(nodes[j]);
                    return;
                }
            throw new ArgumentException("Список вершин не содержит элемента с id - аргументом.");
        }

        /// <summary>
        /// Метод удаления из графа вершины.
        /// </summary>
        /// <param name="removedNode">Удаляемая вершина.</param>
        public void RemoveNode(Node<N, E> removedNode)
        {
            if (!nodes.Contains(removedNode))
                throw new ArgumentException("Список вершин не содержит элемента removedNode.");

            foreach (Edge<N, E> edge in removedNode.edges)
            {
                Node<N, E> neighbor = edge.Pair(removedNode); // Находим соседа вершины по ребру edge.
                neighbor.nears.Remove(removedNode); // Обновляем список соседей соседа.
                neighbor.edges.Remove(edge); // Обновляем список ребер соседа.
                edges.Remove(edge); // Удаляем из графа ребро.
            }
            nodes.Remove(removedNode); // Удаляем из графа вершину.
            return;

        }

        /// <summary>
        /// Метод удаления ребра из графа.
        /// </summary>
        /// <param name="removedEdge"></param>
        public void RemoveEdge(Edge<N, E> removedEdge)
        {
            if (!edges.Contains(removedEdge))
                throw new ArgumentException("Список ребер не содержит элемента removedEdge.");

            removedEdge.Node1.edges.Remove(removedEdge);
            removedEdge.Node1.nears.Remove(removedEdge.Node2);
            removedEdge.Node2.edges.Remove(removedEdge);
            removedEdge.Node2.nears.Remove(removedEdge.Node1);
            edges.Remove(removedEdge);
        }

        /// <summary>
        /// Метод удаления ребра из графа.
        /// </summary>
        /// <param name="id1">id первой вершина ребра.</param>
        /// <param name="id2">id второй вершины ребра.</param>
        public void RemoveEdge(ushort id1, ushort id2)
        {
            Node<N, E> node1 = nodes.Find(x => (x.Id == id1));
            if (node1 is null) throw new ArgumentException("Список ребер не содержит указанного элемента.");
            Node<N, E> node2 = nodes.Find(x => (x.Id == id2));
            if (node2 is null) throw new ArgumentException("Список ребер не содержит указанного элемента.");

            RemoveEdge(id1, id2);
        }

        /// <summary>
        /// Создает граф по матрице смежности вершин.
        ///  Если граф не взвешенный, каждое значение больше 1 рассатривается как 1. 
        ///  Если граф неориентированный, рассматриваются только элементы матрицы выше главной диагонали.
        /// </summary>
        /// <param name="matrix">Квадратная матрица смежности вершин.</param>
        /// <param name="directed">Ориентирован ли граф.</param>
        /// <param name="weighted">Взвешен ли граф.</param>
        /// <returns>Созданный граф.</returns>
        static public Graph<n, e> CreateByAdjacencyMatrix<n, e>(float[,] matrix, bool directed, bool weighted)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) 
                throw new ArgumentException("Матрица смежности matrix должна быть квадратной");

            Graph<n, e> graph = new Graph<n, e>();
            for (ushort i = 0; i < matrix.GetLength(0); i++)
                graph.AddNode(i);
            if (directed)
            {
                if (weighted)
                {
                    for (ushort i = 0; i < matrix.GetLength(0); i++)
                        for (ushort j = 0; j < matrix.GetLength(1); j++)
                            if (matrix[i, j] > 0)
                                graph.AddEdge(i, j, directed, matrix[i, j]);
                }
                else 
                    for (ushort i = 0; i < matrix.GetLength(0); i++)
                        for (ushort j = 0; j < matrix.GetLength(1); j++)
                            if (matrix[i, j] > 0)
                                graph.AddEdge(i, j, directed);
            }
            else 
            if (weighted)
            {
                for (ushort i = 0; i < matrix.GetLength(0); i++)
                    for (ushort j = i; j < matrix.GetLength(1); j++)
                        if (matrix[i, j] > 0)
                            graph.AddEdge(i, j, directed, matrix[i, j]);
            }
            else
                for (ushort i = 0; i < matrix.GetLength(0); i++)
                    for (ushort j = i; j < matrix.GetLength(1); j++)
                        if (matrix[i, j] > 0)
                            graph.AddEdge(i, j, directed);

            return graph;
        }

        /// <summary>
        /// Метод создает матрицу смежности графа.
        /// Индексы ячеек массива соответствуют номеру вершины в списке Nodes.
        /// </summary>
        /// <returns>Матрица смежности графа.</returns>
        public float[,] AdjacencyMatrix()
        {
            float[,] matrix = new float[nodes.Count, nodes.Count];

            bool directed = Directed;
            bool weighted = Weighted;

            if (directed)
            {
                for (int i = 0; i < nodes.Count; i++)
                    for (int j = (Directed) ? 0 : i + 1; j < nodes.Count; j++)
                        if (nodes[i].nears.Contains(nodes[j]))
                            matrix[i, j] = (weighted) ?
                                edges.Find(x => x.Сontain(nodes[i], nodes[j])).Weight : 1;
            }
            else
                for (int i = 0; i < nodes.Count; i++)
                    for (int j = i + 1; j < nodes.Count; j++)
                        if (nodes[i].nears.Contains(nodes[j]))
                        {
                            float value = (weighted) ?
                                edges.Find(x => x.Сontain(nodes[i], nodes[j])).Weight : 1;
                            matrix[i, j] = value;
                            matrix[j, i] = value;
                        }

            return matrix;
        }

        //todo: определение кратчайшего пути.
        //todo: максимальный потому в сети.
        //todo: задача коммивояжера.
    }
}
