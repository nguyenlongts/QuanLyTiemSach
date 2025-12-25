namespace WorkShiftManagement.Forms
{
    partial class FormManagerShift
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelTop = new Panel();
            btnPreviousWeek = new Button();
            btnNextWeek = new Button();
            lblWeekRange = new Label();
            groupBoxAdd = new GroupBox();
            cboEmployee = new ComboBox();
            lblEmployee = new Label();
            dtpWorkDate = new DateTimePicker();
            lblWorkDate = new Label();
            cboShiftType = new ComboBox();
            lblShiftType = new Label();
            txtNote = new TextBox();
            lblNote = new Label();
            btnAddShift = new Button();
            panelSchedule = new Panel();
            dgvSchedule = new DataGridView();
            panelTop.SuspendLayout();
            groupBoxAdd.SuspendLayout();
            panelSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(btnPreviousWeek);
            panelTop.Controls.Add(btnNextWeek);
            panelTop.Controls.Add(lblWeekRange);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 5, 4, 5);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1591, 77);
            panelTop.TabIndex = 0;
            // 
            // btnPreviousWeek
            // 
            btnPreviousWeek.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnPreviousWeek.Location = new Point(27, 15);
            btnPreviousWeek.Margin = new Padding(4, 5, 4, 5);
            btnPreviousWeek.Name = "btnPreviousWeek";
            btnPreviousWeek.Size = new Size(107, 46);
            btnPreviousWeek.TabIndex = 0;
            btnPreviousWeek.Text = "< Trước";
            btnPreviousWeek.UseVisualStyleBackColor = true;
            btnPreviousWeek.Click += btnPreviousWeek_Click;
            // 
            // btnNextWeek
            // 
            btnNextWeek.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnNextWeek.Location = new Point(1467, 15);
            btnNextWeek.Margin = new Padding(4, 5, 4, 5);
            btnNextWeek.Name = "btnNextWeek";
            btnNextWeek.Size = new Size(107, 46);
            btnNextWeek.TabIndex = 1;
            btnNextWeek.Text = "Sau >";
            btnNextWeek.UseVisualStyleBackColor = true;
            btnNextWeek.Click += btnNextWeek_Click;
            // 
            // lblWeekRange
            // 
            lblWeekRange.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblWeekRange.Location = new Point(147, 15);
            lblWeekRange.Margin = new Padding(4, 0, 4, 0);
            lblWeekRange.Name = "lblWeekRange";
            lblWeekRange.Size = new Size(1307, 46);
            lblWeekRange.TabIndex = 2;
            lblWeekRange.Text = "Tuần từ 01/01/2025 đến 07/01/2025";
            lblWeekRange.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBoxAdd
            // 
            groupBoxAdd.Controls.Add(cboEmployee);
            groupBoxAdd.Controls.Add(lblEmployee);
            groupBoxAdd.Controls.Add(dtpWorkDate);
            groupBoxAdd.Controls.Add(lblWorkDate);
            groupBoxAdd.Controls.Add(cboShiftType);
            groupBoxAdd.Controls.Add(lblShiftType);
            groupBoxAdd.Controls.Add(txtNote);
            groupBoxAdd.Controls.Add(lblNote);
            groupBoxAdd.Controls.Add(btnAddShift);
            groupBoxAdd.Dock = DockStyle.Top;
            groupBoxAdd.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            groupBoxAdd.Location = new Point(0, 77);
            groupBoxAdd.Margin = new Padding(4, 5, 4, 5);
            groupBoxAdd.Name = "groupBoxAdd";
            groupBoxAdd.Padding = new Padding(4, 5, 4, 5);
            groupBoxAdd.Size = new Size(1591, 185);
            groupBoxAdd.TabIndex = 1;
            groupBoxAdd.TabStop = false;
            groupBoxAdd.Text = "Thêm Ca Làm Việc";
            // 
            // cboEmployee
            // 
            cboEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEmployee.Font = new Font("Microsoft Sans Serif", 9F);
            cboEmployee.FormattingEnabled = true;
            cboEmployee.Location = new Point(160, 46);
            cboEmployee.Margin = new Padding(4, 5, 4, 5);
            cboEmployee.Name = "cboEmployee";
            cboEmployee.Size = new Size(332, 26);
            cboEmployee.TabIndex = 1;
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.Font = new Font("Microsoft Sans Serif", 9F);
            lblEmployee.Location = new Point(27, 51);
            lblEmployee.Margin = new Padding(4, 0, 4, 0);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(77, 18);
            lblEmployee.TabIndex = 0;
            lblEmployee.Text = "Nhân viên:";
            // 
            // dtpWorkDate
            // 
            dtpWorkDate.Font = new Font("Microsoft Sans Serif", 9F);
            dtpWorkDate.Format = DateTimePickerFormat.Short;
            dtpWorkDate.Location = new Point(160, 100);
            dtpWorkDate.Margin = new Padding(4, 5, 4, 5);
            dtpWorkDate.Name = "dtpWorkDate";
            dtpWorkDate.Size = new Size(332, 24);
            dtpWorkDate.TabIndex = 3;
            // 
            // lblWorkDate
            // 
            lblWorkDate.AutoSize = true;
            lblWorkDate.Font = new Font("Microsoft Sans Serif", 9F);
            lblWorkDate.Location = new Point(27, 105);
            lblWorkDate.Margin = new Padding(4, 0, 4, 0);
            lblWorkDate.Name = "lblWorkDate";
            lblWorkDate.Size = new Size(74, 18);
            lblWorkDate.TabIndex = 2;
            lblWorkDate.Text = "Ngày làm:";
            // 
            // cboShiftType
            // 
            cboShiftType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboShiftType.Font = new Font("Microsoft Sans Serif", 9F);
            cboShiftType.FormattingEnabled = true;
            cboShiftType.Location = new Point(667, 46);
            cboShiftType.Margin = new Padding(4, 5, 4, 5);
            cboShiftType.Name = "cboShiftType";
            cboShiftType.Size = new Size(265, 26);
            cboShiftType.TabIndex = 5;
            // 
            // lblShiftType
            // 
            lblShiftType.AutoSize = true;
            lblShiftType.Font = new Font("Microsoft Sans Serif", 9F);
            lblShiftType.Location = new Point(533, 51);
            lblShiftType.Margin = new Padding(4, 0, 4, 0);
            lblShiftType.Name = "lblShiftType";
            lblShiftType.Size = new Size(59, 18);
            lblShiftType.TabIndex = 4;
            lblShiftType.Text = "Ca làm:";
            // 
            // txtNote
            // 
            txtNote.Font = new Font("Microsoft Sans Serif", 9F);
            txtNote.Location = new Point(667, 100);
            txtNote.Margin = new Padding(4, 5, 4, 5);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(265, 24);
            txtNote.TabIndex = 7;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Font = new Font("Microsoft Sans Serif", 9F);
            lblNote.Location = new Point(533, 105);
            lblNote.Margin = new Padding(4, 0, 4, 0);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(63, 18);
            lblNote.TabIndex = 6;
            lblNote.Text = "Ghi chú:";
            // 
            // btnAddShift
            // 
            btnAddShift.BackColor = Color.FromArgb(0, 122, 204);
            btnAddShift.FlatStyle = FlatStyle.Flat;
            btnAddShift.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            btnAddShift.ForeColor = Color.White;
            btnAddShift.Location = new Point(812, 134);
            btnAddShift.Margin = new Padding(4, 5, 4, 5);
            btnAddShift.Name = "btnAddShift";
            btnAddShift.Size = new Size(120, 38);
            btnAddShift.TabIndex = 8;
            btnAddShift.Text = "Thêm Ca";
            btnAddShift.UseVisualStyleBackColor = false;
            btnAddShift.Click += btnAddShift_Click;
            // 
            // panelSchedule
            // 
            panelSchedule.Controls.Add(dgvSchedule);
            panelSchedule.Dock = DockStyle.Fill;
            panelSchedule.Location = new Point(0, 262);
            panelSchedule.Margin = new Padding(4, 5, 4, 5);
            panelSchedule.Name = "panelSchedule";
            panelSchedule.Padding = new Padding(13, 15, 13, 15);
            panelSchedule.Size = new Size(1591, 793);
            panelSchedule.TabIndex = 2;
            // 
            // dgvSchedule
            // 
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.AllowUserToDeleteRows = false;
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.BackgroundColor = Color.White;
            dgvSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSchedule.Dock = DockStyle.Fill;
            dgvSchedule.Location = new Point(13, 15);
            dgvSchedule.Margin = new Padding(4, 5, 4, 5);
            dgvSchedule.Name = "dgvSchedule";
            dgvSchedule.ReadOnly = true;
            dgvSchedule.RowHeadersWidth = 100;
            dgvSchedule.RowTemplate.Height = 80;
            dgvSchedule.Size = new Size(1565, 763);
            dgvSchedule.TabIndex = 0;
            dgvSchedule.CellContentClick += dgvSchedule_CellContentClick;
            dgvSchedule.RowHeadersVisible = false;
            // 
            // FormManagerShift
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1591, 1055);
            Controls.Add(panelSchedule);
            Controls.Add(groupBoxAdd);
            Controls.Add(panelTop);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormManagerShift";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Phân Ca Làm Việc";
            Load += WorkShiftForm_Load;
            panelTop.ResumeLayout(false);
            groupBoxAdd.ResumeLayout(false);
            groupBoxAdd.PerformLayout();
            panelSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnPreviousWeek;
        private System.Windows.Forms.Button btnNextWeek;
        private System.Windows.Forms.Label lblWeekRange;
        private System.Windows.Forms.GroupBox groupBoxAdd;
        private System.Windows.Forms.ComboBox cboEmployee;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.DateTimePicker dtpWorkDate;
        private System.Windows.Forms.Label lblWorkDate;
        private System.Windows.Forms.ComboBox cboShiftType;
        private System.Windows.Forms.Label lblShiftType;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Button btnAddShift;
        private System.Windows.Forms.Panel panelSchedule;
        private System.Windows.Forms.DataGridView dgvSchedule;
    }
}