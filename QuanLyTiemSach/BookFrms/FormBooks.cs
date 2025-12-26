using Microsoft.Extensions.DependencyInjection;
using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    public partial class FormBooks : Form
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private string _selectedBookId = string.Empty;

        public FormBooks(IBookService bookService)
        {
            InitializeComponent();
            _bookService = bookService;
            _categoryService = ServiceDI.GetCategoryService();

            SetupEvents();
            LoadData();
            ApplyStyles();
        }

        private void SetupEvents()
        {
            dgvBooks.CellClick += dgvBooks_CellClick;
            dgvBooks.DataBindingComplete += dgvBooks_DataBindingComplete;
            btnRefresh.Click += btnRefresh_Click;
            txtSearchBook.KeyDown += txtSearchBook_KeyDown;
        }

        private void dgvBooks_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvBooks.Columns.Count == 0) return;

            if (dgvBooks.Columns.Contains("BookID"))
            {
                dgvBooks.Columns["BookID"].HeaderText = "Mã sách";
                dgvBooks.Columns["BookID"].FillWeight = 12;
                dgvBooks.Columns["BookID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvBooks.Columns.Contains("Title"))
            {
                dgvBooks.Columns["Title"].HeaderText = "Tên sách";
                dgvBooks.Columns["Title"].FillWeight = 25;
            }

            if (dgvBooks.Columns.Contains("Author"))
            {
                dgvBooks.Columns["Author"].HeaderText = "Tác giả";
                dgvBooks.Columns["Author"].FillWeight = 18;
            }

            if (dgvBooks.Columns.Contains("Publisher"))
            {
                dgvBooks.Columns["Publisher"].HeaderText = "NXB";
                dgvBooks.Columns["Publisher"].FillWeight = 15;
            }

            if (dgvBooks.Columns.Contains("PublishedYear"))
            {
                dgvBooks.Columns["PublishedYear"].HeaderText = "Năm XB";
                dgvBooks.Columns["PublishedYear"].FillWeight = 10;
                dgvBooks.Columns["PublishedYear"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvBooks.Columns.Contains("Price"))
            {
                dgvBooks.Columns["Price"].HeaderText = "Giá";
                dgvBooks.Columns["Price"].FillWeight = 12;
                dgvBooks.Columns["Price"].DefaultCellStyle.Format = "N0";
                dgvBooks.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvBooks.Columns.Contains("Quantity"))
            {
                dgvBooks.Columns["Quantity"].HeaderText = "Số lượng";
                dgvBooks.Columns["Quantity"].FillWeight = 10;
                dgvBooks.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvBooks.Columns.Contains("CategoryId"))
            {
                dgvBooks.Columns["CategoryId"].Visible = false;
            }

            string[] hiddenColumns = { "Category", "OrderDetails", "TotalValue", "isActive", "IsAvailable" };
            foreach (var colName in hiddenColumns)
            {
                if (dgvBooks.Columns.Contains(colName))
                {
                    dgvBooks.Columns[colName].Visible = false;
                }
            }
        }

        private async void LoadData()
        {
            try
            {
                var books = await _bookService.GetAllBooksAsync();

                dgvBooks.DataSource = null;
                dgvBooks.DataSource = books;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var formAddBook = new FormAddEditBook(_bookService, _categoryService);

                if (formAddBook.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    MessageBox.Show("Thêm sách thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_selectedBookId))
                {
                    MessageBox.Show("Vui lòng chọn sách cần sửa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var book = await _bookService.GetBookByIdAsync(_selectedBookId);
                if (book == null)
                {
                    MessageBox.Show("Không tìm thấy sách!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var formEditBook = new FormAddEditBook(_bookService, _categoryService, book);

                if (formEditBook.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                    MessageBox.Show("Cập nhật sách thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_selectedBookId))
                {
                    MessageBox.Show("Vui lòng chọn sách cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var book = await _bookService.GetBookByIdAsync(_selectedBookId);
                if (book == null)
                {
                    MessageBox.Show("Không tìm thấy sách!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirm = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa sách này?\n\n" +
                    $"Mã: {book.BookID}\n" +
                    $"Tên: {book.Title}\n" +
                    $"Tác giả: {book.Author}",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    await _bookService.DeleteBookAsync(_selectedBookId);

                    MessageBox.Show("Xóa sách thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _selectedBookId = string.Empty;
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchBook.Clear();
            _selectedBookId = string.Empty;
            LoadData();
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvBooks.Rows.Count)
                {
                    DataGridViewRow row = dgvBooks.Rows[e.RowIndex];

                    if (row.Cells["BookID"].Value != null)
                    {
                        _selectedBookId = row.Cells["BookID"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn dòng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchBook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchBooks();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private async void SearchBooks()
        {
            try
            {
                string keyword = txtSearchBook.Text.Trim();
                var books = await _bookService.SearchBooksAsync(keyword);

                dgvBooks.DataSource = null;
                dgvBooks.DataSource = books;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            dgvBooks.CellClick -= dgvBooks_CellClick;
            dgvBooks.DataBindingComplete -= dgvBooks_DataBindingComplete;
            btnRefresh.Click -= btnRefresh_Click;
            txtSearchBook.KeyDown -= txtSearchBook_KeyDown;

            base.OnFormClosing(e);
        }
        private void ApplyStyles()
        {
            lblTitle.Text = "📚 Quản lý Sách";
            txtSearchBook.Text = "🔍 Tìm kiếm";

            StyleButton(btnAdd, "Thêm", Color.FromArgb(46, 204, 113), "➕");
            StyleButton(btnEdit, "Sửa", Color.FromArgb(52, 152, 219), "✏️");
            StyleButton(btnDelete, "Xóa", Color.FromArgb(231, 76, 60), "🗑️");
            StyleButton(btnRefresh, "Làm mới", Color.FromArgb(149, 165, 166), "🔄");
        }

        private void StyleButton(Button btn, string text, Color color, string icon)
        {
            btn.Text = $"{icon} {text}";
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            var origin = color;
            btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(origin);
            btn.MouseLeave += (s, e) => btn.BackColor = origin;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

