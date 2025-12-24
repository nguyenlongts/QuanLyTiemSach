using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTiemSach.OrderFrms
{
    partial class FormViewOrderDetail
    {
        private System.ComponentModel.IContainer components = null;

        private Panel headerPanel;
        private Label lblHeader;

        private GroupBox groupInfo;
        private Label lblOrderId;
        private Label lblOrderDate;
        private Label lblCustomerName;
        private Label lblCustomerPhone;

        private GroupBox groupItems;
        private DataGridView dgvItems;

        private GroupBox groupSummary;
        private Label lblTotalAmount;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            lblHeader = new Label();
            groupInfo = new GroupBox();
            lblOrderId = new Label();
            lblOrderDate = new Label();
            lblCustomerName = new Label();
            lblCustomerPhone = new Label();
            groupItems = new GroupBox();
            dgvItems = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            groupSummary = new GroupBox();
            btnExportPDF = new Button();
            lblTotalAmount = new Label();
            btnClose = new Button();
            headerPanel.SuspendLayout();
            groupInfo.SuspendLayout();
            groupItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            groupSummary.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(52, 152, 219);
            headerPanel.Controls.Add(lblHeader);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(900, 60);
            headerPanel.TabIndex = 3;
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(900, 60);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "📋 CHI TIẾT HÓA ĐƠN";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupInfo
            // 
            groupInfo.Controls.Add(lblOrderId);
            groupInfo.Controls.Add(lblOrderDate);
            groupInfo.Controls.Add(lblCustomerName);
            groupInfo.Controls.Add(lblCustomerPhone);
            groupInfo.Location = new Point(20, 80);
            groupInfo.Name = "groupInfo";
            groupInfo.Size = new Size(850, 130);
            groupInfo.TabIndex = 2;
            groupInfo.TabStop = false;
            groupInfo.Text = "Thông tin hóa đơn";
            // 
            // lblOrderId
            // 
            lblOrderId.AutoSize = true;
            lblOrderId.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblOrderId.Location = new Point(20, 30);
            lblOrderId.Name = "lblOrderId";
            lblOrderId.Size = new Size(96, 20);
            lblOrderId.TabIndex = 0;
            lblOrderId.Text = "Mã hóa đơn:";
            // 
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Location = new Point(20, 60);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(65, 15);
            lblOrderDate.TabIndex = 1;
            lblOrderDate.Text = "Ngày mua:";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(400, 30);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(73, 15);
            lblCustomerName.TabIndex = 2;
            lblCustomerName.Text = "Khách hàng:";
            // 
            // lblCustomerPhone
            // 
            lblCustomerPhone.AutoSize = true;
            lblCustomerPhone.Location = new Point(400, 60);
            lblCustomerPhone.Name = "lblCustomerPhone";
            lblCustomerPhone.Size = new Size(30, 15);
            lblCustomerPhone.TabIndex = 3;
            lblCustomerPhone.Text = "SĐT:";
            // 
            // groupItems
            // 
            groupItems.Controls.Add(dgvItems);
            groupItems.Location = new Point(20, 230);
            groupItems.Name = "groupItems";
            groupItems.Size = new Size(850, 280);
            groupItems.TabIndex = 1;
            groupItems.TabStop = false;
            groupItems.Text = "Danh sách sách";
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvItems.Location = new Point(15, 30);
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.Size = new Size(820, 230);
            dgvItems.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Mã sách";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Tên sách";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Đơn giá";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Số lượng";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Thành tiền";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // groupSummary
            // 
            groupSummary.Controls.Add(btnExportPDF);
            groupSummary.Controls.Add(lblTotalAmount);
            groupSummary.Controls.Add(btnClose);
            groupSummary.Location = new Point(20, 525);
            groupSummary.Name = "groupSummary";
            groupSummary.Size = new Size(850, 90);
            groupSummary.TabIndex = 0;
            groupSummary.TabStop = false;
            groupSummary.Text = "Thanh toán";
            // 
            // btnExportPDF
            // 
            btnExportPDF.DialogResult = DialogResult.OK;
            btnExportPDF.Location = new Point(744, 35);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(100, 30);
            btnExportPDF.TabIndex = 2;
            btnExportPDF.Text = "Xuất pdf";
            btnExportPDF.Click += btnExportPDF_Click;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.FromArgb(231, 76, 60);
            lblTotalAmount.Location = new Point(20, 35);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(151, 25);
            lblTotalAmount.TabIndex = 0;
            lblTotalAmount.Text = "TỔNG TIỀN: 0 đ";
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.OK;
            btnClose.Location = new Point(598, 35);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 30);
            btnClose.TabIndex = 1;
            btnClose.Text = "Đóng";
            btnClose.Click += btnClose_Click;
            // 
            // FormViewOrderDetail
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(900, 650);
            Controls.Add(groupSummary);
            Controls.Add(groupItems);
            Controls.Add(groupInfo);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormViewOrderDetail";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi Tiết Hóa Đơn";
            headerPanel.ResumeLayout(false);
            groupInfo.ResumeLayout(false);
            groupInfo.PerformLayout();
            groupItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            groupSummary.ResumeLayout(false);
            groupSummary.PerformLayout();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private Button btnExportPDF;
    }
}
