using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    partial class FormBooks
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlTop;
        private Panel pnlCenter;
        private Panel pnlBottom;

        private Label lblTitle;
        private TextBox txtSearchBook;
        private Button btnSearch;
        private Button btnRefresh;

        private DataGridView dgvBooks;

        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            lblTitle = new Label();
            txtSearchBook = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();

            pnlCenter = new Panel();
            dgvBooks = new DataGridView();

            pnlBottom = new Panel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();

            // ================= TOP =================
            pnlTop.BackColor = Color.FromArgb(41, 128, 185);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Height = 100;

            lblTitle.Text = "QUẢN LÝ SÁCH";
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 10);
            lblTitle.AutoSize = true;

            txtSearchBook.Font = new Font("Segoe UI", 10F);
            txtSearchBook.Location = new Point(18, 55);
            txtSearchBook.Size = new Size(260, 30);

            btnSearch.Text = "Tìm kiếm";
            btnSearch.BackColor = Color.FromArgb(46, 204, 113);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(290, 55);
            btnSearch.Size = new Size(100, 30);
            btnSearch.Click += btnSearch_Click;

            btnRefresh.Text = "Làm mới";
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(400, 55);
            btnRefresh.Size = new Size(100, 30);

            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(txtSearchBook);
            pnlTop.Controls.Add(btnSearch);
            pnlTop.Controls.Add(btnRefresh);

            // ================= CENTER =================
            pnlCenter.Dock = DockStyle.Fill;
            pnlCenter.Padding = new Padding(10);

            dgvBooks.Dock = DockStyle.Fill;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.ReadOnly = true;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.RowHeadersVisible = false;

            pnlCenter.Controls.Add(dgvBooks);

            // ================= BOTTOM =================
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Height = 80;
            pnlBottom.BackColor = Color.FromArgb(236, 240, 241);

            btnAdd.Text = "Thêm";
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(30, 20);
            btnAdd.Size = new Size(110, 40);
            btnAdd.Click += BtnAdd_Click;

            btnEdit.Text = "Sửa";
            btnEdit.BackColor = Color.FromArgb(52, 152, 219);
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(150, 20);
            btnEdit.Size = new Size(110, 40);
            btnEdit.Click += BtnEdit_Click;

            btnDelete.Text = "Xóa";
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(270, 20);
            btnDelete.Size = new Size(110, 40);
            btnDelete.Click += BtnDelete_Click;

            pnlBottom.Controls.Add(btnAdd);
            pnlBottom.Controls.Add(btnEdit);
            pnlBottom.Controls.Add(btnDelete);

            // ================= FORM =================
            ClientSize = new Size(980, 680);
            Controls.Add(pnlCenter);
            Controls.Add(pnlBottom);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Text = "Quản lý Sách";
        }
    }
}
