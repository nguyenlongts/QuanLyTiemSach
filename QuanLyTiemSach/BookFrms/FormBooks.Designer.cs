using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    partial class FormBooks
    {
        private System.ComponentModel.IContainer components = null;

        private Panel headerPanel;
        private Label lblHeader;
        private Label lblSubHeader;

        private Panel panelSearch;
        private Label lblSearch;
        private TextBox txtSearchBook;

        private Panel panelButtons;
        private FlowLayoutPanel flowButtons;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;

        private DataGridView dgvBooks;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            lblSubHeader = new Label();
            lblHeader = new Label();
            panelSearch = new Panel();
            lblSearch = new Label();
            txtSearchBook = new TextBox();
            panelButtons = new Panel();
            flowButtons = new FlowLayoutPanel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            dgvBooks = new DataGridView();
            btnSearch = new Button();
            headerPanel.SuspendLayout();
            panelSearch.SuspendLayout();
            panelButtons.SuspendLayout();
            flowButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(lblSubHeader);
            headerPanel.Controls.Add(lblHeader);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(30, 20, 30, 10);
            headerPanel.Size = new Size(1000, 90);
            headerPanel.TabIndex = 3;
            // 
            // lblSubHeader
            // 
            lblSubHeader.Dock = DockStyle.Bottom;
            lblSubHeader.Font = new Font("Segoe UI", 9F);
            lblSubHeader.ForeColor = Color.FromArgb(127, 140, 141);
            lblSubHeader.Location = new Point(30, 60);
            lblSubHeader.Name = "lblSubHeader";
            lblSubHeader.Size = new Size(940, 20);
            lblSubHeader.TabIndex = 0;
            lblSubHeader.Text = "Quản lý sách trong cửa hàng";
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(44, 62, 80);
            lblHeader.Location = new Point(30, 20);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(940, 35);
            lblHeader.TabIndex = 1;
            lblHeader.Text = "Quản lý sách";
            // 
            // panelSearch
            // 
            panelSearch.BackColor = Color.White;
            panelSearch.Controls.Add(btnSearch);
            panelSearch.Controls.Add(lblSearch);
            panelSearch.Controls.Add(txtSearchBook);
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Location = new Point(0, 90);
            panelSearch.Name = "panelSearch";
            panelSearch.Padding = new Padding(30, 15, 30, 15);
            panelSearch.Size = new Size(1000, 80);
            panelSearch.TabIndex = 2;
            // 
            // lblSearch
            // 
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(52, 73, 94);
            lblSearch.Location = new Point(30, 15);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(100, 23);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm";
            // 
            // txtSearchBook
            // 
            txtSearchBook.Location = new Point(30, 40);
            txtSearchBook.Name = "txtSearchBook";
            txtSearchBook.Size = new Size(300, 23);
            txtSearchBook.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(flowButtons);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 170);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(30, 15, 30, 15);
            panelButtons.Size = new Size(1000, 70);
            panelButtons.TabIndex = 1;
            // 
            // flowButtons
            // 
            flowButtons.AutoSize = true;
            flowButtons.Controls.Add(btnAdd);
            flowButtons.Controls.Add(btnEdit);
            flowButtons.Controls.Add(btnDelete);
            flowButtons.Controls.Add(btnRefresh);
            flowButtons.Dock = DockStyle.Left;
            flowButtons.Location = new Point(30, 15);
            flowButtons.Name = "flowButtons";
            flowButtons.Size = new Size(504, 40);
            flowButtons.TabIndex = 0;
            flowButtons.WrapContents = false;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(3, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(120, 40);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(129, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(120, 40);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Sửa";
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(255, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(120, 40);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xoá";
            btnDelete.Click += BtnDelete_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(381, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 40);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.Dock = DockStyle.Fill;
            dgvBooks.Location = new Point(0, 240);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(1000, 360);
            dgvBooks.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(346, 40);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(120, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.Click += btnSearch_Click;
            // 
            // FormBooks
            // 
            BackColor = Color.White;
            ClientSize = new Size(1000, 600);
            Controls.Add(dgvBooks);
            Controls.Add(panelButtons);
            Controls.Add(panelSearch);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormBooks";
            Text = "Quản lý sách";
            headerPanel.ResumeLayout(false);
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            flowButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
        }

        private Button btnSearch;
    }
}
