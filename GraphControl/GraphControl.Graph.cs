using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using GraphLib;

namespace GraphControl
{
    // В этой части класса описываются атрибуты и методы для взаимодействия с моделью графа.
    public partial class GraphControl
    {
        /// <summary>
        /// Список вершин, выделенных пользователем.
        /// </summary>
        private List<Node<NodeData, EdgeData>> SelectedNodesByUser = new List<Node<NodeData, EdgeData>>();

        /// <summary>
        /// Список ребер, выделенных пользователем.
        /// </summary>
        private List<Edge<NodeData, EdgeData>> SelectedEdgesByUser = new List<Edge<NodeData, EdgeData>>();

        /// <summary>
        /// Список вершин, выделенных программно.
        /// </summary>
        private List<Node<NodeData, EdgeData>> SelectedNodesByProg = new List<Node<NodeData, EdgeData>>();

        /// <summary>
        /// Список ребер, выделенных программно.
        /// </summary>
        private List<Edge<NodeData, EdgeData>> SelectedEdgesByProg = new List<Edge<NodeData, EdgeData>>();

        /// <summary>
        /// Количество вершин в графе.
        /// </summary>
        public int NodeCount { get => graph.Nodes.Count; }

        /// <summary>
        /// Количество ребер в графе.
        /// </summary>
        public int EdgeCount { get => graph.Edges.Count; }

        /// <summary>
        /// Количество выделенных пользователем вершин.
        /// </summary>
        public int SelectionNodeCount { get => SelectedNodesByUser.Count; }

        /// <summary>
        /// Количество выделенных пользователем ребер.
        /// </summary>
        public int SelectionEdgeCount { get => SelectedEdgesByUser.Count; }
        
        /// <summary>
        /// Количество выделенных пользователем элементов графа.
        /// </summary>
        public int SelectionCount { get => SelectionNodeCount + SelectionEdgeCount; }

        /// <summary>
        /// Модель графа.
        /// </summary>
        private Graph<NodeData, EdgeData> graph = new Graph<NodeData, EdgeData>();

        #region --Методы взаимодействия с графом--

        #region -Добавление-

        /// <summary>
        /// Добавляет в граф вершину по заданным координатам. 
        /// </summary>
        /// <param name="position">Координаты добавляемой вершины.</param>
        public void AddNode(Point position)
        {
            Node<NodeData, EdgeData> newNode = graph.AddNode();
            newNode.Data = new NodeData(position, GraphNodeDiameter, GraphOutlineWidth);
            Invalidate();
        }

        /// <summary>
        /// Добавляет в граф ребро, связывающее две вершины из списка SelectedNodesByUser.
        /// </summary>
        /// <param name="directed">Ориентированно ли ребро.</param>
        /// <param name="weighed">Взвешенно ли ребро.</param>
        /// <param name="weight">Вес ребра.</param>
        public void AddEdge(bool directed, bool weighed, float weight)
        {
            if (SelectedNodesByUser.Count != 2 || SelectedEdgesByUser.Count != 0)
                throw new InvalidOperationException("Для создания ребра в графе должны быть выделены только две вершины.");

            var node1 = SelectedNodesByUser[0];
            var node2 = SelectedNodesByUser[1];
            Edge<NodeData, EdgeData> newEdge;
            if (weighed) newEdge = graph.AddEdge(node1, node2, directed, weight);
            else newEdge = graph.AddEdge(node1, node2, directed);
            newEdge.Data = new EdgeData(node1.Data.Middle, node2.Data.Middle, GraphOutlineWidth, GraphNodeDiameter / 2);

            ClearSelection();
            Invalidate();
        }

        #endregion

        #region -Удаление-

        /// <summary>
        /// Удаляет из графа все выделенные пользователем вершины и ребра.
        /// </summary>
        public void RemoveSelectedElements()
        {
            foreach (Node<NodeData, EdgeData> node in SelectedNodesByUser)
                graph.RemoveNode(node);
            foreach (Edge<NodeData, EdgeData> edge in SelectedEdgesByUser)
                graph.RemoveEdge(edge);
            Invalidate();
        }

        /// <summary>
        /// Удаляет из графа элемент по заданным координатам.
        /// </summary>
        /// <param name="position">Координаты элемента для удаления.</param>
        public void RemoveGraphElement(Vector2 position)
        {
            for (int i = graph.Nodes.Count - 1; i >= 0; i--)
                if (graph.Nodes[i].Data.Collision(position))
                {
                    graph.RemoveNode(graph.Nodes[i]);
                    Invalidate();
                    return;
                }
            for (int i = graph.Edges.Count - 1; i >= 0; i--)
                if (graph.Edges[i].Data.Collision(position))
                {
                    graph.RemoveEdge(graph.Edges[i]);
                    Invalidate();
                    return;
                }
        }

