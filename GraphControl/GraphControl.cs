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
    /// <summary>
    /// Компонент для визуализации графа и взаимодействия с ним.
    /// </summary>
    [DefaultProperty("GraphNodeDiameter")]
    public partial class GraphControl : UserControl
    {
        /// <summary>
        /// Создан ли экземпляр в режиме designer.
        /// </summary>
        bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);

        /// <summary>
        /// Должны ли бы быть отдельно отрендерены вершины и ребра, выделенные программно.
        /// </summary>
        public bool ShowElementsSelectedByProgram;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (designMode) // Рендер примеров вершин и ребер графа в режиме designer.
                RenderOnDesignerMode(e.Graphics);
                        
            foreach (Node<NodeData, EdgeData> node in graph.Nodes) // Рендер вершин графа.
            {
                if (!(SelectedNodesByProg is null) && ShowElementsSelectedByProgram && SelectedNodesByProg.Contains(node)) // Рендер выделенной программно вершины.
                {
                    e.Graphics.FillEllipse(programSelectionFillBrush, node.Data.FillEllipse);
                    e.Graphics.DrawEllipse(programSelectionOutlinePen, node.Data.OutlineEllipse);
                }
                else if (SelectedNodesByUser.Contains(node)) // Рендер выделенной пользователем вершины.
                {
                    e.Graphics.FillEllipse(userSelectionBrush, node.Data.FillEllipse);
                    e.Graphics.DrawEllipse(outlinePen, node.Data.OutlineEllipse);
                }
                else // Рендер вершины по умолчанию.
                {
                    e.Graphics.FillEllipse(fillBrush, node.Data.FillEllipse); 
                    e.Graphics.DrawEllipse(outlinePen, node.Data.OutlineEllipse);
                }
                e.Graphics.DrawString(node.Id.ToString(), Font, textBrush, node.Data.Middle, sf); // Рендер номера вершины.
            }
            foreach (Edge<NodeData, EdgeData> edge in graph.Edges) // Рендер ребер графа.
            {
                if (!(SelectedEdgesByProg is null) && ShowElementsSelectedByProgram && SelectedEdgesByProg.Contains(edge)) // Рендер веделенного программно ребра
                {
                    e.Graphics.DrawLine(programSelectionOutlinePen, edge.Data.P1, edge.Data.P2);
                    if (edge.Directed) RenderArrowhead(e.Graphics, programSelectionOutlineBrush, edge.Data.P1, edge.Data.P2);
                }
                else // Рендер ребра по умолчанию.
                {
                    e.Graphics.DrawLine(outlinePen, edge.Data.P1, edge.Data.P2);
                    if (edge.Directed) RenderArrowhead(e.Graphics, arrowheadBrush, edge.Data.P1, edge.Data.P2);
                }
                if (edge.Weighed) // Рендер весов у взвешенных ребер.
                {
                    Vector2 middle = edge.Data.Middle;
                    Size size = TextRenderer.MeasureText(edge.Weight.ToString(), Font);
                    e.Graphics.FillEllipse(fillBrush, new Rectangle(middle - (Vector2)size / 2, size));
                    e.Graphics.DrawString(edge.Weight.ToString(), Font, textBrush, middle, sf);
                }
            }

        }

        /// <summary>
        /// Рендер поверхности компонента в режиме designer.
        /// </summary>
        /// <param name="g">Поверхность для рисования.</param>
        private void RenderOnDesignerMode(Graphics g)
        {
            NodeData node1 = new NodeData(new Vector2(50, 50), graphNodeDiameter, graphOutlineWidth);
            NodeData node2 = new NodeData(new Vector2(150, 50), graphNodeDiameter, graphOutlineWidth);
            NodeData node3 = new NodeData(new Vector2(150, 100), graphNodeDiameter, graphOutlineWidth);
            EdgeData edge1 = new EdgeData(node1.Middle, node2.Middle, graphOutlineWidth, graphNodeDiameter / 2);
            EdgeData edge2 = new EdgeData(node2.Middle, node1.Middle, graphOutlineWidth, graphNodeDiameter / 2);
            EdgeData edge3 = new EdgeData(node1.Middle, node3.Middle, graphOutlineWidth, graphNodeDiameter / 2);

            // Ренден вершин.
            g.FillEllipse(fillBrush, node1.FillEllipse); // Обычная вершина
            g.DrawEllipse(outlinePen, node1.OutlineEllipse);
            g.DrawString("1", Font, textBrush, node1.Middle, sf);
            g.FillEllipse(programSelectionFillBrush, node2.FillEllipse); // Выделенная программно вершина
            g.DrawEllipse(programSelectionOutlinePen, node2.OutlineEllipse);
            g.DrawString("2", Font, textBrush, node2.Middle, sf);
            g.FillEllipse(userSelectionBrush, node3.FillEllipse); // Выделенная пользователем вершина
            g.DrawEllipse(outlinePen, node3.OutlineEllipse);
            g.DrawString("3", Font, textBrush, node3.Middle, sf);

            // Рендер ребер.
            g.DrawLine(outlinePen, edge1.P1, edge1.P2);
            RenderArrowhead(g, arrowheadBrush, edge1.P1, edge1.P2);
            g.DrawLine(programSelectionOutlinePen, edge2.P1, edge2.P2);
            RenderArrowhead(g, programSelectionOutlineBrush, edge2.P1, edge2.P2);
            g.DrawLine(outlinePen, edge3.P1, edge3.P2);
            RenderArrowhead(g, arrowheadBrush, edge3.P1, edge3.P2);

            // Ренденр весов ребер.
            Vector2 middle = edge3.Middle;
            float weight = 4;
            Size size = TextRenderer.MeasureText(weight.ToString(), Font);
            g.FillEllipse(fillBrush, new Rectangle(middle - (Vector2)size / 2, size));
            g.DrawString(weight.ToString(), Font, textBrush, middle, sf);
        }

        /// <summary>
        /// Рендер стрелки графа.
        /// </summary>
        /// <param name="g">Поверхность для рисования</param>
        /// <param name="fillBrush">Кисть для закрашивания стрелки.</param>
        /// <param name="arrowStart">Координата начала ребра, которое оканчивается стрелкой.</param>
        /// <param name="arrowEnd">Координата конца ребра, которое оканчивается стрелкой.</param>
        private void RenderArrowhead(Graphics g, SolidBrush fillBrush, Point arrowStart, Point arrowEnd)
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
            g.FillPolygon(fillBrush, points);
        }

        public GraphControl()
        {
            InitializeComponent();
            InitializeProperties();
        }
    }
}
