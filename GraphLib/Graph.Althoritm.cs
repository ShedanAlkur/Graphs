using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLib
{
    // В этой части класса описываются все алгоритмы обработки математического графа.
    public partial class Graph<N, E>
    {

        /// <summary>
        /// Содержит ли граф петли.
        /// Если граф содержит и ориентированные, и неориентированные ребра, вызывает исключение InvalidOperationException.
        /// </summary>
        public bool ContainsLoop()
        {
            bool[] used;
            bool directed = Directed;
            if (!directed && !Undirected)
                throw new InvalidOperationException("Граф должен быть строго ориентирован или не ориентирован.");

            foreach (var node in nodes)
            {
                used = new bool[nodes.Count];
                if (ContainsLoop(node, node, directed, ref used)) return true;
            }
            return false;
        }

        /// <summary>
        /// Итеративный метод поиска в ширину для нахождения цикла. Используется строго в ContainsLoop().
        /// </summary>
        /// <param name="current">Текущая вершина, для которой осуществляется поиск.</param>
        /// <param name="parent">Родительская вершина, из которой был вызван поиск в этой вершине.</param>
        /// <param name="directed">Ориентирован ли граф.</param>
        /// <returns>Содержит ли граф цикл.</returns>
        private bool ContainsLoop(Node<N, E> current, Node<N, E> parent, bool directed, ref bool[] used)
        {
            used[nodes.IndexOf(current)] = true;

            foreach (var near in current.nears)
            {
                //todo: можно упростить в объеме, но будет тяжелее читаться.
                if (!directed)
                {
                    if (!used[nodes.IndexOf(near)])
                    { if (ContainsLoop(near, current, directed, ref used)) return true; }
                    else if (parent.Id != near.Id) return true;

                }
                else if (current.edges.Exists(x => x.Сontain(current, near)))
                {
                    if (!used[nodes.IndexOf(near)])
                    { if (ContainsLoop(near, current, directed, ref used)) return true; }
                    else return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Является ли граф деревом
        /// Если граф содержит и ориентированные, и неориентированные ребра, вызывает исключение InvalidOperationException.
        /// </summary>
        /// <returns>Является ли граф деревом.</returns>
        public bool IsTree()
        {
            bool directed = Directed;
            if (!directed && !Undirected)
                throw new InvalidOperationException("Граф должен быть строго ориентирован или не ориентирован.");

            if (nodes.Count - 1 == edges.Count)
            { if (!directed) return true; }
            else return false;

            // if directed
            bool rootIsFound = false;
            foreach (var node in nodes)
            {
                ushort negativeDeg;
                node.Degree(out negativeDeg, out _);
                if (negativeDeg == 0)
                    if (rootIsFound) return false;
                    else rootIsFound = true;
                else if (negativeDeg != 1) return false;
            }
            return true;
        }

        /// <summary>
        /// Алгоритм нахождения всех вершин графа с четными id.
        /// </summary>
        /// <returns>Результат выполнения алгоритма.</returns>
        public AlgoritmResult<N, E> FindEvenNodes()
        {
            List<Node<N, E>> resNodes = this.nodes.Where(x => (x.Id % 2 == 0)).ToList();
            foreach (Node<N, E> node in this.nodes)
                if (node.Id % 2 == 0) resNodes.Add(node);
            return new AlgoritmResult<N, E>(true, "Найденные четные вершины", resNodes, null);
        }

        /// <summary>
        /// Алгоритм нахождения минимального остовного дерева.
        /// </summary>
        /// <returns>Результат выполнения алгоритма.</returns>
        public AlgoritmResult<N, E> MinimumSpanningTree()
        {

            if (Unweighted)
                return new AlgoritmResult<N, E>(false, "Невозможно применить алгоритм - в графе все ребра должны быть взвешены.", null, null);

            bool directed = Directed;
            if (!(directed && Undirected))
            {
                // Создаем список nodePairs исходного графа и сортируем его в порядке увеличения веса ребер.
                List<NodePair> nodePairs = new List<NodePair>();
                for (ushort i = 0; i < edges.Count; i++)
                    nodePairs.Add(new NodePair(
                        (ushort)nodes.IndexOf(edges[i].Node1), (ushort)nodes.IndexOf(edges[i].Node2), i, edges[i].Weight));
                nodePairs = nodePairs.OrderBy(p => p.Value).ToList();

                List<NodePair> result = new List<NodePair>();
                result.Add(nodePairs[0]);
                nodePairs.RemoveAt(0);

                // Создаем тестовый граф, по изменению которого будет осуществлятся поиск.
                Graph<ushort, ushort> testGraph = new Graph<ushort, ushort>();
                testGraph.AddNode(result.Last().Node1);
                testGraph.AddNode(result.Last().Node2);
                testGraph.AddEdge(result.Last().Node1, result.Last().Node2, directed);

                // Пока имеем не дерево.
                while (result.Count < nodes.Count - 1)
                {
                    bool pairFound = false;
                    for (int i = 0; i < nodePairs.Count; i++)
                    {
                        if (pairFound) break;
                        for (int j = 0; j < result.Count; j++)
                        {
                            if (pairFound) break;
                            if (NodePair.MatchedPair(nodePairs[i], result[j]))
                            {
                                // Добавляем в тестовый граф рассматриваемое ребро.
                                testGraph.AddNode(nodePairs[i].Node1);
                                testGraph.AddNode(nodePairs[i].Node2);
                                testGraph.AddEdge(nodePairs[i].Node1, nodePairs[i].Node2, directed);

                                // Если добавленное ребро не нарушает формирование дерева, добавляем его. Иначе удаляем из тестового графа.
                                if (testGraph.IsTree() && (!directed || directed && !testGraph.ContainsLoop()))
                                {
                                    result.Add(nodePairs[i]);
                                    nodePairs.RemoveAt(i);
                                    pairFound = true;
                                    break;
                                }
                                else testGraph.RemoveEdge(testGraph.edges.Last());
                            }
                        }
                    }
                    if (pairFound) continue;

                    // Если не удалось добавить в тестовый граф ни одно ребро и дерево еще не сформировано.
                    return new AlgoritmResult<N, E>(false, "В графе не существует оставное дерево.", null, null);
                }

                List<Node<N, E>> resultNodes = new List<Node<N, E>>();
                List<Edge<N, E>> resultEdges = new List<Edge<N, E>>();
                foreach (NodePair pair in result)
                {
                    if (!resultNodes.Contains(edges[pair.Edge].Node1))
                        resultNodes.Add(edges[pair.Edge].Node1);
                    if (!resultNodes.Contains(edges[pair.Edge].Node2))
                        resultNodes.Add(edges[pair.Edge].Node2);
                    resultEdges.Add(edges[pair.Edge]);
                }
                return new AlgoritmResult<N, E>(true,
                    "Построено минимальное " + 
                    ((directed) ? "ориентированное" : "неориентированное" + " оставное дерево длиной ") + 
                    result.Sum(p => p.Value) + ".", resultNodes, resultEdges);

            }
            else
                return new AlgoritmResult<N, E>(false, "Невозможно применить алгоритм - в графе содержатся и ориентированные, и неориентированные ребра.", null, null);
        }

        /// <summary>
        /// Выполняет поиск кратчайшего пути по алгоритму Дейкстры.
        /// </summary>
        /// <param name="start">Начальная вершина пути.</param>
        /// <param name="end">Конечная вершина пути.</param>
        /// <returns>Результат выполнения алгоритма.</returns>
        public AlgoritmResult<N, E> ShortestPath(Node<N, E> start, Node<N, E> end)
        {
            if (!nodes.Contains(start) || !nodes.Contains(end))
                throw new ArgumentException("Граф не содержит указанные вершины-параметры");

            if (Unweighted)
                return new AlgoritmResult<N, E>(false, "Невозможно применить алгоритм - в графе все ребра должны быть взвешены.", null, null);

            bool directed = Directed;
            if (!directed && !Undirected)
                throw new InvalidOperationException("Граф должен быть строго ориентирован или не ориентирован.");

            bool[] used = new bool[nodes.Count];
            float[] path = new float[nodes.Count];
            for (int i = 0; i < path.Length; i++) path[i] = float.PositiveInfinity;
            int indexOfStart = nodes.IndexOf(start);
            int indexOfEnd = nodes.IndexOf(end);

            path[indexOfStart] = 0;
            int currentIndex;
            // Обход с нахождением кратчайших путей
            while (used.Contains(false))
            {
                currentIndex = -1;
                float minPath = float.PositiveInfinity;
                for (int i = 0; i < path.Length; i++)
                    if (!used[i] && path[i] < minPath)
                    {
                        currentIndex = i;
                        minPath = path[i];
                    }
                if (currentIndex == -1) break;

                foreach (var edge in nodes[currentIndex].edges)
                {
                    if (directed && edge.Node1 != nodes[currentIndex]) continue; // Если ребро входящее

                    int nearIndex = nodes.IndexOf(edge.Pair(nodes[currentIndex]));
                    if (used[nearIndex]) continue;

                    if (path[currentIndex] + edge.Weight < path[nearIndex])
                        path[nearIndex] = path[currentIndex] + edge.Weight;
                }
                used[currentIndex] = true;
            }
            if (path[indexOfEnd] == float.PositiveInfinity)
                return new AlgoritmResult<N, E>(false, $"Не существует кратчайшего пути из вершины {nodes[indexOfStart].Id} в {nodes[indexOfEnd].Id}", null, null);

            // Восстановление пути по длинам
            List<Node<N, E>> resultNodes = new List<Node<N, E>>();
            List<Edge<N, E>> resultEdges = new List<Edge<N, E>>();
            resultNodes.Add(nodes[indexOfEnd]);
            currentIndex = indexOfEnd;
            while (currentIndex != indexOfStart)
                foreach (var edge in nodes[currentIndex].edges)
                {
                    if (directed && edge.Node1 == nodes[currentIndex]) continue; // Если ребро выходящее

                    int nearIndex = nodes.IndexOf(edge.Pair(nodes[currentIndex]));
                    if (path[currentIndex] - edge.Weight == path[nearIndex])
                    {
                        resultEdges.Add(edge);
                        resultNodes.Add(nodes[nearIndex]);
                        currentIndex = nearIndex;
                        break;
                    }
                }
            string comment = $"Кратчайший путь длиной {path[indexOfEnd]}. ";
            comment += resultNodes[resultNodes.Count - 1].Id;
            for (int i = resultNodes.Count - 2; i >= 0; i--)
                comment += "→" + nodes[i].Id;
            comment += ".";
            return new AlgoritmResult<N, E>(true, comment, resultNodes, resultEdges);
        }
    }
}
