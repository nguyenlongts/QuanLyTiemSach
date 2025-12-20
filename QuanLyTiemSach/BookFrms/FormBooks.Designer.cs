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
        private DataGridView dgvBooks;
        private Panel panelSearch;
        private Panel panelButtons;
        private FlowLayoutPanel flowButtons;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private TextBox txtSearchBook;
        private Label lblSearch;
        private PictureBox picSearch;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
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
            dgvBooks = new DataGridView();
            panelSearch = new Panel();
            lblSearch = new Label();
            txtSearchBook = new TextBox();
            picSearch = new PictureBox();
            panelButtons = new Panel();
            flowButtons = new FlowLayoutPanel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();

            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSearch).BeginInit();
            panelSearch.SuspendLayout();
            panelButtons.SuspendLayout();
            flowButtons.SuspendLayout();
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
            lblHeader.Text = "📚 Quản lý Sách";
            lblHeader.Height = 35;

            // lblSubHeader
            lblSubHeader.Dock = DockStyle.Bottom;
            lblSubHeader.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblSubHeader.ForeColor = Color.FromArgb(127, 140, 141);
            lblSubHeader.Text = "Quản lý danh sách sách trong hệ thống";
            lblSubHeader.Height = 20;

            // ================== SEARCH PANEL ==================
            panelSearch.BackColor = Color.White;
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Height = 80;
            panelSearch.Padding = new Padding(30, 15, 30, 15);
            panelSearch.Controls.Add(txtSearchBook);
            panelSearch.Controls.Add(lblSearch);

            // lblSearch
            lblSearch.Text = "🔍 Tìm kiếm";
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.ForeColor = Color.FromArgb(52, 73, 94);
            lblSearch.Location = new Point(30, 15);
            lblSearch.AutoSize = true;

            // txtSearchBook
            txtSearchBook.Location = new Point(30, 40);
            txtSearchBook.Width = 300;
            txtSearchBook.Height = 35;
            txtSearchBook.Font = new Font("Segoe UI", 11F);
            txtSearchBook.BorderStyle = BorderStyle.FixedSingle;
            txtSearchBook.BackColor = Color.FromArgb(236, 240, 241);
            txtSearchBook.ForeColor = Color.FromArgb(44, 62, 80);
            txtSearchBook.KeyDown += txtSearchBook_KeyDown;

            // ================== BUTTON PANEL ==================
            panelButtons.BackColor = Color.White;
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Height = 70;
            panelButtons.Padding = new Padding(30, 15, 30, 15);
            panelButtons.Controls.Add(flowButtons);

            // flowButtons
            flowButtons.Dock = DockStyle.Left;
            flowButtons.AutoSize = true;
            flowButtons.WrapContents = false;
            flowButtons.Controls.Add(btnAdd);
            flowButtons.Controls.Add(btnEdit);
            flowButtons.Controls.Add(btnDelete);
            flowButtons.Controls.Add(btnRefresh);

            // ================== BUTTONS STYLE ==================
            void StyleButton(Button btn, string text, Color bgColor, string icon)
            {
                btn.Text = $" {icon} {text} ";
                btn.Size = new Size(120, 40);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = bgColor;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
                btn.Margin = new Padding(0, 0, 10, 0);

                // Hover effect
                Color originalColor = bgColor;
                btn.MouseEnter += (s, e) => {
                    btn.BackColor = ControlPaint.Light(originalColor, 0.1f);
                };
                btn.MouseLeave += (s, e) => {
                    btn.BackColor = originalColor;
                };
            }

            StyleButton(btnAdd, "Thêm", Color.FromArgb(46, 204, 113), "➕");
            StyleButton(btnEdit, "Sửa", Color.FromArgb(52, 152, 219), "✏️");
            StyleButton(btnDelete, "Xóa", Color.FromArgb(231, 76, 60), "🗑️");
            StyleButton(btnRefresh, "Làm mới", Color.FromArgb(149, 165, 166), "🔄");

            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;

            // ================== DATAGRIDVIEW ==================
            dgvBooks.Dock = DockStyle.Fill;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.BorderStyle = BorderStyle.None;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.ReadOnly = true;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.EnableHeadersVisualStyles = false;
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.MultiSelect = false;
            dgvBooks.ColumnHeadersHeight = 45;
            dgvBooks.RowTemplate.Height = 40;
            dgvBooks.Margin = new Padding(30);

            // Header Style
            headerStyle.BackColor = Color.FromArgb(41, 128, 185);
            headerStyle.ForeColor = Color.White;
            headerStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.Padding = new Padding(10, 0, 0, 0);
            dgvBooks.ColumnHeadersDefaultCellStyle = headerStyle;

            // Alternating Row Style
            alternatingStyle.BackColor = Color.FromArgb(245, 246, 250);
            dgvBooks.AlternatingRowsDefaultCellStyle = alternatingStyle;

            // Default Cell Style
            defaultStyle.BackColor = Color.White;
            defaultStyle.ForeColor = Color.FromArgb(52, 73, 94);
            defaultStyle.Font = new Font("Segoe UI", 10F);
            defaultStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            defaultStyle.SelectionForeColor = Color.White;
            defaultStyle.Padding = new Padding(10, 5, 10, 5);
            dgvBooks.DefaultCellStyle = defaultStyle;

            // ================== FORM ==================
            ClientSize = new Size(1000, 600);
            Controls.Add(dgvBooks);
            Controls.Add(panelButtons);
            Controls.Add(panelSearch);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.White;
            Padding = new Padding(0, 0, 0, 20);
            Text = "Quản lý sách";

            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSearch).EndInit();
            panelSearch.ResumeLayout(false);
            panelSearch.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            flowButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}