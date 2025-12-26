namespace QuanLyTiemSach.UserFrms
{
    partial class FormUsers
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.GroupBox grpUserInfo;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            btnRefresh = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblTitle = new Label();
            pnlCenter = new Panel();
            dgvUsers = new DataGridView();
            pnlBottom = new Panel();
            grpUserInfo = new GroupBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            cboStatus = new ComboBox();
            lblStatus = new Label();
            cboRole = new ComboBox();
            lblRole = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            pnlTop.SuspendLayout();
            pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            pnlBottom.SuspendLayout();
            grpUserInfo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(41, 128, 185);
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Controls.Add(btnSearch);
            pnlTop.Controls.Add(txtSearch);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(3, 4, 3, 4);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(977, 107);
            pnlTop.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(428, 64);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(103, 40);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(46, 204, 113);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(313, 64);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(103, 40);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(16, 66);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(285, 30);
            txtSearch.TabIndex = 2;
            txtSearch.KeyPress += txtSearch_KeyPress;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(355, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ NGƯỜI DÙNG";

            // 
            // pnlCenter
            // 
            pnlCenter.Controls.Add(dgvUsers);
            pnlCenter.Dock = DockStyle.Fill;
            pnlCenter.Location = new Point(0, 107);
            pnlCenter.Margin = new Padding(3, 4, 3, 4);
            pnlCenter.Name = "pnlCenter";
            pnlCenter.Padding = new Padding(11, 13, 11, 13);
            pnlCenter.Size = new Size(977, 293);
            pnlCenter.TabIndex = 1;

            // 
            // dgvUsers
            // 
            dgvUsers.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvUsers.DefaultCellStyle = dataGridViewCellStyle4;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(11, 13);
            dgvUsers.Margin = new Padding(3, 4, 3, 4);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.RowTemplate.Height = 25;
            dgvUsers.Size = new Size(955, 267);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellClick += dgvUsers_CellClick;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.AllowUserToResizeColumns = false;
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.AutoGenerateColumns = true;


            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.FromArgb(236, 240, 241);
            pnlBottom.Controls.Add(grpUserInfo);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 400);
            pnlBottom.Margin = new Padding(3, 4, 3, 4);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(977, 285);
            pnlBottom.TabIndex = 2;
            // 
            // grpUserInfo
            // 
            grpUserInfo.Controls.Add(btnDelete);
            grpUserInfo.Controls.Add(btnUpdate);
            grpUserInfo.Controls.Add(btnAdd);
            grpUserInfo.Controls.Add(cboStatus);
            grpUserInfo.Controls.Add(lblStatus);
            grpUserInfo.Controls.Add(cboRole);
            grpUserInfo.Controls.Add(lblRole);
            grpUserInfo.Controls.Add(txtPassword);
            grpUserInfo.Controls.Add(lblPassword);
            grpUserInfo.Controls.Add(txtEmail);
            grpUserInfo.Controls.Add(lblEmail);
            grpUserInfo.Controls.Add(txtFullName);
            grpUserInfo.Controls.Add(lblFullName);
            grpUserInfo.Controls.Add(txtUsername);
            grpUserInfo.Controls.Add(lblUsername);
            grpUserInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpUserInfo.Location = new Point(11, 9);
            grpUserInfo.Margin = new Padding(3, 4, 3, 4);
            grpUserInfo.Name = "grpUserInfo";
            grpUserInfo.Padding = new Padding(3, 4, 3, 4);
            grpUserInfo.Size = new Size(954, 272);
            grpUserInfo.TabIndex = 0;
            grpUserInfo.TabStop = false;
            grpUserInfo.Text = "Thông tin người dùng";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.Enabled = false;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(552, 207);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(137, 53);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(52, 152, 219);
            btnUpdate.Enabled = false;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(323, 207);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(137, 53);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(95, 207);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(137, 53);
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Font = new Font("Segoe UI", 9F);
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Active", "Inactive" });
            cboStatus.Location = new Point(502, 156);
            cboStatus.Margin = new Padding(3, 4, 3, 4);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(213, 28);
            cboStatus.TabIndex = 11;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.Location = new Point(420, 160);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(78, 20);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Trạng thái:";
            // 
            // cboRole
            // 
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Font = new Font("Segoe UI", 9F);
            cboRole.FormattingEnabled = true;
            cboRole.Items.AddRange(new object[] { "Admin", "Staff" });
            cboRole.Location = new Point(502, 103);
            cboRole.Margin = new Padding(3, 4, 3, 4);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(213, 28);
            cboRole.TabIndex = 9;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 9F);
            lblRole.Location = new Point(420, 107);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(55, 20);
            lblRole.TabIndex = 8;
            lblRole.Text = "Vai trò:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.Location = new Point(502, 49);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(213, 27);
            txtPassword.TabIndex = 7;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F);
            lblPassword.Location = new Point(420, 53);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.Location = new Point(146, 156);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 27);
            txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F);
            lblEmail.Location = new Point(34, 160);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(49, 20);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 9F);
            txtFullName.Location = new Point(146, 103);
            txtFullName.Margin = new Padding(3, 4, 3, 4);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(220, 27);
            txtFullName.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 9F);
            lblFullName.Location = new Point(34, 107);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(76, 20);
            lblFullName.TabIndex = 2;
            lblFullName.Text = "Họ và tên:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 9F);
            txtUsername.Location = new Point(146, 49);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(220, 27);
            txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F);
            lblUsername.Location = new Point(34, 53);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(110, 20);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Tên đăng nhập:";
            // 
            // FormUsers
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 685);
            Controls.Add(pnlCenter);
            Controls.Add(pnlBottom);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Người dùng - QuanLyTiemSach";
            Load += FormUsers_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            pnlBottom.ResumeLayout(false);
            grpUserInfo.ResumeLayout(false);
            grpUserInfo.PerformLayout();
            ResumeLayout(false);
        }
    }
}