namespace QuanLyTiemSach.SalaryFrms
{
    partial class FormSalary
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
            lblTitle = new Label();
            lblEmployeeId = new Label();
            txtEmployeeId = new TextBox();
            lblMonth = new Label();
            cboMonth = new ComboBox();
            lblShifts = new Label();
            txtShifts = new TextBox();
            lblAmount = new Label();
            txtAmount = new TextBox();
            btnCalculate = new Button();
            btnSave = new Button();
            btnClear = new Button();
            dgvSalary = new DataGridView();
            groupBoxInput = new GroupBox();
            cboYear = new ComboBox();
            lblYear = new Label();
            lblEmployee = new Label();
            cboEmployee = new ComboBox();
            groupBoxList = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvSalary).BeginInit();
            groupBoxInput.SuspendLayout();
            groupBoxList.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 122, 204);
            lblTitle.Location = new Point(333, 31);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(416, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ LƯƠNG NHÂN VIÊN";
            // 
            // lblEmployeeId
            // 
            lblEmployeeId.AutoSize = true;
            lblEmployeeId.Location = new Point(40, 71);
            lblEmployeeId.Margin = new Padding(4, 0, 4, 0);
            lblEmployeeId.Name = "lblEmployeeId";
            lblEmployeeId.Size = new Size(105, 20);
            lblEmployeeId.TabIndex = 1;
            lblEmployeeId.Text = "Mã Nhân Viên:";
            // 
            // txtEmployeeId
            // 
            txtEmployeeId.BackColor = Color.FromArgb(240, 240, 240);
            txtEmployeeId.Location = new Point(173, 67);
            txtEmployeeId.Margin = new Padding(4, 5, 4, 5);
            txtEmployeeId.Name = "txtEmployeeId";
            txtEmployeeId.ReadOnly = true;
            txtEmployeeId.Size = new Size(265, 27);
            txtEmployeeId.TabIndex = 2;
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Location = new Point(40, 118);
            lblMonth.Margin = new Padding(4, 0, 4, 0);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(53, 20);
            lblMonth.TabIndex = 3;
            lblMonth.Text = "Tháng:";
            // 
            // cboMonth
            // 
            cboMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonth.FormattingEnabled = true;
            cboMonth.Location = new Point(173, 114);
            cboMonth.Margin = new Padding(4, 5, 4, 5);
            cboMonth.Name = "cboMonth";
            cboMonth.Size = new Size(130, 28);
            cboMonth.TabIndex = 4;
            cboMonth.SelectedIndexChanged += cboMonth_SelectedIndexChanged;
            // 
            // lblShifts
            // 
            lblShifts.AutoSize = true;
            lblShifts.Location = new Point(533, 71);
            lblShifts.Margin = new Padding(4, 0, 4, 0);
            lblShifts.Name = "lblShifts";
            lblShifts.Size = new Size(82, 20);
            lblShifts.TabIndex = 5;
            lblShifts.Text = "Số Ca Làm:";
            // 
            // txtShifts
            // 
            txtShifts.BackColor = Color.FromArgb(240, 240, 240);
            txtShifts.Location = new Point(653, 67);
            txtShifts.Margin = new Padding(4, 5, 4, 5);
            txtShifts.Name = "txtShifts";
            txtShifts.ReadOnly = true;
            txtShifts.Size = new Size(265, 27);
            txtShifts.TabIndex = 6;
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(533, 118);
            lblAmount.Margin = new Padding(4, 0, 4, 0);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(92, 20);
            lblAmount.TabIndex = 7;
            lblAmount.Text = "Tổng Lương:";
            // 
            // txtAmount
            // 
            txtAmount.BackColor = Color.FromArgb(240, 240, 240);
            txtAmount.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            txtAmount.ForeColor = Color.FromArgb(0, 122, 204);
            txtAmount.Location = new Point(653, 114);
            txtAmount.Margin = new Padding(4, 5, 4, 5);
            txtAmount.Name = "txtAmount";
            txtAmount.ReadOnly = true;
            txtAmount.Size = new Size(265, 24);
            txtAmount.TabIndex = 8;
            // 
            // btnCalculate
            // 
            btnCalculate.BackColor = Color.FromArgb(0, 122, 204);
            btnCalculate.FlatStyle = FlatStyle.Flat;
            btnCalculate.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnCalculate.ForeColor = Color.White;
            btnCalculate.Location = new Point(173, 185);
            btnCalculate.Margin = new Padding(4, 5, 4, 5);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(160, 54);
            btnCalculate.TabIndex = 9;
            btnCalculate.Text = "Tải Số Ca";
            btnCalculate.UseVisualStyleBackColor = false;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(40, 167, 69);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(413, 185);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(160, 54);
            btnSave.TabIndex = 10;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(220, 53, 69);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(653, 185);
            btnClear.Margin = new Padding(4, 5, 4, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(160, 54);
            btnClear.TabIndex = 11;
            btnClear.Text = "Làm Mới";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // dgvSalary
            // 
            dgvSalary.AllowUserToAddRows = false;
            dgvSalary.AllowUserToDeleteRows = false;
            dgvSalary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalary.BackgroundColor = Color.White;
            dgvSalary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalary.Dock = DockStyle.Fill;
            dgvSalary.Location = new Point(4, 25);
            dgvSalary.Margin = new Padding(4, 5, 4, 5);
            dgvSalary.Name = "dgvSalary";
            dgvSalary.ReadOnly = true;
            dgvSalary.RowHeadersWidth = 51;
            dgvSalary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalary.Size = new Size(1005, 324);
            dgvSalary.TabIndex = 12;
            // 
            // groupBoxInput
            // 
            groupBoxInput.Controls.Add(cboYear);
            groupBoxInput.Controls.Add(lblYear);
            groupBoxInput.Controls.Add(lblEmployee);
            groupBoxInput.Controls.Add(cboEmployee);
            groupBoxInput.Controls.Add(lblEmployeeId);
            groupBoxInput.Controls.Add(txtEmployeeId);
            groupBoxInput.Controls.Add(lblMonth);
            groupBoxInput.Controls.Add(btnClear);
            groupBoxInput.Controls.Add(cboMonth);
            groupBoxInput.Controls.Add(btnSave);
            groupBoxInput.Controls.Add(lblShifts);
            groupBoxInput.Controls.Add(btnCalculate);
            groupBoxInput.Controls.Add(txtShifts);
            groupBoxInput.Controls.Add(txtAmount);
            groupBoxInput.Controls.Add(lblAmount);
            groupBoxInput.Location = new Point(27, 92);
            groupBoxInput.Margin = new Padding(4, 5, 4, 5);
            groupBoxInput.Name = "groupBoxInput";
            groupBoxInput.Padding = new Padding(4, 5, 4, 5);
            groupBoxInput.Size = new Size(1013, 277);
            groupBoxInput.TabIndex = 13;
            groupBoxInput.TabStop = false;
            groupBoxInput.Text = "Thông Tin Lương";
            // 
            // cboYear
            // 
            cboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cboYear.FormattingEnabled = true;
            cboYear.Location = new Point(308, 114);
            cboYear.Margin = new Padding(4, 5, 4, 5);
            cboYear.Name = "cboYear";
            cboYear.Size = new Size(130, 28);
            cboYear.TabIndex = 16;
            cboYear.SelectedIndexChanged += cboYear_SelectedIndexChanged;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(308, 89);
            lblYear.Margin = new Padding(4, 0, 4, 0);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(42, 20);
            lblYear.TabIndex = 15;
            lblYear.Text = "Năm:";
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.Location = new Point(40, 24);
            lblEmployee.Margin = new Padding(4, 0, 4, 0);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(79, 20);
            lblEmployee.TabIndex = 13;
            lblEmployee.Text = "Nhân Viên:";
            // 
            // cboEmployee
            // 
            cboEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEmployee.FormattingEnabled = true;
            cboEmployee.Location = new Point(173, 20);
            cboEmployee.Name = "cboEmployee";
            cboEmployee.Size = new Size(265, 28);
            cboEmployee.TabIndex = 12;
            cboEmployee.SelectedIndexChanged += cboEmployee_SelectedIndexChanged;
            // 
            // groupBoxList
            // 
            groupBoxList.Controls.Add(dgvSalary);
            groupBoxList.Location = new Point(27, 400);
            groupBoxList.Margin = new Padding(4, 5, 4, 5);
            groupBoxList.Name = "groupBoxList";
            groupBoxList.Padding = new Padding(4, 5, 4, 5);
            groupBoxList.Size = new Size(1013, 354);
            groupBoxList.TabIndex = 14;
            groupBoxList.TabStop = false;
            groupBoxList.Text = "Danh Sách Lương";
            // 
            // FormSalary
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1067, 785);
            Controls.Add(groupBoxList);
            Controls.Add(groupBoxInput);
            Controls.Add(lblTitle);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormSalary";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Lương Nhân Viên";
            Load += SalaryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSalary).EndInit();
            groupBoxInput.ResumeLayout(false);
            groupBoxInput.PerformLayout();
            groupBoxList.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmployeeId;
        private System.Windows.Forms.TextBox txtEmployeeId;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label lblShifts;
        private System.Windows.Forms.TextBox txtShifts;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvSalary;
        private System.Windows.Forms.GroupBox groupBoxInput;
        private System.Windows.Forms.GroupBox groupBoxList;
        private ComboBox cboEmployee;
        private Label lblEmployee;
        private ComboBox cboYear;
        private Label lblYear;
    }
}