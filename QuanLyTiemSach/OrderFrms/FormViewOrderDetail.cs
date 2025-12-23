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
            LoadOrderDetails();
        }

        private void LoadOrderDetails()
        {
            lblOrderId.Text = $"Mã hóa đơn: #{_order.Id}";
            lblOrderDate.Text = $"Ngày mua: {_order.OrderDate:dd/MM/yyyy HH:mm}";
            lblCustomerName.Text = $"Khách hàng: {_order.Customer?.Name ?? "N/A"}";
            lblCustomerPhone.Text = $"SĐT: {_order.Customer?.PhoneNumber ?? "N/A"}";

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
