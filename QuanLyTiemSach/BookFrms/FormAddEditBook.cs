// ==================== FormAddEditBook.cs ====================
using System;
using System.Linq;
using System.Windows.Forms;
using QuanLyTiemSach.BLL.Services;
using QuanLyTiemSach.Domain.Model;



namespace QuanLyTiemSach
{
    public partial class FormAddEditBook : Form
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly Book _editingBook;
        private readonly bool _isEditMode;

        // Constructor cho Add mode
        public FormAddEditBook(IBookService bookService, ICategoryService categoryService)
        {
            InitializeComponent();
            _bookService = bookService;
            _categoryService = categoryService;
            _isEditMode = false;

            InitializeForm();
        }

        // Constructor cho Edit mode
        public FormAddEditBook(IBookService bookService, ICategoryService categoryService, Book book)
        {
            InitializeComponent();
            _bookService = bookService;
            _categoryService = categoryService;
            _editingBook = book;
            _isEditMode = true;

            InitializeForm();
            LoadBookData();
        }

        private void InitializeForm()
        {
            // Load categories vào ComboBox
            LoadCategories();

            // Cập nhật header
            if (_isEditMode)
            {
                lblHeader.Text = "✏️ Chỉnh sửa thông tin sách";
                txtBookId.Enabled = false; // Không cho sửa BookID
                txtBookId.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            }
            else
            {
                lblHeader.Text = "📚 Thêm sách mới";
            }
        }

        private void LoadCategories()
        {
            try
            {
                var categories = _categoryService.GetAllCategories();

                cboCategory.DataSource = categories;
                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "Id";
                cboCategory.SelectedIndex = -1; // Không chọn gì
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh mục: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            {
                numPublishedYear.Value = _editingBook.PublishedYear.Value;
            }

            numPrice.Value = _editingBook.Price;
            numQuantity.Value = _editingBook.Quantity;

            if (_editingBook.CategoryId > 0)
            {
                cboCategory.SelectedValue = _editingBook.CategoryId;
            }
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
                book.Publisher = string.IsNullOrWhiteSpace(txtPublisher.Text)
                    ? null
                    : txtPublisher.Text.Trim();
                book.PublishedYear = numPublishedYear.Value == numPublishedYear.Minimum
                    ? null
                    : (int?)numPublishedYear.Value;
                book.Price = numPrice.Value;
                book.Quantity = (int)numQuantity.Value;
                book.CategoryId = (int)cboCategory.SelectedValue;

                var (success, message) = _isEditMode
                    ? await _bookService.UpdateBookAsync(book)
                    : await _bookService.AddBookAsync(book);

                if (success)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            // BookID
            if (string.IsNullOrWhiteSpace(txtBookId.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sách!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBookId.Focus();
                return false;
            }

            // Title
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sách!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            // Author
            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Vui lòng nhập tác giả!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAuthor.Focus();
                return false;
            }

            // Price
            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Giá sách phải lớn hơn 0!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPrice.Focus();
                return false;
            }

            // Category
            if (cboCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn danh mục!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategory.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Validation real-time cho BookID
        private async void txtBookId_Leave(object sender, EventArgs e)
        {
            if (_isEditMode) return; // Không validate khi edit

            string bookId = txtBookId.Text.Trim();
            if (!string.IsNullOrEmpty(bookId))
            {
                if (await _bookService.IsBookIdExistsAsync(bookId))
                {
                    MessageBox.Show("Mã sách đã tồn tại!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBookId.Focus();
                    txtBookId.SelectAll();
                }
            }
        }
    }
}