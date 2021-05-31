using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLib
{
    /// <summary>
    /// Структура для хранения числовой информации о паре вершин.
    /// </summary>
    internal struct NodePair
    {
        /// <summary>
        /// Номер первой вершины.
        /// </summary>
        public ushort Node1 { get; private set; }

        /// <summary>
        /// Номер второй вершины.
        /// </summary>
        public ushort Node2 { get; private set; }

        /// <summary>
        /// Номер ребра, связывающего вершины.
        /// </summary>
        public ushort Edge { get; private set; }

        /// <summary>
        /// Числовая величина, соответствующая этой паре вершин.
        /// </summary>
        public float Value { get; private set; }

        internal NodePair(ushort node1, ushort node2, ushort edge, float value)
        {
            this.Node1 = node1;
            this.Node2 = node2;
            this.Edge = edge;
            this.Value = value;
        }

        /// <summary>
        /// Имеют ли указанные пары общие вершины.
        /// </summary>
        /// <param name="pair1">Первая пара вершин.</param>
        /// <param name="pair2">Вторая пара вершин.</param>
        /// <returns>Имеют ли указанные пары общие вершины.</returns>
        internal static bool MatchedPair(NodePair pair1, NodePair pair2)
        {
            return pair1.Node1 == pair2.Node1 ||
            pair1.Node2 == pair2.Node2 ||
            pair1.Node1 == pair2.Node2 ||
            pair1.Node2 == pair2.Node1;
        }

        /// <summary>
        /// Может ли пара ориентированных ребер образовать дерево.
        /// </summary>
        /// <param name="pair1">Первая пара вершин.</param>
        /// <param name="pair2">Вторая пара вершин.</param>
        /// <returns>Имеют ли указанные пары общие вершины.</returns>
        internal static bool MatchedDirectedPair(NodePair pair1, NodePair pair2)
        {
            return pair1.Node2 == pair2.Node1 ||
            pair2.Node2 == pair1.Node1 ||
            pair2.Node1 == pair1.Node1;
        }

        /// <summary>
        /// Может ли пара неориентированных ребер образовать дерево.
        /// </summary>
        /// <param name="pair1">Первая пара вершин.</param>
        /// <param name="pair2">Вторая пара вершин.</param>
        /// <returns>Имеют ли указанные пары общие вершины.</returns>
        internal static bool MatchedUndirectedPair(NodePair pair1, NodePair pair2) =>
            MatchedPair(pair1, pair2);

        public override string ToString()
        {
            return $"edge={Edge}; node1={Node1}; node2={Node2}; value={Value}";
        }
    }
}
