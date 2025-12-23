using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTiemSach.APP
{
    partial class FormOrders
    {
        private System.ComponentModel.IContainer components = null;
        private Panel headerPanel;
        private Label lblHeader;
        private DataGridView dgvOrders;
        private Panel panelButtons;
        private FlowLayoutPanel flowButtons;
        private Button btnAdd, btnViewDetail, btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.headerPanel = new Panel();
            this.lblHeader = new Label();
            this.dgvOrders = new DataGridView();
            this.panelButtons = new Panel();
            this.flowButtons = new FlowLayoutPanel();
            this.btnAdd = new Button();
            this.btnViewDetail = new Button();
            this.btnDelete = new Button();

            this.SuspendLayout();

       
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 60;
            headerPanel.BackColor = Color.FromArgb(52, 152, 219);

            lblHeader.Text = "Quản lý Hóa đơn";
            lblHeader.ForeColor = Color.White;
            lblHeader.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            lblHeader.Padding = new Padding(20, 0, 0, 0);
            headerPanel.Controls.Add(lblHeader);

            dgvOrders.Dock = DockStyle.Top;
            dgvOrders.Height = 350;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor = Color.White;
            dgvOrders.EnableHeadersVisualStyles = false;
            dgvOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(41, 128, 185);
            dgvOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvOrders.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvOrders.RowTemplate.Height = 35;
            dgvOrders.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvOrders.ReadOnly = true;


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

            btnViewDetail.Text = "Xem chi tiết hoá đơn";
            btnViewDetail.BackColor = Color.FromArgb(241, 196, 15);
            btnViewDetail.ForeColor = Color.White;
            btnViewDetail.FlatStyle = FlatStyle.Flat;
            btnViewDetail.Width = 100; btnViewDetail.Height = 35;
            btnViewDetail.Click += btnViewDetail_Click;

            btnDelete.Text = "Xóa";
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Width = 100; btnDelete.Height = 35;
            btnDelete.Click += BtnDelete_Click;

            flowButtons.Controls.AddRange(new Control[] { btnAdd, btnViewDetail, btnDelete });
            panelButtons.Controls.Add(flowButtons);


            this.Text = "Quản lý Hóa đơn";
            this.ClientSize = new Size(800, 500);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Controls.AddRange(new Control[] { panelButtons, dgvOrders, headerPanel });

            this.ResumeLayout(false);
        }
    }
}
