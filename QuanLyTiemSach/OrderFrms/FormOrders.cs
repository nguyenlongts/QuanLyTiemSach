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
        private bool isFilter;
        private List<Order> Orders = new();

        public FormOrders()
        {
            InitializeComponent();
            _orderService = ServiceDI.GetOrderService();
            _customerService = ServiceDI.GetCustomerService();
            InitializeDateTimePickers();
            InitializeGrid();
            _ = LoadOrdersAsync();
        }

        private void InitializeGrid()
        {
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.ReadOnly = true;
            dgvOrders.MultiSelect = false;
            dgvOrders.RowHeadersVisible = false;

            dgvOrders.Columns.Clear();

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 60
            });
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "OrderDate",
                HeaderText = "Ngày mua",
                DataPropertyName = "OrderDate",
                Width = 150
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CustomerName",
                HeaderText = "Khách hàng",
                DataPropertyName = "CustomerName",
                Width = 150
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CustomerPhone",
                HeaderText = "Số điện thoại",
                DataPropertyName = "CustomerPhone",
                Width = 120
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalAmount",
                HeaderText = "Tổng tiền",
                DataPropertyName = "TotalAmount",
                Width = 120,
                DefaultCellStyle = {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ItemCount",
                HeaderText = "Số mặt hàng",
                DataPropertyName = "ItemCount",
                Width = 100
            });

        }
        private async Task LoadOrdersAsync()
        {
            try
            {
                Orders = (await _orderService.GetAllOrdersAsync()).ToList();
                BindOrders(Orders);
                isFilter = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải hóa đơn: {ex.Message}");
            }
        }
        private void BindOrders(IEnumerable<Order> orders)
        {
            dgvOrders.DataSource = orders.Select(o => new
            {
                o.Id,
                OrderDate = o.OrderDate.ToString("dd/MM/yyyy HH:mm"),
                CustomerName = o.Customer?.Name ?? "N/A",
                CustomerPhone = o.Customer?.PhoneNumber ?? "N/A",
                o.TotalAmount,
                ItemCount = o.OrderDetails?.Count ?? 0
            }).ToList();

            UpdateStatusLabel();
        }

        private void InitializeDateTimePickers()
        {
            dtpFromDate.Value = DateTime.Now.AddMonths(-1);
            dtpToDate.Value = DateTime.Now;
        }

        private void UpdateStatusLabel()
        {
            lblHeader.Text = $"Quản lý Hóa đơn - Tổng: {Orders.Count}";
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime from = dtpFromDate.Value.Date;
            DateTime to = dtpToDate.Value.Date.AddDays(1).AddTicks(-1);

            if (from > to)
            {
                MessageBox.Show("Ngày bắt đầu không hợp lệ");
                return;
            }

            isFilter = true;

            var filtered = Orders
                .Where(o => o.OrderDate >= from && o.OrderDate <= to)
                .ToList();

            BindOrders(filtered);
        }


        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            InitializeDateTimePickers();
            isFilter = false;
            BindOrders(Orders);
        }

        private async void BtnAdd_Click(object sender, EventArgs e)
        {
            var orderDetailForm = new FormOrderDetail(_orderService, _customerService);
            if (orderDetailForm.ShowDialog() == DialogResult.OK)
            {
                await LoadOrdersAsync();
                MessageBox.Show("Thêm hóa đơn thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (dgvOrders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xóa!");
                return;
            }

            int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["Id"].Value);

            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa hóa đơn #{orderId}'?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            await _orderService.DeleteOrderAsync(orderId);
            await LoadOrdersAsync();

            MessageBox.Show("Xóa hóa đơn thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}