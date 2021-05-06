using GraphControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormTest
{
    public enum GraphInteractionMode : byte
    {
        AddingNode,
        MovingNode,
        AddingEdge,
        Removing,
        Selecting,
        ApplyAlgoritm,
    }

    public enum ApplyAlgorithm
    {
        None,
        FindEvenNodes,
        MinimumSpanningTree,
        FindLoops,
        ShortestPath,
    }

    public partial class Form_main : Form
    {
        GraphInteractionMode graphMode = GraphInteractionMode.AddingNode;
        ApplyAlgorithm applyAlgorithm = ApplyAlgorithm.None;

        public Form_main()
        {
            InitializeComponent();
        }

        private void graphControl1_MouseDown(object sender, MouseEventArgs e)
        {
            GraphControl.GraphControl control = (sender as GraphControl.GraphControl);
            tsslbl_log.Text = $"Всего вершин {control.NodeCount}, ребер {control.EdgeCount}; "
                + $"Выделено вершин {control.SelectionNodeCount}, ребер {control.SelectionEdgeCount}";
            try
            {
                if (e.Button == MouseButtons.Left)
                    switch (graphMode)
                    {
                        case GraphInteractionMode.Selecting:
                            control.Selection(e.Location, !ModifierKeys.HasFlag(Keys.Control));
                            break;
                        case GraphInteractionMode.AddingEdge:
                            {
                                if (control.SelectionEdgeCount != 0) control.ClearSelection();
                                if (control.SelectionNodeCount == 0)
                                    control.NodeSelection(e.Location, false);
                                else if (control.SelectionNodeCount == 1)
                                {
                                    control.NodeSelection(e.Location, false);
                                    control.AddEdge(cb_directedEdge.Checked, cb_weightedEdge.Checked, (float)numeric_weight.Value);
                                }
                                break;
                            }
                        case GraphInteractionMode.AddingNode:
                            control.AddNode(e.Location);
                            break;
                        case GraphInteractionMode.ApplyAlgoritm:
                            switch (applyAlgorithm)
                            {
                                case ApplyAlgorithm.None:
                                case ApplyAlgorithm.FindEvenNodes:
                                case ApplyAlgorithm.MinimumSpanningTree:
                                case ApplyAlgorithm.FindLoops:
                                    break;
                                case ApplyAlgorithm.ShortestPath:
                                    {
                                        if (control.SelectionEdgeCount != 0) control.ClearEdgeSelection();
                                        if (control.SelectionNodeCount == 0)
                                            control.NodeSelection(e.Location, false);
                                        else if (control.SelectionNodeCount == 1)
                                        {
                                            control.NodeSelection(e.Location, false);
                                            label_comment.Text = control.ShortestPath();
                                        }
                                        break;
                                    }
                                default:
                                    throw new NotImplementedException();
                            }
                            break;
                        case GraphInteractionMode.MovingNode:
                            {
                                if (control.SelectionEdgeCount != 0) control.ClearEdgeSelection();
                                if (control.SelectionNodeCount == 0)
                                    control.NodeSelection(e.Location, true);
                                else if (control.SelectionNodeCount == 1)
                                    control.MoveSelectedNode(e.Location);
                            }
                            break;
                        case GraphInteractionMode.Removing:
                            control.RemoveGraphElement(e.Location);
                            break;
                    }
                tsslbl_log.Text = $"Всего вершин {control.NodeCount}, ребер {control.EdgeCount}; "
                    + $"Выделено вершин {control.SelectionNodeCount}, ребер {control.SelectionEdgeCount}";
            }
            catch (InvalidOperationException ex)
            {
                tsslbl_log.Text = $"Всего вершин {control.NodeCount}, ребер {control.EdgeCount}; "
                    + $"Выделено вершин {control.SelectionNodeCount}, ребер {control.SelectionEdgeCount}";
                label_comment.Text = ex.Message;
                control.ClearSelection();
            }
            catch (ArgumentException ex)
            {
                tsslbl_log.Text = $"Всего вершин {control.NodeCount}, ребер {control.EdgeCount}; "
                    + $"Выделено вершин {control.SelectionNodeCount}, ребер {control.SelectionEdgeCount}";
                label_comment.Text = ex.Message;
                control.ClearSelection();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tsslbl_mode.Text = "Текущий режим: добавление вершины";

            cb_algoritms.Items.Add("Поиск минимального оставного дерева");
            cb_algoritms.Items.Add("Поиск кратчайшего пути");
            cb_algoritms.SelectedIndex = 0;
            cb_algoritms.Items.Add("Поиск вершин с четными номерами");
            cb_algoritms.Items.Add("Поиск цикла");
        }

        private void testUserControl1_MouseMove(object sender, MouseEventArgs e)
        {
            tsslbl_pos.Text = $"X = {e.X}, Y = {e.Y}";
        }
       
        private void btn_autoPlacing_Click(object sender, EventArgs e)
        {
            graphControl1.AutomaticNodePlacing();
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            //label_comment.Text = testUserControl1.FindEvenNodes();
            Form_matrixInput dialog = new Form_matrixInput(graphControl1);
            dialog.Owner = this;
            dialog.ShowDialog();
            dialog.Dispose();
        }

        private void btn_addNode_Click(object sender, EventArgs e)
        {
            tsslbl_mode.Text = "Режим: добавление вершины";
            graphMode = GraphInteractionMode.AddingNode;
            graphControl1.ShowElementsSelectedByProgram = false;
            label_comment.Text = "Укажите позицию для добавления вершины в граф.";
        }

        private void btn_moveNode_Click(object sender, EventArgs e)
        {
            tsslbl_mode.Text = "Режим: перемещение вершины";
            graphMode = GraphInteractionMode.MovingNode;
            graphControl1.ShowElementsSelectedByProgram = false;
            label_comment.Text = "Выделите вершину и её новую позицию.";
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            tsslbl_mode.Text = "Режим: удаление элемента";
            graphMode = GraphInteractionMode.Removing;
            graphControl1.ShowElementsSelectedByProgram = false;
            graphControl1.ClearSelection();
        }

        private void btn_addEdge_Click(object sender, EventArgs e)
        {
            tsslbl_mode.Text = "Режим: добавление ребра";
            graphMode = GraphInteractionMode.AddingEdge;
            graphControl1.ShowElementsSelectedByProgram = false;
            label_comment.Text = "Выделите начальную и конечную вершину ребра.";
        }

        private void btn_applyAlgorithm_Click(object sender, EventArgs e)
        {
            graphMode = GraphInteractionMode.ApplyAlgoritm;
            graphControl1.ShowElementsSelectedByProgram = true;
            
            tsslbl_mode.Text = "Режим: результат алгоритма.";
            switch (cb_algoritms.SelectedIndex)
            {
                case 0:
                    label_comment.Text = graphControl1.MinimumSpanningTree(); 
                    break;
                case 1:
                    graphControl1.ClearSelection();
                    graphControl1.ShowElementsSelectedByProgram = false;
                    label_comment.Text = "Выберите начальную и конечную вершину для поиска пути.";
                    applyAlgorithm = ApplyAlgorithm.ShortestPath;
                    break;
                case 2:
                    label_comment.Text = graphControl1.FindEvenNodes();
                    break;
                case 3:
                    label_comment.Text = graphControl1.FindLoops();
                    graphControl1.ShowElementsSelectedByProgram = false;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphMode = GraphInteractionMode.ApplyAlgoritm;
            graphControl1.ShowElementsSelectedByProgram = true;

            tsslbl_mode.Text = "Режим: результат алгоритма.";
            label_comment.Text = graphControl1.ShortestPath();
        }

        private void btn_selection_Click(object sender, EventArgs e)
        {
            tsslbl_mode.Text = "Режим: выделение";
            graphMode = GraphInteractionMode.Selecting;
            graphControl1.ShowElementsSelectedByProgram = false;
            label_comment.Text = "Укажите позицию выделямого элемента. Нажмите \"ctrl\" для множественного выбора.";
        }
    }
}
