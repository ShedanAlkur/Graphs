using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLib
{
    /// <summary>
    /// Вершина графа Graph.
    /// </summary>
    public class Node
    {
        public List<Edge> Edges = new List<Edge>();
        public List<Node> Nears = new List<Node>();
        public ushort Id;

        public Node (ushort Id)
        {
            this.Id = Id;
        }

        public void AddEdge(Edge edge)
        {
            if (!edge.Сontain(this)) throw new ArgumentException();

            Edges.Add(edge);
        }

        public void AddNear(Node node)
        {
            if (Nears.Contains(node)) return;

            Nears.Add(node);
        }
    }

    public class Node<N> : Node
    {
        public N Data { get; set; }
        public Node(ushort Id) : base(Id)
        {
            Data = default(N);
        }
    }
}
