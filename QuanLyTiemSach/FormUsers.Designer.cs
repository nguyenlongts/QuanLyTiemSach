using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    partial class FormUsers
    {
        private System.ComponentModel.IContainer components = null;
        private Panel headerPanel;
        private Label lblHeader;
        private DataGridView dgvUsers;
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
            this.dgvUsers = new DataGridView();
            this.panelButtons = new Panel();
            this.flowButtons = new FlowLayoutPanel();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();

            this.SuspendLayout();


            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 60;
            headerPanel.BackColor = Color.FromArgb(52, 152, 219);

            lblHeader.Text = "Quản lý Người dùng";
            lblHeader.ForeColor = Color.White;
            lblHeader.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            lblHeader.Padding = new Padding(20, 0, 0, 0);
            headerPanel.Controls.Add(lblHeader);

            dgvUsers.Dock = DockStyle.Top;
            dgvUsers.Height = 350;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvUsers.RowTemplate.Height = 35;
            dgvUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvUsers.ReadOnly = true;

  
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
            btnAdd.Width = 100; btnAdd.Height = 35;
            btnAdd.Click += BtnAdd_Click;

            btnEdit.Text = "Sửa";
            btnEdit.BackColor = Color.FromArgb(241, 196, 15);
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Width = 100; btnEdit.Height = 35;
            btnEdit.Click += BtnEdit_Click;

            btnDelete.Text = "Xóa";
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Width = 100; btnDelete.Height = 35;
            btnDelete.Click += BtnDelete_Click;

            flowButtons.Controls.AddRange(new Control[] { btnAdd, btnEdit, btnDelete });
            panelButtons.Controls.Add(flowButtons);

            this.Text = "Quản lý Người dùng";
            this.ClientSize = new Size(800, 500);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Controls.AddRange(new Control[] { panelButtons, dgvUsers, headerPanel });

            this.ResumeLayout(false);
        }
    }
}