        #endregion

        #region -Выделение-    

        /// <summary>
        /// Добавляет вершину по заданным координатам в список выделенных пользователем вершин.
        /// </summary>
        /// <param name="point">Координаты выделяемой вершины.</param>
        /// <param name="reset">Необходимо ли сначала сбросить выделение.</param>
        public void NodeSelection(Vector2 point, bool reset)
        {
            bool needToRedraw = false;
            if (reset)
            {
                if (SelectionNodeCount > 0) needToRedraw = true;
                ClearNodeSelection();
            }

            for (int i = graph.Nodes.Count - 1; i >= 0; i--)
                if (graph.Nodes[i].Data.Collision(point))
                {
                    needToRedraw = true;
                    if (reset)
                        SelectedNodesByUser.Add(graph.Nodes[i]);
                    else if (SelectedNodesByUser.Contains(graph.Nodes[i]))
                        SelectedNodesByUser.Remove(graph.Nodes[i]);
                    else
                        SelectedNodesByUser.Add(graph.Nodes[i]);
                    break;
                }

            if (needToRedraw) Invalidate();
        }

        /// <summary>
        /// Добавляет ребро по заданным координатам в список выделенных пользователем ребер.
        /// </summary>
        /// <param name="point">Координаты выделяемого ребра.</param>
        /// <param name="reset">Необходимо ли сначала сбросить выделение.</param>
        public void EdgeSelection(Vector2 point, bool reset)
        {
            bool needToRedraw = false;
            if (reset)
            {
                if (SelectionEdgeCount > 0) needToRedraw = true;
                ClearEdgeSelection();
            }

            for (int i = graph.Edges.Count - 1; i >= 0; i--)
                if (graph.Edges[i].Data.Collision(point))
                {
                    needToRedraw = true;

                    if (reset)
                        SelectedEdgesByUser.Add(graph.Edges[i]);
                    else if (SelectedEdgesByUser.Contains(graph.Edges[i]))
                        SelectedEdgesByUser.Remove(graph.Edges[i]);
                    else
                        SelectedEdgesByUser.Add(graph.Edges[i]);
                    break;
                }

            if (needToRedraw) Invalidate();
        }

        /// <summary>
        /// Добавляет элемент графа по заданным координатам в список выделенных пользователем вершин и ребер.
        /// </summary>
        /// <param name="point">Координаты выделяемого элемента.</param>
        /// <param name="reset">Необходимо ли сначала сбросить выделение.</param>
        public void Selection(Vector2 point, bool reset)
        {
            bool selectedElementWasFound = false;
            bool needToRedraw = false;
            if (reset)
            {
                if (SelectionCount > 0) needToRedraw = true;
                ClearSelection();
            }

            for (int i = graph.Nodes.Count - 1; i >= 0; i--)
                if (graph.Nodes[i].Data.Collision(point))
                {
                    selectedElementWasFound = true;
                    needToRedraw = true;
                    if (reset)
                        SelectedNodesByUser.Add(graph.Nodes[i]);
                    else if (SelectedNodesByUser.Contains(graph.Nodes[i]))
                        SelectedNodesByUser.Remove(graph.Nodes[i]);
                    else
                        SelectedNodesByUser.Add(graph.Nodes[i]);
                    break;
                }

            if (!selectedElementWasFound)
                for (int i = graph.Edges.Count - 1; i >= 0; i--)
                    if (graph.Edges[i].Data.Collision(point))
                    {
                        selectedElementWasFound = true;
                        needToRedraw = true;

                        if (reset)
                            SelectedEdgesByUser.Add(graph.Edges[i]);
                        else if (SelectedEdgesByUser.Contains(graph.Edges[i]))
                            SelectedEdgesByUser.Remove(graph.Edges[i]);
                        else
                            SelectedEdgesByUser.Add(graph.Edges[i]);
                        break;
                    }

            if (needToRedraw) Invalidate();
        }

        /// <summary>
        /// Сбросить пользовательское выделение элементов графа.
        /// </summary>
        public void ClearSelection()
        {
            SelectedNodesByUser.Clear();
            SelectedEdgesByUser.Clear();
        }

        /// <summary>
        /// Сбпросить пользовательское выделение вершин графа.
        /// </summary>
        public void ClearNodeSelection() => SelectedNodesByUser.Clear();

        /// <summary>
        /// Сбросить пользовательское выделение ребер графа.
        /// </summary>
        public void ClearEdgeSelection() => SelectedEdgesByUser.Clear();

