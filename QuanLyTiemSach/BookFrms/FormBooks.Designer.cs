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
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private TextBox txtSearchBook;
        private Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();

            headerPanel = new Panel();
            lblHeader = new Label();
            dgvBooks = new DataGridView();
            panelButtons = new Panel();
            label1 = new Label();
            txtSearchBook = new TextBox();
            flowButtons = new FlowLayoutPanel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();

            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            panelButtons.SuspendLayout();
            flowButtons.SuspendLayout();
            SuspendLayout();

            // headerPanel
            headerPanel.BackColor = Color.FromArgb(52, 152, 219);
            headerPanel.Controls.Add(lblHeader);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Size = new Size(800, 60);

            // lblHeader
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Padding = new Padding(20, 0, 0, 0);
            lblHeader.Text = "Quản lý Sách";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;

            // dgvBooks
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dgvBooks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.Dock = DockStyle.Top;
            dgvBooks.Height = 350;
            dgvBooks.ReadOnly = true;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.EnableHeadersVisualStyles = false;

            dataGridViewCellStyle2.BackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;

            // panelButtons
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Height = 60;
            panelButtons.Padding = new Padding(20, 10, 0, 10);
            panelButtons.Controls.Add(label1);
            panelButtons.Controls.Add(txtSearchBook);
            panelButtons.Controls.Add(flowButtons);

            // label1
            label1.Text = "Tìm kiếm:";
            label1.Location = new Point(620, 5);

            // txtSearchBook
            txtSearchBook.Location = new Point(620, 30);
            txtSearchBook.Width = 150;
            txtSearchBook.KeyDown += txtSearchBook_KeyDown;

            // flowButtons
            flowButtons.Controls.Add(btnAdd);
            flowButtons.Controls.Add(btnEdit);
            flowButtons.Controls.Add(btnDelete);
            flowButtons.Dock = DockStyle.Left;

            // btnAdd
            btnAdd.Text = "Thêm";
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.ForeColor = Color.White;
            btnAdd.Click += BtnAdd_Click;

            // btnEdit
            btnEdit.Text = "Sửa";
            btnEdit.BackColor = Color.FromArgb(241, 196, 15);
            btnEdit.ForeColor = Color.White;
            btnEdit.Click += BtnEdit_Click;

            // btnDelete
            btnDelete.Text = "Xóa";
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.ForeColor = Color.White;
            btnDelete.Click += BtnDelete_Click;

            // FormBooks
            ClientSize = new Size(800, 500);
            Controls.Add(panelButtons);
            Controls.Add(dgvBooks);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            Text = "Quản lý sách";

            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            flowButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
