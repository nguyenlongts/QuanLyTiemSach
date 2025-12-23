using QuanLyTiemSach.Domain.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTiemSach.OrderFrms
{
    public partial class FormViewOrderDetail : Form
    {
        private Order _order;

        public FormViewOrderDetail(Order order)
        {
            _order = order;
            InitializeComponent();
            BuildUI();
            LoadOrderDetails();
        }

        private void BuildUI()
        {
            // Header
            headerPanel = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.FromArgb(52, 152, 219) };
            lblHeader = new Label
            {
                Text = "📋 CHI TIẾT HÓA ĐƠN",
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            headerPanel.Controls.Add(lblHeader);

            // Info panel
            infoPanel = new Panel { Dock = DockStyle.Top, Height = 120, Padding = new Padding(20) };

            lblOrderId = new Label { Location = new Point(0, 0), AutoSize = true, Font = new Font("Segoe UI", 11, FontStyle.Bold) };
            lblOrderDate = new Label { Location = new Point(0, 30), AutoSize = true };
            lblCustomerName = new Label { Location = new Point(0, 55), AutoSize = true };
            lblCustomerPhone = new Label { Location = new Point(0, 80), AutoSize = true };

            infoPanel.Controls.AddRange(new Control[]
            {
                lblOrderId, lblOrderDate, lblCustomerName, lblCustomerPhone
            });

            // Grid
            dgvItems = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false
            };

            dgvItems.Columns.Add("BookID", "Mã sách");
            dgvItems.Columns.Add("BookTitle", "Tên sách");
            dgvItems.Columns.Add("UnitPrice", "Đơn giá");
            dgvItems.Columns.Add("Quantity", "Số lượng");
            dgvItems.Columns.Add("Total", "Thành tiền");

            dgvItems.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";
            dgvItems.Columns["Total"].DefaultCellStyle.Format = "N0";

            // Summary
            summaryPanel = new Panel { Dock = DockStyle.Bottom, Height = 100, Padding = new Padding(20) };

            lblTotalAmount = new Label
            {
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(231, 76, 60),
                Dock = DockStyle.Top,
                Height = 40
            };

            btnClose = new Button
            {
                Text = "Đóng",
                Width = 100,
                Height = 35,
                Dock = DockStyle.Right,
                DialogResult = DialogResult.OK
            };

            summaryPanel.Controls.AddRange(new Control[] { btnClose, lblTotalAmount });

            Controls.AddRange(new Control[]
            {
                dgvItems,
                summaryPanel,
                infoPanel,
                headerPanel
            });
        }

        private void LoadOrderDetails()
        {
            lblOrderId.Text = $"🆔 Mã hóa đơn: #{_order.Id}";
            lblOrderDate.Text = $"📅 Ngày đặt: {_order.OrderDate:dd/MM/yyyy HH:mm}";
            lblCustomerName.Text = $"👤 Khách hàng: {_order.Customer?.Name ?? "N/A"}";
            lblCustomerPhone.Text = $"📞 SĐT: {_order.Customer?.PhoneNumber ?? "N/A"}";

            dgvItems.Rows.Clear();
            foreach (var item in _order.OrderDetails)
            {
                dgvItems.Rows.Add(
                    item.BookID,
                    item.Book?.Title ?? "N/A",
                    item.UnitPrice,
                    item.Quantity,
                    item.UnitPrice * item.Quantity
                );
            }

            lblTotalAmount.Text = $"TỔNG TIỀN: {_order.TotalAmount:N0} đ";
        }
    }
}
