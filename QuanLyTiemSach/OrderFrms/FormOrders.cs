//using QuanLyTiemSach.BLL.Services.Interfaces;
//using QuanLyTiemSach.Domain.Model;
//using QuanLyTiemSach.OrderFrms;
//using System;
//using System.Linq;
//using System.Windows.Forms;

//namespace QuanLyTiemSach.APP
//{
//    public partial class FormOrders : Form
//    {
//        private readonly IOrderService _orderService;
//        private readonly ICustomerService _customerService;

//        public FormOrders()
//        {
//            InitializeComponent();
//            _orderService = ServiceDI.GetOrderService();
//            _customerService = ServiceDI.GetCustomerService();
//            LoadOrders();
//        }

//        private async void LoadOrders()
//        {
//            try
//            {
//                dgvOrders.Rows.Clear();
//                dgvOrders.Columns.Clear();
//                dgvOrders.Columns.Add("Id", "ID");
//                dgvOrders.Columns.Add("OrderDate", "Ngày mua");
//                dgvOrders.Columns.Add("CustomerName", "Khách hàng");
//                dgvOrders.Columns.Add("CustomerPhone", "Số điện thoại");
//                dgvOrders.Columns.Add("TotalAmount", "Tổng tiền");
//                dgvOrders.Columns.Add("ItemCount", "Số mặt hàng");


//                dgvOrders.Columns["Id"].Width = 60;
//                dgvOrders.Columns["OrderDate"].Width = 150;
//                dgvOrders.Columns["CustomerName"].Width = 150;
//                dgvOrders.Columns["CustomerPhone"].Width = 120;
//                dgvOrders.Columns["TotalAmount"].Width = 120;
//                dgvOrders.Columns["ItemCount"].Width = 100;

//                dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
//                dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


//                var orders = await _orderService.GetAllOrdersAsync();

//                foreach (var order in orders)
//                {
//                    dgvOrders.Rows.Add(
//                        order.Id,
//                        order.OrderDate.ToString("dd/MM/yyyy HH:mm"),
//                        order.Customer?.Name ?? "N/A",
//                        order.Customer?.PhoneNumber ?? "N/A",
//                        order.TotalAmount,
//                        order.OrderDetails?.Count ?? 0
//                    );
//                }

//                UpdateStatusLabel();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}",
//                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void UpdateStatusLabel()
//        {
//            int totalOrders = dgvOrders.Rows.Count;
//            lblHeader.Text = $"Quản lý Hóa đơn: Hiện có ({totalOrders-1} hóa đơn)";
//        }

//        private async void BtnAdd_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                var orderDetailForm = new FormOrderDetail(_orderService, _customerService);
//                if (orderDetailForm.ShowDialog() == DialogResult.OK)
//                {
//                    LoadOrders();
//                    MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo",
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Lỗi khi thêm hóa đơn: {ex.Message}",
//                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private async void btnViewDetail_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (dgvOrders.SelectedRows.Count == 0)
//                {
//                    MessageBox.Show("Vui lòng chọn hóa đơn cần xem chi tiết!",
//                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Id"].Value);
//                var order = await _orderService.GetOrderByIdAsync(orderId);

//                var viewForm = new FormViewOrderDetail(order);
//                viewForm.ShowDialog();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Lỗi khi xem chi tiết hóa đơn: {ex.Message}",
//                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private async void BtnDelete_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                if (dgvOrders.SelectedRows.Count == 0)
//                {
//                    MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!",
//                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Id"].Value);
//                string customerName = dgvOrders.SelectedRows[0].Cells["CustomerName"].Value?.ToString();

//                var result = MessageBox.Show(
//                    $"Bạn có chắc chắn muốn xóa hóa đơn #{orderId} của khách hàng '{customerName}'?\n\n" +
//                    "Lưu ý: Số lượng sách sẽ được hoàn lại vào kho.",
//                    "Xác nhận xóa",
//                    MessageBoxButtons.YesNo,
//                    MessageBoxIcon.Question);

//                if (result == DialogResult.Yes)
//                {
//                    await _orderService.DeleteOrderAsync(orderId);
//                    LoadOrders();
//                    MessageBox.Show("Xóa hóa đơn thành công!\nSố lượng sách đã được hoàn lại vào kho.",
//                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Lỗi khi xóa hóa đơn: {ex.Message}",
//                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }
//    }
//}

