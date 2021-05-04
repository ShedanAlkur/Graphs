using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLib
{
    /// <summary>
    /// Структура для хранения результатов выполнения специальных алгоритмов над графом.
    /// </summary>
    /// <typeparam name="N">Тип данных, хранящихся в вершинах графа.</typeparam>
    /// <typeparam name="E">Тип данных, хранящихся в ребрах графа.</typeparam>
    public struct AlgoritmResult<N, E>
    {
        /// <summary>
        /// Выполнен ли алгоритм успешно.
        /// </summary>
        public bool Success { get; private set; }

        /// <summary>
        /// Комментарий к выполненному алгоритму.
        /// </summary>
        public string Comment { get; private set; }
        
        /// <summary>
        /// Список вершин, выделенных в ходе выполнения алгоритма.
        /// </summary>
        public List<Node<N, E>> Nodes { get; private set; }

        /// <summary>
        /// Список ребер, выделенных в ходе выполнения алгоритма.
        /// </summary>
        public List<Edge<N, E>> Edges { get; private set; }

        /// <summary>
        /// Конструктор структуры для хранения результатов выполнения специальных алгоритмов над графом.
        /// </summary>
        /// <param name="success">Выполнен ли алгоритм успешно.</param>
        /// <param name="comment">Комментарий к выполненному алгоритму.</param>
        /// <param name="nodes">Список вершин, выделенных в ходе выполнения алгоритма.</param>
        /// <param name="edges">Список ребер, выделенных в ходе выполнения алгоритма.</param>
        public AlgoritmResult(bool success, string comment, List<Node<N, E>> nodes, List<Edge<N, E>> edges)
        {
            this.Success = success;
            this.Comment = comment;
            this.Nodes = nodes;
            this.Edges = edges;
        }
    }
}
