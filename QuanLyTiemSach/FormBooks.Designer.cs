using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    partial class FormBooks
    {
        private System.ComponentModel.IContainer components = null;
        private Panel headerPanel;
        private Label lblHeader;
        private DataGridView dgvBooks;
        private Panel panelButtons;
        private FlowLayoutPanel flowButtons;
        private Button btnAdd, btnEdit, btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.headerPanel = new Panel();
            this.lblHeader = new Label();
            this.dgvBooks = new DataGridView();
            this.panelButtons = new Panel();
            this.flowButtons = new FlowLayoutPanel();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();

            this.SuspendLayout();


            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 60;
            headerPanel.BackColor = Color.FromArgb(52, 152, 219);

            lblHeader.Text = "Quản lý Sách";
            lblHeader.ForeColor = Color.White;
            lblHeader.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            lblHeader.Padding = new Padding(20, 0, 0, 0);

            headerPanel.Controls.Add(lblHeader);


            dgvBooks.Dock = DockStyle.Top;
            dgvBooks.Height = 350;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.EnableHeadersVisualStyles = false;
            dgvBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvBooks.RowTemplate.Height = 35;
            dgvBooks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvBooks.ReadOnly = true;


            panelButtons.Dock = DockStyle.Top;
            panelButtons.Height = 60;
            panelButtons.BackColor = Color.White;
            panelButtons.Padding = new Padding(20, 10, 0, 10);


            flowButtons.Dock = DockStyle.Left;
            flowButtons.FlowDirection = FlowDirection.LeftToRight;
            flowButtons.WrapContents = false;
            flowButtons.AutoSize = true;

            btnAdd.Text = "Thêm";
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Width = 100;
            btnAdd.Height = 35;
            btnAdd.Click += BtnAdd_Click;

            btnEdit.Text = "Sửa";
            btnEdit.BackColor = Color.FromArgb(241, 196, 15);
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Width = 100;
            btnEdit.Height = 35;
            btnEdit.Click += BtnEdit_Click;

            btnDelete.Text = "Xóa";
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Width = 100;
            btnDelete.Height = 35;
            btnDelete.Click += BtnDelete_Click;

            flowButtons.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete });
            panelButtons.Controls.Add(flowButtons);

            this.Text = "Quản lý sách";
            this.ClientSize = new Size(800, 500);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Controls.AddRange(new Control[] { panelButtons, dgvBooks, headerPanel });

            this.ResumeLayout(false);
        }
    }
}