using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.Domain.Model;
using QuanLyTiemSach.OrderFrms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyTiemSach.APP
{
    public partial class FormOrders : Form
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private bool _isFiltering = false;

        public FormOrders()
        {
            InitializeComponent();
            _orderService = ServiceDI.GetOrderService();
            _customerService = ServiceDI.GetCustomerService();
            InitializeDateTimePickers();
            LoadOrders();
        }

        private void InitializeDateTimePickers()
        {
            // Đặt ngày mặc định
            dtpFromDate.Value = DateTime.Now.AddMonths(-1); // 1 tháng trước
            dtpToDate.Value = DateTime.Now; // Hôm nay
        }

        private async void LoadOrders()
        {
            try
            {
                dgvOrders.Rows.Clear();
                dgvOrders.Columns.Clear();
                dgvOrders.Columns.Add("Id", "ID");
                dgvOrders.Columns.Add("OrderDate", "Ngày mua");
                dgvOrders.Columns.Add("CustomerName", "Khách hàng");
                dgvOrders.Columns.Add("CustomerPhone", "Số điện thoại");
                dgvOrders.Columns.Add("TotalAmount", "Tổng tiền");
                dgvOrders.Columns.Add("ItemCount", "Số mặt hàng");

                dgvOrders.Columns["Id"].Width = 60;
                dgvOrders.Columns["OrderDate"].Width = 150;
                dgvOrders.Columns["CustomerName"].Width = 150;
                dgvOrders.Columns["CustomerPhone"].Width = 120;
                dgvOrders.Columns["TotalAmount"].Width = 120;
                dgvOrders.Columns["ItemCount"].Width = 100;

                dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
                dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                var orders = await _orderService.GetAllOrdersAsync();

                foreach (var order in orders)
                {
                    dgvOrders.Rows.Add(
                        order.Id,
                        order.OrderDate.ToString("dd/MM/yyyy HH:mm"),
                        order.Customer?.Name ?? "N/A",
                        order.Customer?.PhoneNumber ?? "N/A",
                        order.TotalAmount,
                        order.OrderDetails?.Count ?? 0
                    );
                }

                UpdateStatusLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadOrdersByDateRange(DateTime fromDate, DateTime toDate)
        {
            try
            {
                dgvOrders.Rows.Clear();
                dgvOrders.Columns.Clear();
                dgvOrders.Columns.Add("Id", "ID");
                dgvOrders.Columns.Add("OrderDate", "Ngày mua");
                dgvOrders.Columns.Add("CustomerName", "Khách hàng");
                dgvOrders.Columns.Add("CustomerPhone", "Số điện thoại");
                dgvOrders.Columns.Add("TotalAmount", "Tổng tiền");
                dgvOrders.Columns.Add("ItemCount", "Số mặt hàng");

                dgvOrders.Columns["Id"].Width = 60;
                dgvOrders.Columns["OrderDate"].Width = 150;
                dgvOrders.Columns["CustomerName"].Width = 150;
                dgvOrders.Columns["CustomerPhone"].Width = 120;
                dgvOrders.Columns["TotalAmount"].Width = 120;
                dgvOrders.Columns["ItemCount"].Width = 100;

                dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Format = "N0";
                dgvOrders.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                var orders = await _orderService.GetOrdersByDateRangeAsync(fromDate, toDate);

                foreach (var order in orders)
                {
                    dgvOrders.Rows.Add(
                        order.Id,
                        order.OrderDate.ToString("dd/MM/yyyy HH:mm"),
                        order.Customer?.Name ?? "N/A",
                        order.Customer?.PhoneNumber ?? "N/A",
                        order.TotalAmount,
                        order.OrderDetails?.Count ?? 0
                    );
                }

                UpdateStatusLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc hóa đơn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatusLabel()
        {
            int totalOrders = dgvOrders.Rows.Count;
            string filterText = _isFiltering ? " (đã lọc)" : "";
            lblHeader.Text = $"Quản lý Hóa đơn: Hiện có {totalOrders} hóa đơn{filterText}";
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                if (fromDate > toDate)
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _isFiltering = true;
                LoadOrdersByDateRange(fromDate, toDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lọc: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            try
            {
                _isFiltering = false;
                InitializeDateTimePickers();
                LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi bỏ lọc: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var orderDetailForm = new FormOrderDetail(_orderService, _customerService);
                if (orderDetailForm.ShowDialog() == DialogResult.OK)
                {
                    if (_isFiltering)
                    {
                        LoadOrdersByDateRange(dtpFromDate.Value.Date, dtpToDate.Value.Date);
                    }
                    else
                    {
                        LoadOrders();
                    }
                    MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm hóa đơn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnViewDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrders.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn cần xem chi tiết!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Id"].Value);
                var order = await _orderService.GetOrderByIdAsync(orderId);

                var viewForm = new FormViewOrderDetail(order);
                viewForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem chi tiết hóa đơn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOrders.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Id"].Value);
                string customerName = dgvOrders.SelectedRows[0].Cells["CustomerName"].Value?.ToString();

                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa hóa đơn #{orderId} của khách hàng '{customerName}'?\n\n" +
                    "Lưu ý: Số lượng sách sẽ được hoàn lại vào kho.",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _orderService.DeleteOrderAsync(orderId);

                    if (_isFiltering)
                    {
                        LoadOrdersByDateRange(dtpFromDate.Value.Date, dtpToDate.Value.Date);
                    }
                    else
                    {
                        LoadOrders();
                    }

                    MessageBox.Show("Xóa hóa đơn thành công!\nSố lượng sách đã được hoàn lại vào kho.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa hóa đơn: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}