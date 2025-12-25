namespace QuanLyTiemSach
{
    partial class FormCategory
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSubHeader;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.DataGridView dgvCategory;
        private System.Windows.Forms.Panel panelBottom;
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
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle alternatingStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle defaultStyle = new DataGridViewCellStyle();

            headerPanel = new Panel();
            lblHeader = new Label();
            lblSubHeader = new Label();
            panelSearch = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();
            panelCenter = new Panel();
            dgvCategory = new DataGridView();
            panelBottom = new Panel();
            grpCategoryInfo = new GroupBox();
            lblCategoryName = new Label();
            txtCategoryName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();

            headerPanel.SuspendLayout();
            panelSearch.SuspendLayout();
            panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).BeginInit();
            panelBottom.SuspendLayout();
            grpCategoryInfo.SuspendLayout();
            SuspendLayout();

            // ================== HEADER PANEL ==================
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(lblSubHeader);
            headerPanel.Controls.Add(lblHeader);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 90;
            headerPanel.Padding = new Padding(30, 20, 30, 10);

            // lblHeader
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(44, 62, 80);
            lblHeader.Text = "📂 Quản lý Danh mục";
            lblHeader.Height = 35;

            // lblSubHeader
            lblSubHeader.Dock = DockStyle.Bottom;
            lblSubHeader.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblSubHeader.ForeColor = Color.FromArgb(127, 140, 141);
            lblSubHeader.Text = "Quản lý các danh mục sách trong hệ thống";
            lblSubHeader.Height = 20;

            // ================== SEARCH PANEL ==================
            panelSearch.BackColor = Color.White;
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Height = 80;
            panelSearch.Padding = new Padding(30, 15, 30, 15);
            panelSearch.Controls.Add(btnRefresh);
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(lblSearch);

            // lblSearch
            lblSearch.Text = "🔍 Tìm kiếm";
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(52, 73, 94);
            lblSearch.Location = new Point(30, 15);
            lblSearch.AutoSize = true;

            // txtSearch
            txtSearch.Location = new Point(30, 40);
            txtSearch.Width = 300;
            txtSearch.Height = 35;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.BackColor = Color.FromArgb(236, 240, 241);
            txtSearch.ForeColor = Color.FromArgb(44, 62, 80);

            // btnSearch
            btnSearch.Location = new Point(340, 40);
            btnSearch.Size = new Size(100, 35);
            btnSearch.Text = "🔍 Tìm";
            btnSearch.BackColor = Color.FromArgb(46, 204, 113);
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.Cursor = Cursors.Hand;

            // btnRefresh
            btnRefresh.Location = new Point(450, 40);
            btnRefresh.Size = new Size(120, 35);
            btnRefresh.Text = "🔄 Làm mới";
            btnRefresh.BackColor = Color.FromArgb(149, 165, 166);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.Cursor = Cursors.Hand;

            // ================== CENTER PANEL ==================
            panelCenter.Controls.Add(dgvCategory);
            panelCenter.Dock = DockStyle.Fill;
            panelCenter.Padding = new Padding(30, 0, 30, 0);
            panelCenter.BackColor = Color.White;

            // ================== DATAGRIDVIEW ==================
            dgvCategory.Dock = DockStyle.Fill;
            dgvCategory.BackgroundColor = Color.White;
            dgvCategory.BorderStyle = BorderStyle.None;
            dgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategory.ReadOnly = true;
            dgvCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategory.EnableHeadersVisualStyles = false;
            dgvCategory.AllowUserToAddRows = false;
            dgvCategory.AllowUserToDeleteRows = false;
            dgvCategory.RowHeadersVisible = false;
            dgvCategory.MultiSelect = false;
            dgvCategory.ColumnHeadersHeight = 45;
            dgvCategory.RowTemplate.Height = 40;

            // Header Style
            headerStyle.BackColor = Color.FromArgb(41, 128, 185);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.Padding = new Padding(10, 0, 0, 0);
            dgvCategory.ColumnHeadersDefaultCellStyle = headerStyle;

            // Alternating Row Style
            alternatingStyle.BackColor = Color.FromArgb(245, 246, 250);
            dgvCategory.AlternatingRowsDefaultCellStyle = alternatingStyle;

            // Default Cell Style
            defaultStyle.BackColor = Color.White;
            defaultStyle.ForeColor = Color.FromArgb(52, 73, 94);
            defaultStyle.Font = new Font("Segoe UI", 10F);
            defaultStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            defaultStyle.SelectionForeColor = Color.White;
            defaultStyle.Padding = new Padding(10, 5, 10, 5);
            dgvCategory.DefaultCellStyle = defaultStyle;

            // ================== BOTTOM PANEL ==================
            panelBottom.BackColor = Color.FromArgb(236, 240, 241);
            panelBottom.Controls.Add(grpCategoryInfo);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Height = 220;
            panelBottom.Padding = new Padding(30, 15, 30, 15);

            // ================== GROUP BOX ==================
            grpCategoryInfo.Dock = DockStyle.Fill;
            grpCategoryInfo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpCategoryInfo.ForeColor = Color.FromArgb(52, 73, 94);
            grpCategoryInfo.Text = "📝 Thông tin danh mục";
            grpCategoryInfo.BackColor = Color.White;
            grpCategoryInfo.Controls.Add(lblCategoryName);
            grpCategoryInfo.Controls.Add(txtCategoryName);
            grpCategoryInfo.Controls.Add(lblDescription);
            grpCategoryInfo.Controls.Add(txtDescription);
            grpCategoryInfo.Controls.Add(btnAdd);
            grpCategoryInfo.Controls.Add(btnUpdate);
            grpCategoryInfo.Controls.Add(btnDelete);

            // lblCategoryName
            lblCategoryName.AutoSize = true;
            lblCategoryName.Font = new Font("Segoe UI", 10F);
            lblCategoryName.ForeColor = Color.FromArgb(52, 73, 94);
            lblCategoryName.Location = new Point(30, 40);
            lblCategoryName.Text = "Tên danh mục:";

            // txtCategoryName
            txtCategoryName.Location = new Point(30, 65);
            txtCategoryName.Width = 300;
            txtCategoryName.Height = 35;
            txtCategoryName.Font = new Font("Segoe UI", 10F);
            txtCategoryName.BorderStyle = BorderStyle.FixedSingle;

            // lblDescription
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.ForeColor = Color.FromArgb(52, 73, 94);
            lblDescription.Location = new Point(360, 40);
            lblDescription.Text = "Mô tả:";

            // txtDescription
            txtDescription.Location = new Point(360, 65);
            txtDescription.Width = 300;
            txtDescription.Height = 35;
            txtDescription.Font = new Font("Segoe UI", 10F);
            txtDescription.BorderStyle = BorderStyle.FixedSingle;

            // ================== BUTTONS ==================
            void StyleButton(Button btn, string text, Color bgColor, string icon, Point location)
            {
                btn.Text = $" {icon} {text} ";
                btn.Size = new Size(130, 45);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = bgColor;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
                btn.Location = location;

                Color originalColor = bgColor;
                btn.MouseEnter += (s, e) => {
                    btn.BackColor = ControlPaint.Light(originalColor, 0.1f);
                };
                btn.MouseLeave += (s, e) => {
                    btn.BackColor = originalColor;
                };
            }

            StyleButton(btnAdd, "Thêm", Color.FromArgb(46, 204, 113), "➕", new Point(30, 130));
            StyleButton(btnUpdate, "Cập nhật", Color.FromArgb(52, 152, 219), "✏️", new Point(170, 130));
            StyleButton(btnDelete, "Xóa", Color.FromArgb(231, 76, 60), "🗑️", new Point(310, 130));

            btnAdd.Click += btnAddCategoryMain_Click;
            btnUpdate.Click += btnEditCategoryMain_Click;
            btnDelete.Click += btnDelete_Click;

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            // ================== FORM ==================
            ClientSize = new Size(1000, 700);
            Controls.Add(panelCenter);
            Controls.Add(panelBottom);
            Controls.Add(panelSearch);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.White;
            Text = "Quản lý Danh mục";

            headerPanel.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategory).EndInit();
            panelBottom.ResumeLayout(false);
            grpCategoryInfo.ResumeLayout(false);
            grpCategoryInfo.PerformLayout();
            ResumeLayout(false);
        }
    }
}