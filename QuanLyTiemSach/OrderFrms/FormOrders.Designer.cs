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
        private Panel panelFilter;
        private Label lblFromDate;
        private DateTimePicker dtpFromDate;
        private Label lblToDate;
        private DateTimePicker dtpToDate;
        private Button btnFilter;
        private Button btnClearFilter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            headerPanel = new Panel();
            lblHeader = new Label();
            panelFilter = new Panel();
            lblFromDate = new Label();
            dtpFromDate = new DateTimePicker();
            lblToDate = new Label();
            dtpToDate = new DateTimePicker();
            btnFilter = new Button();
            btnClearFilter = new Button();
            dgvOrders = new DataGridView();
            panelButtons = new Panel();
            flowButtons = new FlowLayoutPanel();
            btnAdd = new Button();
            btnViewDetail = new Button();
            btnDelete = new Button();
            headerPanel.SuspendLayout();
            panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
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
            lblHeader.Text = "Quản lý Hóa đơn";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelFilter
            // 
            panelFilter.BackColor = Color.FromArgb(236, 240, 241);
            panelFilter.Controls.Add(lblFromDate);
            panelFilter.Controls.Add(dtpFromDate);
            panelFilter.Controls.Add(lblToDate);
            panelFilter.Controls.Add(dtpToDate);
            panelFilter.Controls.Add(btnFilter);
            panelFilter.Controls.Add(btnClearFilter);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(0, 60);
            panelFilter.Name = "panelFilter";
            panelFilter.Padding = new Padding(20, 10, 20, 10);
            panelFilter.Size = new Size(800, 60);
            panelFilter.TabIndex = 3;
            // 
            // lblFromDate
            // 
            lblFromDate.AutoSize = true;
            lblFromDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFromDate.Location = new Point(20, 20);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(60, 15);
            lblFromDate.TabIndex = 0;
            lblFromDate.Text = "Từ ngày:";
            // 
            // dtpFromDate
            // 
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(85, 17);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(120, 23);
            dtpFromDate.TabIndex = 1;
            // 
            // lblToDate
            // 
            lblToDate.AutoSize = true;
            lblToDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblToDate.Location = new Point(220, 20);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(67, 15);
            lblToDate.TabIndex = 2;
            lblToDate.Text = "Đến ngày:";
            // 
            // dtpToDate
            // 
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(290, 17);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(120, 23);
            dtpToDate.TabIndex = 3;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(52, 152, 219);
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(430, 15);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(90, 28);
            btnFilter.TabIndex = 4;
            btnFilter.Text = "Lọc";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnClearFilter
            // 
            btnClearFilter.BackColor = Color.FromArgb(149, 165, 166);
            btnClearFilter.FlatStyle = FlatStyle.Flat;
            btnClearFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClearFilter.ForeColor = Color.White;
            btnClearFilter.Location = new Point(530, 15);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(90, 28);
            btnClearFilter.TabIndex = 5;
            btnClearFilter.Text = "Bỏ lọc";
            btnClearFilter.UseVisualStyleBackColor = false;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // dgvOrders
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 245, 245);
            dgvOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor = Color.White;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvOrders.Dock = DockStyle.Top;
            dgvOrders.EnableHeadersVisualStyles = false;
            dgvOrders.Location = new Point(0, 120);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowTemplate.Height = 35;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(800, 290);
            dgvOrders.TabIndex = 1;
            dgvOrders.RowHeadersVisible = false; dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.MultiSelect = false;

            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.White;
            panelButtons.Controls.Add(flowButtons);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 410);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(20, 10, 0, 10);
            panelButtons.Size = new Size(800, 78);
            panelButtons.TabIndex = 0;
            // 
            // flowButtons
            // 
            flowButtons.AutoSize = true;
            flowButtons.Controls.Add(btnAdd);
            flowButtons.Controls.Add(btnViewDetail);
            flowButtons.Controls.Add(btnDelete);
            flowButtons.Dock = DockStyle.Left;
            flowButtons.Location = new Point(20, 10);
            flowButtons.Name = "flowButtons";
            flowButtons.Size = new Size(318, 58);
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
            // btnViewDetail
            // 
            btnViewDetail.BackColor = Color.FromArgb(241, 196, 15);
            btnViewDetail.FlatStyle = FlatStyle.Flat;
            btnViewDetail.ForeColor = Color.White;
            btnViewDetail.Location = new Point(109, 3);
            btnViewDetail.Name = "btnViewDetail";
            btnViewDetail.Size = new Size(100, 35);
            btnViewDetail.TabIndex = 1;
            btnViewDetail.Text = "Xem chi tiết";
            btnViewDetail.UseVisualStyleBackColor = false;
            btnViewDetail.Click += btnViewDetail_Click;
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
            // FormOrders
            // 
            ClientSize = new Size(800, 500);
            Controls.Add(panelButtons);
            Controls.Add(dgvOrders);
            Controls.Add(panelFilter);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormOrders";
            Text = "Quản lý Hóa đơn";
            headerPanel.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            panelButtons.ResumeLayout(false);
            panelButtons.PerformLayout();
            flowButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}