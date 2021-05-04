
namespace FormTest
{
    partial class Form_main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_autoPlacing = new System.Windows.Forms.Button();
            this.groupBox_additionOfEdge = new System.Windows.Forms.GroupBox();
            this.btn_addEdge = new System.Windows.Forms.Button();
            this.cb_weightedEdge = new System.Windows.Forms.CheckBox();
            this.cb_directedEdge = new System.Windows.Forms.CheckBox();
            this.numeric_weight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label_comment = new System.Windows.Forms.Label();
            this.btn_addNode = new System.Windows.Forms.Button();
            this.btn_moveNode = new System.Windows.Forms.Button();
            this.cb_algoritms = new System.Windows.Forms.ComboBox();
            this.btn_applyAlgorithm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_remove = new System.Windows.Forms.Button();
            this.btn_test = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslbl_pos = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbl_mode = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbl_log = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.graphControl1 = new GraphControl.GraphControl();
            this.groupBox_additionOfEdge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_weight)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_autoPlacing
            // 
            this.btn_autoPlacing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_autoPlacing.Location = new System.Drawing.Point(466, 342);
            this.btn_autoPlacing.Name = "btn_autoPlacing";
            this.btn_autoPlacing.Size = new System.Drawing.Size(162, 23);
            this.btn_autoPlacing.TabIndex = 8;
            this.btn_autoPlacing.Text = "Автоматически разместить";
            this.btn_autoPlacing.UseVisualStyleBackColor = true;
            this.btn_autoPlacing.Click += new System.EventHandler(this.btn_autoPlacing_Click);
            // 
            // groupBox_additionOfEdge
            // 
            this.groupBox_additionOfEdge.Controls.Add(this.btn_addEdge);
            this.groupBox_additionOfEdge.Controls.Add(this.cb_weightedEdge);
            this.groupBox_additionOfEdge.Controls.Add(this.cb_directedEdge);
            this.groupBox_additionOfEdge.Controls.Add(this.numeric_weight);
            this.groupBox_additionOfEdge.Controls.Add(this.label3);
            this.groupBox_additionOfEdge.Location = new System.Drawing.Point(9, 106);
            this.groupBox_additionOfEdge.Name = "groupBox_additionOfEdge";
            this.groupBox_additionOfEdge.Size = new System.Drawing.Size(146, 118);
            this.groupBox_additionOfEdge.TabIndex = 9;
            this.groupBox_additionOfEdge.TabStop = false;
            this.groupBox_additionOfEdge.Text = "Добавление ребра";
            // 
            // btn_addEdge
            // 
            this.btn_addEdge.Location = new System.Drawing.Point(9, 92);
            this.btn_addEdge.Name = "btn_addEdge";
            this.btn_addEdge.Size = new System.Drawing.Size(131, 23);
            this.btn_addEdge.TabIndex = 4;
            this.btn_addEdge.Text = "Добавление ребра";
            this.btn_addEdge.UseVisualStyleBackColor = true;
            this.btn_addEdge.Click += new System.EventHandler(this.btn_addEdge_Click);
            // 
            // cb_weightedEdge
            // 
            this.cb_weightedEdge.AutoSize = true;
            this.cb_weightedEdge.Location = new System.Drawing.Point(8, 43);
            this.cb_weightedEdge.Name = "cb_weightedEdge";
            this.cb_weightedEdge.Size = new System.Drawing.Size(110, 17);
            this.cb_weightedEdge.TabIndex = 3;
            this.cb_weightedEdge.Text = "Ребро взвешено";
            this.cb_weightedEdge.UseVisualStyleBackColor = true;
            // 
            // cb_directedEdge
            // 
            this.cb_directedEdge.AutoSize = true;
            this.cb_directedEdge.Location = new System.Drawing.Point(8, 20);
            this.cb_directedEdge.Name = "cb_directedEdge";
            this.cb_directedEdge.Size = new System.Drawing.Size(137, 17);
            this.cb_directedEdge.TabIndex = 2;
            this.cb_directedEdge.Text = "Ребро ориентировано";
            this.cb_directedEdge.UseVisualStyleBackColor = true;
            // 
            // numeric_weight
            // 
            this.numeric_weight.Location = new System.Drawing.Point(41, 66);
            this.numeric_weight.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numeric_weight.Name = "numeric_weight";
            this.numeric_weight.Size = new System.Drawing.Size(64, 20);
            this.numeric_weight.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Вес:";
            // 
            // label_comment
            // 
            this.label_comment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_comment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_comment.Location = new System.Drawing.Point(12, 345);
            this.label_comment.Name = "label_comment";
            this.label_comment.Size = new System.Drawing.Size(445, 49);
            this.label_comment.TabIndex = 10;
            this.label_comment.Text = "Комментарий";
            // 
            // btn_addNode
            // 
            this.btn_addNode.Location = new System.Drawing.Point(9, 19);
            this.btn_addNode.Name = "btn_addNode";
            this.btn_addNode.Size = new System.Drawing.Size(145, 23);
            this.btn_addNode.TabIndex = 11;
            this.btn_addNode.Text = "Добавление вершины";
            this.btn_addNode.UseVisualStyleBackColor = true;
            this.btn_addNode.Click += new System.EventHandler(this.btn_addNode_Click);
            // 
            // btn_moveNode
            // 
            this.btn_moveNode.Location = new System.Drawing.Point(9, 48);
            this.btn_moveNode.Name = "btn_moveNode";
            this.btn_moveNode.Size = new System.Drawing.Size(145, 23);
            this.btn_moveNode.TabIndex = 13;
            this.btn_moveNode.Text = "Перемещение вершины";
            this.btn_moveNode.UseVisualStyleBackColor = true;
            this.btn_moveNode.Click += new System.EventHandler(this.btn_moveNode_Click);
            // 
            // cb_algoritms
            // 
            this.cb_algoritms.FormattingEnabled = true;
            this.cb_algoritms.Location = new System.Drawing.Point(6, 22);
            this.cb_algoritms.Name = "cb_algoritms";
            this.cb_algoritms.Size = new System.Drawing.Size(145, 21);
            this.cb_algoritms.TabIndex = 15;
            // 
            // btn_applyAlgorithm
            // 
            this.btn_applyAlgorithm.Location = new System.Drawing.Point(6, 49);
            this.btn_applyAlgorithm.Name = "btn_applyAlgorithm";
            this.btn_applyAlgorithm.Size = new System.Drawing.Size(145, 23);
            this.btn_applyAlgorithm.TabIndex = 17;
            this.btn_applyAlgorithm.Text = "Применить алгоритм";
            this.btn_applyAlgorithm.UseVisualStyleBackColor = true;
            this.btn_applyAlgorithm.Click += new System.EventHandler(this.btn_applyAlgorithm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_remove);
            this.groupBox1.Controls.Add(this.btn_addNode);
            this.groupBox1.Controls.Add(this.btn_moveNode);
            this.groupBox1.Controls.Add(this.groupBox_additionOfEdge);
            this.groupBox1.Location = new System.Drawing.Point(465, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(163, 234);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Режимы";
            // 
            // btn_remove
            // 
            this.btn_remove.Location = new System.Drawing.Point(9, 77);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(145, 23);
            this.btn_remove.TabIndex = 14;
            this.btn_remove.Text = "Удаление элемента";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // btn_test
            // 
            this.btn_test.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_test.Location = new System.Drawing.Point(507, 371);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(121, 23);
            this.btn_test.TabIndex = 21;
            this.btn_test.Text = "Создать по матрице";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cb_algoritms);
            this.groupBox2.Controls.Add(this.btn_applyAlgorithm);
            this.groupBox2.Location = new System.Drawing.Point(465, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(163, 78);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Алгоритмы над графом";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslbl_pos,
            this.tsslbl_mode,
            this.tsslbl_log});
            this.statusStrip1.Location = new System.Drawing.Point(0, 403);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(640, 22);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslbl_pos
            // 
            this.tsslbl_pos.Name = "tsslbl_pos";
            this.tsslbl_pos.Size = new System.Drawing.Size(58, 17);
            this.tsslbl_pos.Text = "tsslbl_pos";
            // 
            // tsslbl_mode
            // 
            this.tsslbl_mode.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tsslbl_mode.Name = "tsslbl_mode";
            this.tsslbl_mode.Size = new System.Drawing.Size(70, 17);
            this.tsslbl_mode.Text = "tsslbl_mode";
            // 
            // tsslbl_log
            // 
            this.tsslbl_log.Name = "tsslbl_log";
            this.tsslbl_log.Size = new System.Drawing.Size(56, 17);
            this.tsslbl_log.Text = "tsslbl_log";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(466, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // graphControl1
            // 
            this.graphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphControl1.Location = new System.Drawing.Point(12, 12);
            this.graphControl1.Name = "graphControl1";
            this.graphControl1.Size = new System.Drawing.Size(445, 313);
            this.graphControl1.TabIndex = 26;
            this.graphControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.graphControl1_MouseDown);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 425);
            this.Controls.Add(this.graphControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_comment);
            this.Controls.Add(this.btn_autoPlacing);
            this.MinimumSize = new System.Drawing.Size(656, 464);
            this.Name = "Form_main";
            this.Text = "TestForm for GraphControlLib";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_additionOfEdge.ResumeLayout(false);
            this.groupBox_additionOfEdge.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_weight)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_autoPlacing;
        private System.Windows.Forms.GroupBox groupBox_additionOfEdge;
        private System.Windows.Forms.CheckBox cb_weightedEdge;
        private System.Windows.Forms.CheckBox cb_directedEdge;
        private System.Windows.Forms.NumericUpDown numeric_weight;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btn_addEdge;
        private System.Windows.Forms.Label label_comment;
        private System.Windows.Forms.Button btn_addNode;
        private System.Windows.Forms.Button btn_moveNode;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.ComboBox cb_algoritms;
        private System.Windows.Forms.Button btn_applyAlgorithm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslbl_mode;
        private System.Windows.Forms.ToolStripStatusLabel tsslbl_pos;
        private System.Windows.Forms.ToolStripStatusLabel tsslbl_log;
        private System.Windows.Forms.Button button1;
        private GraphControl.GraphControl graphControl1;
    }
}