        #endregion

        #region -Перемещение-

        /// <summary>
        /// Переместить выделенную пользователем в списке SelectedNodesByUser вершину по заданным координатам.
        /// </summary>
        /// <param name="newPosition">Конечные координаты центра перемещаемой вершины.</param>
        public void MoveSelectedNode(Vector2 newPosition)
        {
            if (SelectedNodesByUser.Count != 1 && SelectedEdgesByUser.Count != 0)
                throw new InvalidOperationException("Для перемещения вершины в графе должна быть выделена только одна вершина");

            SelectedNodesByUser[0].Data.Middle = newPosition;
            ClearNodeSelection();
            UpdateEdgePlacing();
            Invalidate();
        }

        /// <summary>
        /// Выполнисть автоматическое размещение элементов графа.
        /// </summary>
        public void AutomaticNodePlacing()
        {
            AutomaticNodePlacing(new Vector2(this.Width / 2, this.Height / 2),
                (int)(Math.Min(this.Width, this.Height) / 2) - GraphNodeDiameter / 2);
            Invalidate();
        }

        /// <summary>
        /// Выполнить автоматическое размещение элементов графа по окружности с заданным центром и радиуом.
        /// </summary>
        /// <param name="middle">Координаты центра окружности для размещение вершин.</param>
        /// <param name="radius">Радиус окружности для размещения вершин.</param>
        public void AutomaticNodePlacing(Vector2 middle, int radius)
        {
            for (ushort i = 0; i < graph.Nodes.Count(); i++)
                graph.Nodes[i].Data.Middle = middle + Vector2.CreateByAngle(radius, Math.PI * 2.0 / graph.Nodes.Count() * i + Math.PI);

            UpdateEdgePlacing();
        }

        /// <summary>
        /// Выполнить автоматическое размещение ребер графа в соотвествии с положением вершин.
        /// </summary>
        private void UpdateEdgePlacing()
        {
            foreach (var edge in graph.Edges)
                edge.Data.SetPosition(edge.Node1.Data.Middle, edge.Node2.Data.Middle);
        }

        #endregion

        #region -Создание-
        /// <summary>
        /// Установить граф, созданный по матрице смежности вершин.
        /// </summary>
        /// <param name="matrix">Квадратная матрица смежности вершин.</param>
        /// <param name="directed">Ориентирован ли граф.</param>
        /// <param name="weighted">Взвешен ли граф.</param>
        public void CreateByAdjacencyMatrix(float[,] matrix, bool directed, bool weighted)
        {
            graph = Graph<NodeData, EdgeData>.CreateByAdjacencyMatrix<NodeData, EdgeData>(matrix, directed, weighted);
            foreach (var n in graph.Nodes)
                n.Data = new NodeData(new Vector2(0, 0), GraphNodeDiameter, GraphOutlineWidth);
            foreach (var e in graph.Edges)
                e.Data = new EdgeData(new Vector2(0, 0), new Vector2(0, 0), GraphOutlineWidth, GraphNodeDiameter / 2);
            AutomaticNodePlacing();
        }
        #endregion

        #endregion

        /// <summary>
        /// Выполняет программный поиск вершин с четными id номерами.
        /// </summary>
        /// <returns>Комментарий по выполнению алгоритма.</returns>
        public string FindEvenNodes()
        {
            AlgoritmResult<NodeData, EdgeData> algoritmResult = graph.FindEvenNodes();
            SelectedNodesByProg = algoritmResult.Nodes;
            SelectedEdgesByProg = algoritmResult.Edges;

            ShowElementsSelectedByProgram = true;
            Invalidate();
            return algoritmResult.Comment;
        }

        /// <summary>
        /// Выполняет поиск минимального оставного дерева в графе.
        /// </summary>
        /// <returns>Комментарий по выполнению алгоритма.</returns>
        public string MinimumSpanningTree()
        {
            AlgoritmResult<NodeData, EdgeData> algoritmResult = graph.MinimumSpanningTree();
            SelectedNodesByProg = algoritmResult.Nodes;
            SelectedEdgesByProg = algoritmResult.Edges;

            ShowElementsSelectedByProgram = true;
            Invalidate();
            return algoritmResult.Comment;
        }

        /// <summary>
        /// Выполняет поиск циклов в графе.
        /// </summary>
        /// <returns>True - если циклы в графе есть, иначе - false.</returns>
        public string FindLoops()
        {
            return (graph.ContainsLoop()) ? "Граф содержит циклы." : "Граф не содержит циклов.";
        }
    }
}
