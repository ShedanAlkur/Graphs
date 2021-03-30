using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLib
{
    /// <summary>
    /// Ребро графа Graph.
    /// </summary>
    public class Edge
    {
        Node Node1;
        Node Node2;
        public bool Directed { get; set; }
        public float Weight { get; set; }

        public Edge(Node node1, Node node2, bool directed = false, float weight = 0)
        {
            this.Node1 = node1;
            this.Node2 = node2;
            this.Directed = directed;
            this.Weight = weight;
        }

        public Node Pair(Node node)
        {
            if (Node1 == node) return Node2;
            if (Node2 == node) return Node1;
            return null;
        }
        public Node<N> Pair<N>(Node<N> node)
        {
            if (Node1 == node) return (Node<N>)Node2;
            if (Node2 == node) return (Node<N>)Node1;
            return null;
        }

        public bool Сontain(Node node) => (node == Node1 || node == Node2);
        public bool Сontain(Node node1, Node node2) => 
            (node1 == Node1 && node2 == Node2 || node1 == Node2 && node2 == Node1);
        public bool Сontain(byte id) => (id == Node1.Id || id == Node2.Id);
        public bool Сontain(byte id1, byte id2) => 
            (id1 == Node1.Id && id2 == Node2.Id || id1 == Node2.Id && id2 == Node1.Id);
    }

    public class Edge<E> : Edge
    {
        
        public E Data { get; set; }
        public Edge(Node node1, Node node2, bool directed = false, float weight = 0) 
            : base(node1, node2, directed, weight)
        {
            Data = default(E);
        }
    }
}
