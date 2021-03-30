using GraphLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphControl
{
    [DefaultProperty("GraphNodeDiameter")]
    public partial class TestUserControl : Panel
    {
        #region --Свойства цветов графа--
        private Color graphOutlineColor = Color.DarkCyan;
        private Color graphFillColor = Color.LightYellow;
        private Color graphUserSelectionColor = Color.LightBlue;
        private Color graphProgramSelectionColor = Color.Orange;

        [Category("Внешний вид"), Description("Цвет обводки элементов графа.")
            , DefaultValue(typeof(Color), "DarkCyan")]
        public Color GraphOutlineColor
        {
            get { return graphOutlineColor; }
            set { graphOutlineColor = value; OnChangeProperties(); }
        }

        [Category("Внешний вид"), Description("Цвет заливки элементов графа.")
            , DefaultValue(typeof(Color), "LightYellow")]
        public Color GraphFillColor 
        {
            get { return graphFillColor; }
            set { graphFillColor = value; OnChangeProperties(); }
        }

        [Category("Внешний вид"), Description("Цвет заливки элементов графа при их выделении пользователем.")
            , DefaultValue(typeof(Color), "LightBlue")]
        public Color GraphUserSelectionColor
        {
            get { return graphUserSelectionColor; }
            set { graphUserSelectionColor = value; OnChangeProperties(); }
        }

        [Category("Внешний вид"), Description("Цвет заливки элементов графа при их программном выделении.")
            , DefaultValue(typeof(Color), "Orange")]
        public Color GraphProgramSelectionColor
        {
            get { return graphProgramSelectionColor; }
            set { graphProgramSelectionColor = value; OnChangeProperties(); }
        }
        #endregion

        #region --Свойства размерностей графа--
        private int graphNodeDiameter = 50;
        private int graphOutlineWidth = 2;
        int arrowLength = 20;
        double arrowAngle = 15.0 / 180 * Math.PI;
        double arrowSideLength;

        [Category("Внешний вид"), Description("Диаметр вершины графа.")
            , DefaultValue(typeof(int), "50")]
        public int GraphNodeDiameter
        {
            get { return graphNodeDiameter; }
            set { graphNodeDiameter = value; OnChangeProperties(); }
        }

        [Category("Внешний вид"), Description("Толщина обводки элементов графа.")
            , DefaultValue(typeof(int), "2")]
        public int GraphOutlineWidth
        {
            get { return graphOutlineWidth; }
            set { graphOutlineWidth = value; OnChangeProperties(); }
        }

        [Category("Внешний вид"), Description("Длина наконечника стрелки у ориентированного ребра графа.")
            , DefaultValue(typeof(int), "20")]
        public int ArrowLength
        {
            get { return arrowLength; }
            set
            {
                arrowLength = value;
                arrowSideLength = arrowLength / Math.Cos(arrowAngle); OnChangeProperties();
            }
        }

        [Category("Внешний вид"), Description("Угол в градусах между смежными с окончанием наконечника стрелки сторонами.")
            , DefaultValue(typeof(double), "30")]
        public double ArrowAngle
        {
            get { return Math.Round(arrowAngle * 180 / Math.PI * 2, 3); }
            set { arrowAngle = value / 180 * Math.PI / 2; OnChangeProperties(); }
        }
        #endregion

        private VisGraph graph = new VisGraph();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //Ellipse ell = new Ellipse(50, 50, GraphNodeDiameter, GraphNodeDiameter);
            using (StringFormat sf = new StringFormat())
            {
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                using (Pen outlinePen = new Pen(graphOutlineColor, graphOutlineWidth))
                {
                    // Рендер обычных элементов графа.
                    using (SolidBrush fillBrush = new SolidBrush(graphFillColor)
                        , userSelectionBrush = new SolidBrush(graphUserSelectionColor)
                        , textBrush = new SolidBrush(ForeColor)
                        , arrowheadBrush = new SolidBrush(graphOutlineColor))
                    {
                        foreach (Node<NodeData> node in graph.Nodes)
                        {
                            // Заливка вершин.
                            if (graph.SelectedNodes.Contains(node))
                                e.Graphics.FillEllipse(userSelectionBrush, node.Data.Ellipse);
                            else
                                e.Graphics.FillEllipse(fillBrush, node.Data.Ellipse);
                            // Обводка вершин
                            e.Graphics.DrawEllipse(outlinePen, node.Data.Ellipse);
                            // рендер номеров вершины
                            e.Graphics.DrawString(node.Id.ToString(), Font, textBrush, node.Data.Position, sf);
                        }
                        foreach (Edge<EdgeData> edge in graph.Edges)
                        {
                            e.Graphics.DrawLine(outlinePen, edge.Data.P1, edge.Data.P2);
                            if (edge.Directed) RenderArrowhead(e.Graphics, arrowheadBrush, edge.Data.P1, edge.Data.P2);
                        }

                    }
                }
            }

            using (SolidBrush arrowheadBrush = new SolidBrush(graphOutlineColor))
                RenderArrowhead(e.Graphics, arrowheadBrush, new Point(0, 0), new Point(100, 100)); // Тестовый вызов метода.
        }

        public int test_x, test_y;

        private void RenderArrowhead(Graphics e, SolidBrush fillBrush, Point arrowStart, Point arrowEnd)
        {
            double degree = Math.Atan2(arrowEnd.Y - arrowStart.Y, arrowEnd.X - arrowStart.X);

            Point[] points =
            {
                arrowEnd, // Верхняя вершина.

                new Point(arrowEnd.X - (int)(arrowSideLength * Math.Cos(degree + arrowAngle)),
                arrowEnd.Y - (int)(arrowSideLength * Math.Sin(degree + arrowAngle))), // Правая вершина.
                
                new Point(arrowEnd.X - (int)(arrowSideLength * Math.Cos(degree - arrowAngle)),
                arrowEnd.Y - (int)(arrowSideLength * Math.Sin(degree - arrowAngle))), // Левая вершина.
            };
            e.FillPolygon(fillBrush, points);
        }

        private void OnChangeProperties()
        {
            Invalidate();
        }

        public TestUserControl()
        {
            InitializeComponent();
            double arrowSideLength = arrowLength / Math.Cos(arrowAngle);
        }

        #region --Методы взаимодействия с графом--
        public bool SelectionUpdate(Point point)
        {
            if (graph.SelectionUpdate(point))
            {
                Invalidate();
                return true;
            }
            return false;

        }

        public void AddNode(Point location)
        {
            graph.AddNode(location, graphNodeDiameter);
            Invalidate();
        }

        public void RemoveSelectedElements()
        {
            foreach (Node<NodeData> node in graph.SelectedNodes)
                graph.RemoveNode(node);
            //TODO: Удаление ребра.
            Invalidate();
        }
        #endregion
    }
}
