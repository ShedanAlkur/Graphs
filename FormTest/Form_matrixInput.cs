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
    public partial class Form_matrixInput : Form
    {
        GraphControl.GraphControl graphControl;

        public Form_matrixInput(GraphControl.GraphControl testUserControl)
        {
            InitializeComponent();
            this.graphControl = testUserControl;
        }

        private void MakeMatrixSymmetric()
        {
            for (int i = 0; i < dgv_matrix.RowCount; i++)
                for (int j = i + 1; j < dgv_matrix.ColumnCount; j++)
                    dgv_matrix[i, j].Value = dgv_matrix[j, i].Value;
        }

        private void Form_matrixInput_Load(object sender, EventArgs e)
        {
            num_nodeCounter.Value = 3;
        }

        private void num_nodeCounter_ValueChanged(object sender, EventArgs e)
        {
            dgv_matrix.RowCount = (int)num_nodeCounter.Value;
            dgv_matrix.ColumnCount = (int)num_nodeCounter.Value;
        }

        private void cb_weighted_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cb_directed_CheckedChanged(object sender, EventArgs e)
        {
            if (!cb_directed.Checked) MakeMatrixSymmetric();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            try
            {
                float[,] matrix = new float[dgv_matrix.RowCount, dgv_matrix.ColumnCount];
                for (int i = 0; i < dgv_matrix.RowCount; i++)
                    for (int j = 0; j < dgv_matrix.ColumnCount; j++)
                        matrix[i, j] = (float)Convert.ToDouble(dgv_matrix[j, i].Value);
                graphControl.CreateByAdjacencyMatrix(matrix, cb_directed.Checked, cb_weighted.Checked);
            }
            catch { MessageBox.Show("Введенные значения вызвали ошибку. Изменения не приняты.", "Ошибка"); }
            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_random_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for (int i = 0; i < dgv_matrix.RowCount; i++)
                for (int j = 0; j < dgv_matrix.ColumnCount; j++)
                    if (i!=j && rnd.NextDouble() < 0.35)
                        dgv_matrix[i, j].Value = rnd.Next(1, 30);
                    else dgv_matrix[i, j].Value = 0;

            if (!cb_directed.Checked) MakeMatrixSymmetric();
        }

        private void dgv_matrix_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);

            TextBox tb = e.Control as TextBox;
            if (tb != null)
            {
                tb.KeyPress += new KeyPressEventHandler(Column_KeyPress);
            }
        }

        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) 
                || e.KeyChar == '.' && !(sender as TextBox).Text.Contains('.')))
            {
                e.Handled = true;
            }
        }

        private void dgv_matrix_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!cb_directed.Checked)
                dgv_matrix[e.RowIndex, e.ColumnIndex].Value =
                    dgv_matrix[e.ColumnIndex, e.RowIndex].Value;
        }
    }
}
