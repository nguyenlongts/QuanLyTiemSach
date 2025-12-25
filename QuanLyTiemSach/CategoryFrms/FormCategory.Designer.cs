namespace QuanLyTiemSach
{
    partial class FormCategory
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Panel pnlBottom;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;

        private System.Windows.Forms.DataGridView dgvCategory;

        private System.Windows.Forms.GroupBox grpCategoryInfo;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            btnRefresh = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblTitle = new Label();

            pnlCenter = new Panel();
            dgvCategory = new DataGridView();

            pnlBottom = new Panel();
            grpCategoryInfo = new GroupBox();
            lblCategoryName = new Label();
            txtCategoryName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();

            pnlTop.SuspendLayout();
            pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).BeginInit();
            pnlBottom.SuspendLayout();
            grpCategoryInfo.SuspendLayout();
            SuspendLayout();

            // ================= TOP =================
            pnlTop.BackColor = Color.FromArgb(41, 128, 185);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 100;
            pnlTop.Controls.Add(btnRefresh);
            pnlTop.Controls.Add(btnSearch);
            pnlTop.Controls.Add(txtSearch);
            pnlTop.Controls.Add(lblTitle);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 10);
            lblTitle.Text = "QUẢN LÝ DANH MỤC";

            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(18, 55);
            txtSearch.Size = new Size(260, 30);

            btnSearch.BackColor = Color.FromArgb(46, 204, 113);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(290, 55);
            btnSearch.Size = new Size(100, 30);
            btnSearch.Text = "Tìm kiếm";
            btnSearch.Click += btnSearch_Click;

            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(400, 55);
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.Text = "Làm mới";
            btnRefresh.Click += btnRefresh_Click;

            // ================= CENTER =================
            pnlCenter.Dock = DockStyle.Fill;
            pnlCenter.Padding = new Padding(10);
            pnlCenter.Controls.Add(dgvCategory);

            dgvCategory.Dock = DockStyle.Fill;
            dgvCategory.BackgroundColor = Color.White;
            dgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategory.ReadOnly = true;
            dgvCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategory.AllowUserToAddRows = false;
            dgvCategory.AllowUserToDeleteRows = false;
            dgvCategory.RowHeadersVisible = false;
            dgvCategory.CellClick += dgvCategory_CellClick;

            // ================= BOTTOM =================
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Height = 250;
            pnlBottom.BackColor = Color.FromArgb(236, 240, 241);
            pnlBottom.Controls.Add(grpCategoryInfo);

            grpCategoryInfo.Text = "Thông tin danh mục";
            grpCategoryInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpCategoryInfo.Dock = DockStyle.Fill;

            lblCategoryName.Text = "Tên danh mục:";
            lblCategoryName.Location = new Point(30, 40);

            txtCategoryName.Location = new Point(150, 36);
            txtCategoryName.Size = new Size(250, 27);

            lblDescription.Text = "Mô tả:";
            lblDescription.Location = new Point(30, 85);

            txtDescription.Location = new Point(150, 81);
            txtDescription.Size = new Size(250, 27);

            btnAdd.Text = "Thêm";
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(150, 140);
            btnAdd.Size = new Size(110, 40);
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.BackColor = Color.FromArgb(52, 152, 219);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(270, 140);
            btnUpdate.Size = new Size(110, 40);
            btnUpdate.Enabled = false;
            btnUpdate.Click += btnUpdate_Click;

            btnDelete.Text = "Xóa";
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(390, 140);
            btnDelete.Size = new Size(110, 40);
            btnDelete.Enabled = false;
            btnDelete.Click += btnDelete_Click;

            grpCategoryInfo.Controls.Add(lblCategoryName);
            grpCategoryInfo.Controls.Add(txtCategoryName);
            grpCategoryInfo.Controls.Add(lblDescription);
            grpCategoryInfo.Controls.Add(txtDescription);
            grpCategoryInfo.Controls.Add(btnAdd);
            grpCategoryInfo.Controls.Add(btnUpdate);
            grpCategoryInfo.Controls.Add(btnDelete);

            // ================= FORM =================
            ClientSize = new Size(980, 680);
            Controls.Add(pnlCenter);
            Controls.Add(pnlBottom);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 9F);
            Text = "Quản lý Danh mục";

            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategory).EndInit();
            pnlBottom.ResumeLayout(false);
            grpCategoryInfo.ResumeLayout(false);
            grpCategoryInfo.PerformLayout();
            ResumeLayout(false);
        }
    }
}
