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
    /// <typeparam name="E">Тип элементов в ребрах графа.</typeparam>
    public class Graph<N, E>
    {
        /// <summary>
        /// Список вершин графа.
        /// </summary>
        public List<Node<N>> Nodes = new List<Node<N>>();

        /// <summary>
        /// Список ребер графа.
        /// </summary>
        public List<Edge<E>> Edges = new List<Edge<E>>();

        /// <summary>
        /// Взвешен ли граф.
        /// </summary>
        public bool Weighted { get; private set; }

        /// <summary>
        /// Ориентирован ли граф.
        /// </summary>
        public bool Directed { get; private set; }

        /// <summary>
        /// Метод добавления в граф новой вершины.
        /// </summary>
        /// <returns>id добавленной вершины</returns>
        public ushort AddNode()
        {
            if (Nodes.Count >= ushort.MaxValue) throw new OverflowException();
            for (ushort id = 0; id <= ushort.MaxValue; id++)
                if (!Nodes.Exists(x => (x.Id == id)))
                {
                    Nodes.Add(new Node<N>(id));
                    break;
                }
            return Nodes.Last().Id;
        }

        /// <summary>
        /// Метод добавления в граф новой вершины.
        /// </summary>
        /// <param name="Id">id добавляемой вершины.</param>
        /// <returns>Удалось ли добавить вершину с выбранным id.</returns>
        public bool AddNode(byte Id)
        {
            if (Nodes.Count >= ushort.MaxValue) throw new OverflowException();
            if (Nodes.Exists(x => (x.Id == Id))) return false;

            Nodes.Add(new Node<N>(Id));
            return true;            
        }

        /// <summary>
        /// Метод добавления в граф нового ребра.
        /// </summary>
        /// <param name="node1">Первая вершина ребра.</param>
        /// <param name="node2">Вторая вершины ребра.</param>
        /// <param name="directed">Ориентировано ли ребро.</param>
        /// <param name="weight">Вес ребра.</param>
        /// <returns>Удалось ли добавить ребро</returns>
        public bool AddEdge(Node node1, Node node2, bool directed = false, float weight = 0)
        {
            if (Edges.Exists(x => x.Сontain(node1, node2))) return false;

            Edge<E> edge = new Edge<E>(node1, node2, directed, weight);
            node1.AddEdge(edge);
            node1.AddNear(node2);
            node2.AddEdge(edge);
            node2.AddNear(node1);
            Edges.Add(edge);
            return true;
        }

        /// <summary>
        /// Метод добавления в граф нового ребра.
        /// </summary>
        /// <param name="id1">id первой вершина ребра.</param>
        /// <param name="id2">id второй вершины ребра.</param>
        /// <param name="directed">Ориентировано ли ребро.</param>
        /// <param name="weight">Вес ребра.</param>
        /// <returns>Удалось ли добавить ребро</returns>
        public bool AddEdge(byte id1, byte id2, bool directed = false, float weight = 0)
        {
            if (Edges.Exists(x => x.Сontain(id1, id2))) return false;

            Node<N> node1 = Nodes.Find(x => (x.Id == id1));
            Node<N> node2 = Nodes.Find(x => (x.Id == id2));
            return AddEdge(node1, node2, directed, weight);

        }

        /// <summary>
        /// Метод удаления из графа вершины.
        /// </summary>
        /// <param name="id">id удаляемоу вершины.</param>
        public void RemoveNode(int id)
        {
            for (int j = 0; j < Nodes.Count(); j++)
            {
                if (Nodes[j].Id == id)
                {
                    RemoveNode(Nodes[j]);
                    return;
                }
            }
            throw new ArgumentException("Список вершин не содержит элемента с id - аргументом.");
        }

        /// <summary>
        /// Метод удаления из графа вершины.
        /// </summary>
        /// <param name="removedNode">Удаляемая вершина.</param>
        public void RemoveNode(Node<N> removedNode)
        {
            if (!Nodes.Contains(removedNode))
                throw new ArgumentException("Список вершин не содержит элемента removedNode.");

            //TODO: проверить очистку памяти.
            foreach (Edge<E> edge in removedNode.Edges)
            {
                Node neighbor = edge.Pair(removedNode); // Находим соседа вершины по ребру edge.
                neighbor.Nears.Remove(removedNode); // Обновляем список соседей соседа.
                neighbor.Edges.Remove(edge); // Обновляем список ребер соседа.
                Edges.Remove(edge); // Удаляем из графа ребро.
            }
            Nodes.Remove(removedNode); // Удаляем из графа вершину
            return;

        }

        /// <summary>
        /// Создает граф по матрице инцидентности вершин.
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="directed"></param>
        /// <returns>Созданный граф.</returns>
        static public Graph<N, E> CreateByIncidenceMatrix(byte[,] matrix, bool directed)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Матрица инцидентности графа.
        /// Индексы ячеек массива соответствуют номеру вершиы в списке Nodes.
        /// </summary>
        public byte[][] IncidenceMatrix { get; private set; }

        /// <summary>
        /// Матрица весов ребер графа.
        /// Индексы ячеек массива соответствуют номеру вершиы в списке Nodes.
        /// </summary>
        public float WeightMatrix { get; private set; }

        #region Закомментированые методы для дальнейшей реализации

        ///// <summary>
        ///// Функция нахождения кратчайшего пути между двумя вершинами графа.
        ///// </summary>
        ///// <param name="node1">Номер вершины начала пути.</param>
        ///// <param name="node2">Номер вершины окончания пути.</param>
        ///// <returns>Перечень номеров вершин, входящих в путь.</returns>
        //public ushort[] ShortestPath(ushort node1, ushort node2)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Функция нахождения хроматического числа графа.
        ///// </summary>
        ///// <returns>Массив с номерами цветов для каждой вершины графа./returns>
        //public byte[] Coloring()
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Функция нахождения сильных компонент связности графа.
        ///// </summary>
        ///// <returns></returns>
        //public ushort[][] ConnectedComponents()
        //{
        //    throw new NotImplementedException();
        //}
        
        ///// <summary>
        ///// Функция нахожденя локальных степеней вершин графа.
        ///// </summary>
        ///// <returns>Массив с локальными степениями для каждой вершины графа.</returns>
        //public ushort[] VerticesDegree()
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Функция нахождения объединения двух графов.
        ///// </summary>
        ///// <param name="g1"></param>
        ///// <param name="g2"></param>
        ///// <returns>Результат объединения двух графов.</returns>
        //public static Graph<N> Union(Graph<N> g1, Graph<N> g2)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Функция нахождения пересечения двух графов.
        ///// </summary>
        ///// <param name="g1"></param>
        ///// <param name="g2"></param>
        ///// <returns>Результат пересечения двух графов.</returns>
        //public static Graph<N> Intersection(Graph<N> g1, Graph<N> g2)
        //{
        //    throw new NotImplementedException();
        //}

        ///// <summary>
        ///// Функция нахождения композиции двух графов g1(g2).
        ///// </summary>
        ///// <param name="g1"></param>
        ///// <param name="g2"></param>
        ///// <returns>Результат композиции двух графов.</returns>
        //public static Graph<N> LexicographicalProduct(Graph<N> g1, Graph<N> g2)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
    }
}
