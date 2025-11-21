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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
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
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(52, 152, 219);
            headerPanel.Controls.Add(lblHeader);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(800, 60);
            headerPanel.TabIndex = 2;
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Padding = new Padding(20, 0, 0, 0);
            lblHeader.Size = new Size(800, 60);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Quản lý Sách";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvBooks
            // 
            dataGridViewCellStyle3.BackColor = Color.FromArgb(245, 245, 245);
            dgvBooks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.BackgroundColor = Color.White;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvBooks.ColumnHeadersHeight = 29;
            dgvBooks.Dock = DockStyle.Top;
            dgvBooks.EnableHeadersVisualStyles = false;
            dgvBooks.Location = new Point(0, 60);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.RowTemplate.Height = 35;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(800, 350);
            dgvBooks.TabIndex = 1;
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(label1);
            panelButtons.Controls.Add(txtSearchBook);
            panelButtons.Controls.Add(flowButtons);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 410);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(20, 10, 0, 10);
            panelButtons.Size = new Size(800, 60);
            panelButtons.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(632, 3);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 2;
            label1.Text = "Tìm kiếm:";
            label1.Click += label1_Click;
            // 
            // txtSearchBook
            // 
            txtSearchBook.Location = new Point(632, 33);
            txtSearchBook.Name = "txtSearchBook";
            txtSearchBook.Size = new Size(126, 27);
            txtSearchBook.TabIndex = 1;
            txtSearchBook.KeyDown += txtSearchBook_KeyDown;
            // 
            // flowButtons
            // 
            flowButtons.AutoSize = true;
            flowButtons.Controls.Add(btnAdd);
            flowButtons.Controls.Add(btnEdit);
            flowButtons.Controls.Add(btnDelete);
            flowButtons.Dock = DockStyle.Left;
            flowButtons.Location = new Point(20, 10);
            flowButtons.Name = "flowButtons";
            flowButtons.Size = new Size(318, 40);
            flowButtons.TabIndex = 0;
            flowButtons.WrapContents = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(3, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 35);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(241, 196, 15);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(109, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 35);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(215, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 35);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += BtnDelete_Click;
            // 
            // FormBooks
            // 
            ClientSize = new Size(800, 500);
            Controls.Add(panelButtons);
            Controls.Add(dgvBooks);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormBooks";
            Text = "Quản lý sách";
            headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            flowButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TextBox txtSearchBook;
        private Label label1;
    }
}
