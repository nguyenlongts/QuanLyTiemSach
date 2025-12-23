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
            this.headerPanel = new Panel();
            this.lblHeader = new Label();

            this.groupInfo = new GroupBox();
            this.lblOrderId = new Label();
            this.lblOrderDate = new Label();
            this.lblCustomerName = new Label();
            this.lblCustomerPhone = new Label();

            this.groupItems = new GroupBox();
            this.dgvItems = new DataGridView();

            this.groupSummary = new GroupBox();
            this.lblTotalAmount = new Label();
            this.btnClose = new Button();

            // ===== Form =====
            this.ClientSize = new Size(900, 650);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Chi Tiết Hóa Đơn";
            this.BackColor = Color.WhiteSmoke;

            // ===== Header =====
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Height = 60;
            this.headerPanel.BackColor = Color.FromArgb(52, 152, 219);

            this.lblHeader.Dock = DockStyle.Fill;
            this.lblHeader.Text = "📋 CHI TIẾT HÓA ĐƠN";
            this.lblHeader.ForeColor = Color.White;
            this.lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblHeader.TextAlign = ContentAlignment.MiddleCenter;

            this.headerPanel.Controls.Add(this.lblHeader);

            // ===== Order Info =====
            this.groupInfo.Text = "Thông tin hóa đơn";
            this.groupInfo.Location = new Point(20, 80);
            this.groupInfo.Size = new Size(850, 130);

            this.lblOrderId.Location = new Point(20, 30);
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblOrderId.Text = "Mã hóa đơn:";

            this.lblOrderDate.Location = new Point(20, 60);
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Text = "Ngày mua:";

            this.lblCustomerName.Location = new Point(400, 30);
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Text = "Khách hàng:";

            this.lblCustomerPhone.Location = new Point(400, 60);
            this.lblCustomerPhone.AutoSize = true;
            this.lblCustomerPhone.Text = "SĐT:";

            this.groupInfo.Controls.Add(this.lblOrderId);
            this.groupInfo.Controls.Add(this.lblOrderDate);
            this.groupInfo.Controls.Add(this.lblCustomerName);
            this.groupInfo.Controls.Add(this.lblCustomerPhone);

            // ===== Items =====
            this.groupItems.Text = "Danh sách sách";
            this.groupItems.Location = new Point(20, 230);
            this.groupItems.Size = new Size(850, 280);

            this.dgvItems.Location = new Point(15, 30);
            this.dgvItems.Size = new Size(820, 230);
            this.dgvItems.ReadOnly = true;
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvItems.Columns.Add("BookID", "Mã sách");
            this.dgvItems.Columns.Add("BookTitle", "Tên sách");
            this.dgvItems.Columns.Add("UnitPrice", "Đơn giá");
            this.dgvItems.Columns.Add("Quantity", "Số lượng");
            this.dgvItems.Columns.Add("Total", "Thành tiền");

            this.dgvItems.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";
            this.dgvItems.Columns["Total"].DefaultCellStyle.Format = "N0";
            this.dgvItems.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvItems.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.groupItems.Controls.Add(this.dgvItems);

            // ===== Summary =====
            this.groupSummary.Text = "Thanh toán";
            this.groupSummary.Location = new Point(20, 525);
            this.groupSummary.Size = new Size(850, 90);

            this.lblTotalAmount.Location = new Point(20, 35);
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTotalAmount.ForeColor = Color.FromArgb(231, 76, 60);
            this.lblTotalAmount.Text = "TỔNG TIỀN: 0 đ";

            this.btnClose.Text = "Đóng";
            this.btnClose.Size = new Size(100, 30);
            this.btnClose.Location = new Point(720, 35);
            this.btnClose.DialogResult = DialogResult.OK;

            this.groupSummary.Controls.Add(this.lblTotalAmount);
            this.groupSummary.Controls.Add(this.btnClose);

            // ===== Add Controls =====
            this.Controls.Add(this.groupSummary);
            this.Controls.Add(this.groupItems);
            this.Controls.Add(this.groupInfo);
            this.Controls.Add(this.headerPanel);
        }
    }
}
