using System;
using System.Windows.Forms;
using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.Domain.Model;

namespace QuanLyTiemSach
{
    public partial class FormAddEditBook : Form
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly Book _editingBook;
        private readonly bool _isEditMode;

        public FormAddEditBook(
            IBookService bookService,
            ICategoryService categoryService)
        {
            InitializeComponent();
            _bookService = bookService;
            _categoryService = categoryService;
            _isEditMode = false;

            InitializeForm();
        }

        public FormAddEditBook(
            IBookService bookService,
            ICategoryService categoryService,
            Book book)
        {
            InitializeComponent();
            _bookService = bookService;
            _categoryService = categoryService;
            _editingBook = book;
            _isEditMode = true;

            InitializeForm();
            LoadBookData();
        }

        private async void InitializeForm()
        {
            await LoadCategoriesAsync();

            if (_isEditMode)
            {
                lblHeader.Text = "Chỉnh sửa thông tin sách";
                txtBookId.Enabled = false;
                txtBookId.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            }
            else
            {
                lblHeader.Text = "Thêm sách mới";
            }
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();

                cboCategory.DataSource = categories;
                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "Id";
                cboCategory.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khi tải danh mục:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadBookData()
        {
            if (_editingBook == null) return;

            txtBookId.Text = _editingBook.BookID;
            txtTitle.Text = _editingBook.Title;
            txtAuthor.Text = _editingBook.Author;
            txtPublisher.Text = _editingBook.Publisher ?? "";

            if (_editingBook.PublishedYear.HasValue)
                numPublishedYear.Value = _editingBook.PublishedYear.Value;

            numPrice.Value = _editingBook.Price;
            numQuantity.Value = _editingBook.Quantity;
            cboCategory.SelectedValue = _editingBook.CategoryId;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                    return;

                var book = _isEditMode ? _editingBook : new Book();

                book.BookID = txtBookId.Text.Trim();
                book.Title = txtTitle.Text.Trim();
                book.Author = txtAuthor.Text.Trim();
                book.Publisher =txtPublisher.Text.Trim();
                book.PublishedYear = numPublishedYear.Value == numPublishedYear.Minimum ? null : (int?)numPublishedYear.Value;
                book.Price = numPrice.Value;
                book.Quantity = (int)numQuantity.Value;
                book.CategoryId = (int)cboCategory.SelectedValue;

                if (_isEditMode)
                    await _bookService.UpdateBookAsync(book);
                else
                    await _bookService.AddBookAsync(book);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private async void txtBookId_Leave(object sender, EventArgs e)
        {
            if (_isEditMode) return;

            try
            {
                string bookId = txtBookId.Text.Trim();
                if (!string.IsNullOrEmpty(bookId))
                {
                    if (await _bookService.IsBookIdExistsAsync(bookId))
                    {
                        MessageBox.Show(
                            "Mã sách đã tồn tại!",
                            "Cảnh báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        txtBookId.Focus();
                        txtBookId.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtBookId.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sách!", "Lỗi", MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtBookId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Vui lòng nhập tác giả!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAuthor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPublisher.Text))
            {
                MessageBox.Show("Vui lòng nhập nhà xuất bản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAuthor.Focus();
                return false;
            }

            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Giá sách phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numPrice.Focus();
                return false;
            }

            if (cboCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn danh mục!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboCategory.Focus();
                return false;
            }

            return true;
        }
    }
}
