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
        None = 0x00,
        Select = 0x01,
        Move = 0x02,
        Remove = 0x03,

        AddNode = 0x11,
        //RemoveNode = 0x13,

        AddEdge = 0x21,
        //RemoveEdge = 0x23
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void testUserControl1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void testUserControl1_MouseDown(object sender, MouseEventArgs e)
        {
            //switch (testUserControl1.GraphMode)
            //{
            //    case GraphInteractionMode.None: break;
            //    case GraphInteractionMode.Select: break;
            //    case GraphInteractionMode.Move: break;
            //    case GraphInteractionMode.Remove:
            //        {
            //            //(sender as TestUserControl).sele
            //            break;
            //        }
            //    case GraphInteractionMode.AddNode:
            //        {
            //            (sender as TestUserControl).AddNode(e.Location);
            //            break;
            //        }
            //    case GraphInteractionMode.AddEdge: break;
            //}

            if (e.Button == MouseButtons.Left)
                (sender as TestUserControl).AddNode(e.Location);
            if (e.Button == MouseButtons.Right)
                (sender as TestUserControl).SelectionUpdate(e.Location);
            if (e.Button == MouseButtons.Middle)
            {
                //(sender as TestUserControl).RemoveSelectedElements();

                (sender as TestUserControl).test_x = e.X;
                (sender as TestUserControl).test_y = e.Y;
                testUserControl1.Invalidate();
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void testUserControl1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = $"X = {e.X}, Y = {e.Y}";
        }
    }
}
