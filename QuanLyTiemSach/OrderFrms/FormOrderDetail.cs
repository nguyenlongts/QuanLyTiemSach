using QuanLyTiemSach.BLL.Services;
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

        //private void InitializeComponent()
        //{
        //    this.Size = new Size(900, 700);
        //    this.Text = "Tạo Hóa Đơn Mới";
        //    this.StartPosition = FormStartPosition.CenterParent;
        //    this.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    this.MaximizeBox = false;
        //    this.MinimizeBox = false;

        //    headerPanel = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.FromArgb(52, 152, 219) };
        //    lblHeader = new Label
        //    {
        //        Text = "📋 TẠO HÓA ĐƠN MỚI",
        //        Dock = DockStyle.Fill,
        //        ForeColor = Color.White,
        //        Font = new Font("Segoe UI", 16, FontStyle.Bold),
        //        TextAlign = ContentAlignment.MiddleCenter
        //    };
        //    headerPanel.Controls.Add(lblHeader);

        //    customerPanel = new Panel { Dock = DockStyle.Top, Height = 140, BackColor = Color.White, Padding = new Padding(20) };

        //    lblCustomerName = new Label { Text = "Tên khách hàng:", Location = new Point(0, 0), AutoSize = true };
        //    txtCustomerName = new TextBox { Location = new Point(0, 25), Width = 250, Font = new Font("Segoe UI", 10) };

        //    lblCustomerPhone = new Label { Text = "Số điện thoại:", Location = new Point(270, 0), AutoSize = true };
        //    txtCustomerPhone = new TextBox { Location = new Point(270, 25), Width = 200, Font = new Font("Segoe UI", 10) };

        //    btnSearchCustomer = new Button
        //    {
        //        Text = "🔍 Tìm",
        //        Location = new Point(480, 23),
        //        Width = 80,
        //        Height = 28,
        //        BackColor = Color.FromArgb(52, 152, 219),
        //        ForeColor = Color.White,
        //        FlatStyle = FlatStyle.Flat,
        //        Cursor = Cursors.Hand
        //    };
        //    btnSearchCustomer.Click += BtnSearchCustomer_Click;

        //    lblCustomerAddress = new Label { Text = "Địa chỉ:", Location = new Point(0, 60), AutoSize = true };
        //    txtCustomerAddress = new TextBox { Location = new Point(0, 85), Width = 560, Font = new Font("Segoe UI", 10) };

        //    customerPanel.Controls.AddRange(new Control[] {
        //        lblCustomerName, txtCustomerName,
        //        lblCustomerPhone, txtCustomerPhone, btnSearchCustomer,
        //        lblCustomerAddress, txtCustomerAddress
        //    });

        //    // Items Panel
        //    itemsPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20, 10, 20, 10), BackColor = Color.FromArgb(236, 240, 241) };

        //    var itemsHeader = new Panel { Dock = DockStyle.Top, Height = 40, BackColor = Color.White };
        //    var lblItems = new Label { Text = "Danh sách sản phẩm:", Dock = DockStyle.Left, AutoSize = true, Padding = new Padding(10) };
        //    btnAddItem = new Button
        //    {
        //        Text = "+ Thêm sản phẩm",
        //        Dock = DockStyle.Right,
        //        Width = 140,
        //        BackColor = Color.FromArgb(46, 204, 113),
        //        ForeColor = Color.White,
        //        FlatStyle = FlatStyle.Flat,
        //        Cursor = Cursors.Hand
        //    };
        //    btnAddItem.Click += BtnAddItem_Click;

        //    btnRemoveItem = new Button
        //    {
        //        Text = "− Xóa",
        //        Dock = DockStyle.Right,
        //        Width = 80,
        //        BackColor = Color.FromArgb(231, 76, 60),
        //        ForeColor = Color.White,
        //        FlatStyle = FlatStyle.Flat,
        //        Cursor = Cursors.Hand
        //    };
        //    btnRemoveItem.Click += BtnRemoveItem_Click;

        //    itemsHeader.Controls.AddRange(new Control[] { lblItems, btnRemoveItem, btnAddItem });

        //    dgvItems = new DataGridView
        //    {
        //        Dock = DockStyle.Fill,
        //        BackgroundColor = Color.White,
        //        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        //        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        //        AllowUserToAddRows = false,
        //        ReadOnly = true
        //    };

        //    itemsPanel.Controls.AddRange(new Control[] { dgvItems, itemsHeader });

        //    // Summary Panel
        //    summaryPanel = new Panel { Dock = DockStyle.Bottom, Height = 100, BackColor = Color.White, Padding = new Padding(20) };

        //    lblTotalAmount = new Label
        //    {
        //        Text = "TỔNG TIỀN: 0 đ",
        //        Font = new Font("Segoe UI", 14, FontStyle.Bold),
        //        ForeColor = Color.FromArgb(231, 76, 60),
        //        Dock = DockStyle.Top,
        //        Height = 40
        //    };

        //    var buttonPanel = new FlowLayoutPanel
        //    {
        //        Dock = DockStyle.Bottom,
        //        Height = 40,
        //        FlowDirection = FlowDirection.RightToLeft,
        //        AutoSize = false
        //    };

        //    btnCancel = new Button
        //    {
        //        Text = "Hủy",
        //        Width = 100,
        //        Height = 35,
        //        BackColor = Color.FromArgb(149, 165, 166),
        //        ForeColor = Color.White,
        //        FlatStyle = FlatStyle.Flat,
        //        Cursor = Cursors.Hand,
        //        DialogResult = DialogResult.Cancel
        //    };

        //    btnSave = new Button
        //    {
        //        Text = "💾 Lưu hóa đơn",
        //        Width = 130,
        //        Height = 35,
        //        BackColor = Color.FromArgb(46, 204, 113),
        //        ForeColor = Color.White,
        //        FlatStyle = FlatStyle.Flat,
        //        Cursor = Cursors.Hand
        //    };
        //    btnSave.Click += BtnSave_Click;

        //    buttonPanel.Controls.AddRange(new Control[] { btnCancel, btnSave });
        //    summaryPanel.Controls.AddRange(new Control[] { buttonPanel, lblTotalAmount });

        //    // Add all to form
        //    this.Controls.AddRange(new Control[] { itemsPanel, summaryPanel, customerPanel, headerPanel });
        //}

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

        private async void BtnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                var books = await _bookService.GetAllBooksAsync();
                var selectForm = new FormSelectBook(books.Where(b => b.Quantity > 0).ToList());

                if (selectForm.ShowDialog() == DialogResult.OK)
                {
                    var selectedBook = selectForm.SelectedBook;
                    int quantity = selectForm.Quantity;

                    // Check if book already in list
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
                            Book = selectedBook,
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

        private void BtnRemoveItem_Click(object sender, EventArgs e)
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

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate customer info
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

                // Find or create customer
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

                // Create order
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
    }
}