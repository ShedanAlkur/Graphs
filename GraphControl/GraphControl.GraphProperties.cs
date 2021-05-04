using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using GraphLib;

namespace GraphControl
{
    // В этой части класса описываются атрибуты и методы, отвечающие за рендер элементов графа.
    public partial class GraphControl
    {

        #region --Свойства цветов графа--
        private Color graphDefaultOutlineClr = Color.DarkCyan;
        private Color graphDefaultNodeClr = Color.LightYellow;
        private Color graphUserNodeClr = Color.LightBlue;
        private Color graphProgramNodeClr = Color.Orange;
        private Color graphProgramOutlineClr = Color.DarkOrange;

        StringFormat sf;

        Pen outlinePen, programSelectionOutlinePen;
        SolidBrush fillBrush, userSelectionBrush,
            textBrush, arrowheadBrush, programSelectionFillBrush, programSelectionOutlineBrush;

        [Category("Внешний вид"), Description("Цвет обводки контуров и стрелок графа (обычных и выделенных пользователем).")
            , DefaultValue(typeof(Color), "DarkCyan")]
        public Color GraphDefaultOutlineClr
        {
            get { return graphDefaultOutlineClr; }
            set { 
                graphDefaultOutlineClr = value;
                arrowheadBrush = new SolidBrush(graphDefaultOutlineClr);
                outlinePen = new Pen(graphDefaultOutlineClr, graphOutlineWidth);
                Invalidate();
            }
        }

        [Category("Внешний вид"), Description("Цвет заливки вершин графа (обычных).")
            , DefaultValue(typeof(Color), "LightYellow")]
        public Color GraphDefaultNodeClr
        {
            get { return graphDefaultNodeClr; }
            set { 
                graphDefaultNodeClr = value;
                fillBrush = new SolidBrush(graphDefaultNodeClr);
                Invalidate(); 
            }
        }

        [Category("Внешний вид"), Description("Цвет заливки вершин графа (выделенных пользователем).")
            , DefaultValue(typeof(Color), "LightBlue")]
        public Color GraphUserNodeClr
        {
            get { return graphUserNodeClr; }
            set {
                graphUserNodeClr = value;
                userSelectionBrush = new SolidBrush(graphUserNodeClr);
                Invalidate(); 
            }
        }

        [Category("Внешний вид"), Description("Цвет заливки вершин графа (выделенных программой).")
            , DefaultValue(typeof(Color), "Orange")]
        public Color GraphProgramNodeClr
        {
            get { return graphProgramNodeClr; }
            set { 
                graphProgramNodeClr = value;
                programSelectionFillBrush = new SolidBrush(graphProgramNodeClr);
                Invalidate();
            }
        }

        [Category("Внешний вид"), Description("Цвет обводки контуров и стрелок (выделенных программой).")
            , DefaultValue(typeof(Color), "DarkOrange")]
        public Color GraphProgramOutlineClr
        {
            get { return graphProgramOutlineClr; }
            set {
                graphProgramOutlineClr = value;

                programSelectionOutlineBrush = new SolidBrush(graphProgramOutlineClr);
                programSelectionOutlinePen = new Pen(graphProgramOutlineClr, graphOutlineWidth);
                Invalidate(); 
            }
        }
        #endregion

        #region --Свойства размерностей графа--
        private int graphNodeDiameter = 40;
        private int graphOutlineWidth = 2;
        int arrowLength = 15;
        double arrowAngle = 15.0 / 180 * Math.PI;
        double arrowSideLength;

        [Category("Внешний вид"), Description("Диаметр вершины графа.")
            , DefaultValue(typeof(int), "40")]
        public int GraphNodeDiameter
        {
            get { return graphNodeDiameter; }
            set { graphNodeDiameter = value; Invalidate(); }
        }

        [Category("Внешний вид"), Description("Толщина обводки элементов графа.")
            , DefaultValue(typeof(int), "2")]
        public int GraphOutlineWidth
        {
            get { return graphOutlineWidth; }
            set { graphOutlineWidth = value; Invalidate(); }
        }

        [Category("Внешний вид"), Description("Длина наконечника стрелки у ориентированного ребра графа.")
            , DefaultValue(typeof(int), "15")]
        public int ArrowLength
        {
            get { return arrowLength; }
            set
            {
                arrowLength = value;
                arrowSideLength = arrowLength / Math.Cos(arrowAngle); Invalidate();
            }
        }

        [Category("Внешний вид"), Description("Угол в градусах между смежными с окончанием наконечника стрелки сторонами.")
            , DefaultValue(typeof(double), "30")]
        public double ArrowAngle
        {
            get { return Math.Round(arrowAngle * 180 / Math.PI * 2, 3); }
            set { arrowAngle = value / 180 * Math.PI / 2; Invalidate(); }
        }
        #endregion

        private void OnChangeProperties()
        {
            InitializeProperties();
            Invalidate();
        }

        private void InitializeProperties()
        {
            arrowSideLength = arrowLength / Math.Cos(arrowAngle);
            textBrush = new SolidBrush(ForeColor);

            fillBrush = new SolidBrush(graphDefaultNodeClr);
            arrowheadBrush = new SolidBrush(graphDefaultOutlineClr);
            outlinePen = new Pen(graphDefaultOutlineClr, graphOutlineWidth);

            userSelectionBrush = new SolidBrush(graphUserNodeClr);

            programSelectionFillBrush = new SolidBrush(graphProgramNodeClr);
            programSelectionOutlineBrush = new SolidBrush(graphProgramOutlineClr);
            programSelectionOutlinePen = new Pen(graphProgramOutlineClr, graphOutlineWidth);


            sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
        }
    }
}
