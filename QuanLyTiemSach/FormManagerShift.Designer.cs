namespace QuanLyTiemSach
{
    partial class FormManagerShift
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
            btnAddShift = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cbEmployee = new ComboBox();
            dpShift = new DateTimePicker();
            cbShift = new ComboBox();
            gridShift = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            clm3 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)gridShift).BeginInit();
            SuspendLayout();
            // 
            // btnAddShift
            // 
            btnAddShift.BackColor = SystemColors.ActiveCaption;
            btnAddShift.Location = new Point(43, 181);
            btnAddShift.Name = "btnAddShift";
            btnAddShift.Size = new Size(102, 38);
            btnAddShift.TabIndex = 0;
            btnAddShift.Text = "Thêm";
            btnAddShift.UseVisualStyleBackColor = false;
            btnAddShift.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 68);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 1;
            label1.Text = "Nhân viên:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 109);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 2;
            label2.Text = "Ngày làm:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 147);
            label3.Name = "label3";
            label3.Size = new Size(58, 20);
            label3.TabIndex = 3;
            label3.Text = "Ca làm:";
            // 
            // label4
            // 
            label4.BackColor = SystemColors.MenuHighlight;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label4.ForeColor = Color.Transparent;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(800, 49);
            label4.TabIndex = 4;
            label4.Text = "Quản Lý Phân Ca";
            // 
            // cbEmployee
            // 
            cbEmployee.FormattingEnabled = true;
            cbEmployee.Location = new Point(124, 65);
            cbEmployee.Name = "cbEmployee";
            cbEmployee.Size = new Size(205, 28);
            cbEmployee.TabIndex = 5;
            // 
            // dpShift
            // 
            dpShift.Location = new Point(124, 104);
            dpShift.Name = "dpShift";
            dpShift.Size = new Size(250, 27);
            dpShift.TabIndex = 6;
            // 
            // cbShift
            // 
            cbShift.FormattingEnabled = true;
            cbShift.Location = new Point(124, 147);
            cbShift.Name = "cbShift";
            cbShift.Size = new Size(205, 28);
            cbShift.TabIndex = 7;
            cbShift.SelectedIndexChanged += cbShift_SelectedIndexChanged;
            // 
            // gridShift
            // 
            gridShift.BackgroundColor = Color.White;
            gridShift.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridShift.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, clm3 });
            gridShift.Location = new Point(43, 238);
            gridShift.Name = "gridShift";
            gridShift.RowHeadersWidth = 51;
            gridShift.Size = new Size(726, 188);
            gridShift.TabIndex = 8;
            // 
            // Column1
            // 
            Column1.HeaderText = "Nhân viên";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.HeaderText = "Ngày";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // clm3
            // 
            clm3.HeaderText = "Ca làm";
            clm3.MinimumWidth = 6;
            clm3.Name = "clm3";
            clm3.Width = 125;
            // 
            // FormManagerShift
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gridShift);
            Controls.Add(cbShift);
            Controls.Add(dpShift);
            Controls.Add(cbEmployee);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnAddShift);
            Name = "FormManagerShift";
            Text = "FormManagerShift";
            ((System.ComponentModel.ISupportInitialize)gridShift).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddShift;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cbEmployee;
        private DateTimePicker dpShift;
        private ComboBox cbShift;
        private DataGridView gridShift;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn clm3;
    }
}