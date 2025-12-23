using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTiemSach.OrderFrms
{
    partial class FormOrderDetail
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblHeader;

        private GroupBox groupCustomer;
        private Label lblName;
        private TextBox txtCustomerName;
        private Label lblPhone;
        private TextBox txtCustomerPhone;
        private Label lblAddress;
        private TextBox txtCustomerAddress;
        private Button btnSearchCustomer;

        private GroupBox groupItems;
        private Button btnAddBook;
        private Button btnRemoveBook;
        private DataGridView dgvItems;

        private GroupBox groupSummary;
        private Label lblTotalAmount;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblHeader = new Label();
            groupCustomer = new GroupBox();
            lblName = new Label();
            txtCustomerName = new TextBox();
            lblPhone = new Label();
            txtCustomerPhone = new TextBox();
            btnSearchCustomer = new Button();
            lblAddress = new Label();
            txtCustomerAddress = new TextBox();
            groupItems = new GroupBox();
            btnAddBook = new Button();
            btnRemoveBook = new Button();
            dgvItems = new DataGridView();
            groupSummary = new GroupBox();
            lblTotalAmount = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            panelHeader.SuspendLayout();
            groupCustomer.SuspendLayout();
            groupItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            groupSummary.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(52, 152, 219);
            panelHeader.Controls.Add(lblHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(900, 60);
            panelHeader.TabIndex = 3;
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
            lblHeader.Text = "📋 TẠO HÓA ĐƠN MỚI";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupCustomer
            // 
            groupCustomer.Controls.Add(lblName);
            groupCustomer.Controls.Add(txtCustomerName);
            groupCustomer.Controls.Add(lblPhone);
            groupCustomer.Controls.Add(txtCustomerPhone);
            groupCustomer.Controls.Add(btnSearchCustomer);
            groupCustomer.Controls.Add(lblAddress);
            groupCustomer.Controls.Add(txtCustomerAddress);
            groupCustomer.Location = new Point(20, 80);
            groupCustomer.Name = "groupCustomer";
            groupCustomer.Size = new Size(850, 140);
            groupCustomer.TabIndex = 2;
            groupCustomer.TabStop = false;
            groupCustomer.Text = "Thông tin khách hàng";
            // 
            // lblName
            // 
            lblName.Location = new Point(20, 30);
            lblName.Name = "lblName";
            lblName.Size = new Size(54, 23);
            lblName.TabIndex = 0;
            lblName.Text = "Tên KH:";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(80, 27);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(220, 23);
            txtCustomerName.TabIndex = 1;
            // 
            // lblPhone
            // 
            lblPhone.Location = new Point(320, 30);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(34, 23);
            lblPhone.TabIndex = 2;
            lblPhone.Text = "SĐT:";
            // 
            // txtCustomerPhone
            // 
            txtCustomerPhone.Location = new Point(360, 27);
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.Size = new Size(160, 23);
            txtCustomerPhone.TabIndex = 3;
            // 
            // btnSearchCustomer
            // 
            btnSearchCustomer.Location = new Point(540, 26);
            btnSearchCustomer.Name = "btnSearchCustomer";
            btnSearchCustomer.Size = new Size(75, 25);
            btnSearchCustomer.TabIndex = 4;
            btnSearchCustomer.Text = "Tìm";
            // 
            // lblAddress
            // 
            lblAddress.Location = new Point(20, 67);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(54, 23);
            lblAddress.TabIndex = 5;
            lblAddress.Text = "Địa chỉ:";
            // 
            // txtCustomerAddress
            // 
            txtCustomerAddress.Location = new Point(80, 67);
            txtCustomerAddress.Name = "txtCustomerAddress";
            txtCustomerAddress.Size = new Size(650, 23);
            txtCustomerAddress.TabIndex = 6;
            // 
            // groupItems
            // 
            groupItems.Controls.Add(btnAddBook);
            groupItems.Controls.Add(btnRemoveBook);
            groupItems.Controls.Add(dgvItems);
            groupItems.Location = new Point(20, 240);
            groupItems.Name = "groupItems";
            groupItems.Size = new Size(850, 300);
            groupItems.TabIndex = 1;
            groupItems.TabStop = false;
            groupItems.Text = "Danh sách sách";
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(20, 30);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(110, 25);
            btnAddBook.TabIndex = 0;
            btnAddBook.Text = "➕ Thêm sách";
            btnAddBook.Click += btnAddBook_Click;
            // 
            // btnRemoveBook
            // 
            btnRemoveBook.Location = new Point(140, 30);
            btnRemoveBook.Name = "btnRemoveBook";
            btnRemoveBook.Size = new Size(110, 25);
            btnRemoveBook.TabIndex = 1;
            btnRemoveBook.Text = "❌ Xóa sách";
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.Location = new Point(20, 65);
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.Size = new Size(810, 215);
            dgvItems.TabIndex = 2;
            // 
            // groupSummary
            // 
            groupSummary.Controls.Add(lblTotalAmount);
            groupSummary.Controls.Add(btnSave);
            groupSummary.Controls.Add(btnCancel);
            groupSummary.Location = new Point(20, 560);
            groupSummary.Name = "groupSummary";
            groupSummary.Size = new Size(850, 100);
            groupSummary.TabIndex = 0;
            groupSummary.TabStop = false;
            groupSummary.Text = "Thanh toán";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalAmount.Location = new Point(20, 35);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(300, 30);
            lblTotalAmount.TabIndex = 0;
            lblTotalAmount.Text = "TỔNG TIỀN: 0 đ";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(600, 35);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 1;
            btnSave.Text = "💾 Lưu";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(720, 35);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Hủy";
            // 
            // FormOrderDetail
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(900, 700);
            Controls.Add(groupSummary);
            Controls.Add(groupItems);
            Controls.Add(groupCustomer);
            Controls.Add(panelHeader);
            Name = "FormOrderDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo Hóa Đơn Mới";
            panelHeader.ResumeLayout(false);
            groupCustomer.ResumeLayout(false);
            groupCustomer.PerformLayout();
            groupItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            groupSummary.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
