
namespace FormTest
{
    partial class Form_matrixInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.num_nodeCounter = new System.Windows.Forms.NumericUpDown();
            this.cb_weighted = new System.Windows.Forms.CheckBox();
            this.cb_directed = new System.Windows.Forms.CheckBox();
            this.dgv_matrix = new System.Windows.Forms.DataGridView();
            this.btn_create = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_random = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_nodeCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_matrix)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество вершин";
            // 
            // num_nodeCounter
            // 
            this.num_nodeCounter.Location = new System.Drawing.Point(125, 7);
            this.num_nodeCounter.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.num_nodeCounter.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_nodeCounter.Name = "num_nodeCounter";
            this.num_nodeCounter.Size = new System.Drawing.Size(62, 20);
            this.num_nodeCounter.TabIndex = 1;
            this.num_nodeCounter.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.num_nodeCounter.ValueChanged += new System.EventHandler(this.num_nodeCounter_ValueChanged);
            // 
            // cb_weighted
            // 
            this.cb_weighted.AutoSize = true;
            this.cb_weighted.Location = new System.Drawing.Point(193, 8);
            this.cb_weighted.Name = "cb_weighted";
            this.cb_weighted.Size = new System.Drawing.Size(99, 17);
            this.cb_weighted.TabIndex = 2;
            this.cb_weighted.Text = "Граф взвешен";
            this.cb_weighted.UseVisualStyleBackColor = true;
            this.cb_weighted.CheckedChanged += new System.EventHandler(this.cb_weighted_CheckedChanged);
            // 
            // cb_directed
            // 
            this.cb_directed.AutoSize = true;
            this.cb_directed.Location = new System.Drawing.Point(193, 31);
            this.cb_directed.Name = "cb_directed";
            this.cb_directed.Size = new System.Drawing.Size(126, 17);
            this.cb_directed.TabIndex = 3;
            this.cb_directed.Text = "Граф ориентирован";
            this.cb_directed.UseVisualStyleBackColor = true;
            this.cb_directed.CheckedChanged += new System.EventHandler(this.cb_directed_CheckedChanged);
            // 
            // dgv_matrix
            // 
            this.dgv_matrix.AllowUserToAddRows = false;
            this.dgv_matrix.AllowUserToDeleteRows = false;
            this.dgv_matrix.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_matrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = "0";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_matrix.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_matrix.Location = new System.Drawing.Point(12, 56);
            this.dgv_matrix.Name = "dgv_matrix";
            this.dgv_matrix.Size = new System.Drawing.Size(310, 310);
            this.dgv_matrix.TabIndex = 4;
            this.dgv_matrix.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_matrix_CellEndEdit);
            this.dgv_matrix.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_matrix_EditingControlShowing);
            // 
            // btn_create
            // 
            this.btn_create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_create.Location = new System.Drawing.Point(12, 372);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(75, 23);
            this.btn_create.TabIndex = 5;
            this.btn_create.Text = "Создать граф";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_cancel.Location = new System.Drawing.Point(93, 372);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "Отмена";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_random
            // 
            this.btn_random.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_random.Location = new System.Drawing.Point(193, 372);
            this.btn_random.Name = "btn_random";
            this.btn_random.Size = new System.Drawing.Size(126, 23);
            this.btn_random.TabIndex = 7;
            this.btn_random.Text = "Заполнить случайно";
            this.btn_random.UseVisualStyleBackColor = true;
            this.btn_random.Click += new System.EventHandler(this.btn_random_Click);
            // 
            // Form_matrixInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 401);
            this.Controls.Add(this.btn_random);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.dgv_matrix);
            this.Controls.Add(this.cb_directed);
            this.Controls.Add(this.cb_weighted);
            this.Controls.Add(this.num_nodeCounter);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 440);
            this.Name = "Form_matrixInput";
            this.ShowIcon = false;
            this.Text = "Создать по матрице смежности";
            this.Load += new System.EventHandler(this.Form_matrixInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_nodeCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_matrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_nodeCounter;
        private System.Windows.Forms.CheckBox cb_weighted;
        private System.Windows.Forms.CheckBox cb_directed;
        private System.Windows.Forms.DataGridView dgv_matrix;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_random;
    }
}