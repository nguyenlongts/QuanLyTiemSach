using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.Domain.Model;
using QuanLyTiemSach.OrderFrms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyTiemSach.OrderFrms
{
    public partial class FormOrderDetail : Form
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IBookService _bookService;
        private List<OrderDetail> _orderDetails = new List<OrderDetail>();

        public FormOrderDetail(IOrderService orderService, ICustomerService customerService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _bookService = ServiceDI.GetBookService();
            InitializeComponent();
            LoadItemsGrid();
        }

        private void LoadItemsGrid()
        {
            dgvItems.Columns.Clear();
            dgvItems.Columns.Add("BookID", "Mã sách");
            dgvItems.Columns.Add("BookTitle", "Tên sách");
            dgvItems.Columns.Add("UnitPrice", "Đơn giá");
            dgvItems.Columns.Add("Quantity", "Số lượng");
            dgvItems.Columns.Add("Total", "Thành tiền");

            dgvItems.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";
            dgvItems.Columns["Total"].DefaultCellStyle.Format = "N0";
            dgvItems.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvItems.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvItems.EnableHeadersVisualStyles = false;
            dgvItems.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvItems.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvItems.ColumnHeadersHeight = 35;

            dgvItems.RowTemplate.Height = 32;
            dgvItems.Font = new Font("Segoe UI", 10);
            dgvItems.GridColor = Color.LightGray;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.MultiSelect = false;
            dgvItems.ReadOnly = true;

        }

        private async void BtnSearchCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string phone = txtCustomerPhone.Text.Trim();
                if (string.IsNullOrEmpty(phone))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var customer = await _customerService.GetCustomerByPhoneNumberAsync(phone);
                if (customer != null)
                {
                    txtCustomerName.Text = customer.Name;
                    txtCustomerAddress.Text = customer.Address;
                    MessageBox.Show("Đã tìm thấy khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng. Vui lòng nhập thông tin mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshItemsGrid()
        {
            dgvItems.Rows.Clear();
            decimal total = 0;

            foreach (var item in _orderDetails)
            {
                decimal itemTotal = item.UnitPrice * item.Quantity;
                total += itemTotal;

                dgvItems.Rows.Add(
                    item.BookID,
                    item.Book?.Title ?? "N/A",
                    item.UnitPrice,
                    item.Quantity,
                    itemTotal
                );
            }

            lblTotalAmount.Text = $"TỔNG TIỀN: {total:N0} đ";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCustomerPhone.Text))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_orderDetails.Count == 0)
                {
                    MessageBox.Show("Vui lòng thêm ít nhất một sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var customer = await _customerService.GetCustomerByPhoneNumberAsync(txtCustomerPhone.Text.Trim());
                if (customer == null)
                {
                    customer = await _customerService.CreateCustomerAsync(new Customer
                    {
                        Name = txtCustomerName.Text.Trim(),
                        PhoneNumber = txtCustomerPhone.Text.Trim(),
                        Address = txtCustomerAddress.Text.Trim()
                    });
                }

                var order = new Order
                {
                    OrderDate = DateTime.Now,
                    CustomerId = customer.Id
                };

                await _orderService.CreateOrderAsync(order, _orderDetails);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                var books = await _bookService.GetAllBooksAsync();
                var selectForm = new FormSelectBook(books.Where(b => b.Quantity > 0).ToList());

                if (selectForm.ShowDialog() == DialogResult.OK)
                {
                    var selectedBook = selectForm.SelectedBook;
                    int quantity = selectForm.Quantity;
                    var existing = _orderDetails.FirstOrDefault(od => od.BookID == selectedBook.BookID);
                    if (existing != null)
                    {
                        existing.Quantity += quantity;
                    }
                    else
                    {
                        _orderDetails.Add(new OrderDetail
                        {
                            BookID = selectedBook.BookID,
                            Quantity = quantity,
                            UnitPrice = selectedBook.Price
                        });
                    }

                    RefreshItemsGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRemoveBook_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string bookId = dgvItems.SelectedRows[0].Cells["BookID"].Value?.ToString();
            _orderDetails.RemoveAll(od => od.BookID == bookId);
            RefreshItemsGrid();
        }

    }
}