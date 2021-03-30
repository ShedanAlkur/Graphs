using GraphLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GraphControl
{
    public class VisGraph : Graph<NodeData, EdgeData>
    {
        public List<Node<NodeData>> SelectedNodes = new List<Node<NodeData>>();
        public List<Edge<EdgeData>> SelectedEdges = new List<Edge<EdgeData>>();

        public bool SelectionUpdate(Vector2 point, bool monoChoise = true, bool reset = true)
        {
            Console.WriteLine("SelectionUpdate");
            if (reset)
            {
                SelectedNodes.Clear();
                SelectedEdges.Clear();
            }

            bool selectedElementWasFound = false;

            for (int i = Nodes.Count - 1; i >= 0 ; i--)
            {
                if (Nodes[i].Data.Collision(point))
                {
                    selectedElementWasFound = true;
                    if (reset || !SelectedNodes.Contains(Nodes[i]))
                        SelectedNodes.Add(Nodes[i]);
                    if (monoChoise) return true;
                }
            }
            foreach (Edge<EdgeData> edge in Edges)
                if (edge.Data.Collision(point))
                {
                    selectedElementWasFound = true;
                    if (reset || !SelectedEdges.Contains(edge))
                        SelectedEdges.Add(edge);
                    if (monoChoise) return true;
                }

            return selectedElementWasFound;
        }

        public void ClearSelection()
        {
            SelectedNodes.Clear();
            SelectedEdges.Clear();
        }

        public void AddNode(Vector2 point, int diameter)
        {
            AddNode();
            Nodes.Last().Data = new NodeData(point, diameter);
        }

        public bool AddEdge(Node node1, Node node2)
        {
            throw new NotImplementedException();
        }

    }
}
