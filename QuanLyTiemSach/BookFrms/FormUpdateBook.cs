using System;
using System.Windows.Forms;
using QuanLyTiemSach.Domain.Model;
using QuanLyTiemSach.BLL.Services;

namespace QuanLyTiemSach.BookFrms
{
    public partial class FormUpdateBook : Form
    {
        private readonly BookService _bookService;
        private Book _book;

        public FormUpdateBook(Book book)
        {
            InitializeComponent();

            _bookService = new BookService();
            _book = book;

            // Bind data
            txtId.Text = book.BookID;
            txtName.Text = book.Title;
            txtAuthor.Text = book.Author;
            txtPrice.Text = book.Price.ToString();

            txtId.ReadOnly = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateBook(out string msg, out decimal price))
            {
                MessageBox.Show(msg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update entity
            _book.Title = txtName.Text.Trim();
            _book.Author = txtAuthor.Text.Trim();
            _book.Price = price;

            try
            {
                _bookService.Update(_book);
                MessageBox.Show("Cập nhật sách thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sách:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateBook(out string errorMessage, out decimal price)
        {
            errorMessage = string.Empty;
            price = 0;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorMessage = "Tên sách không được để trống!";
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                errorMessage = "Tác giả không được để trống!";
                txtAuthor.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out price) || price <= 0)
            {
                errorMessage = "Giá sách phải là số dương!";
                txtPrice.Focus();
                return false;
            }

            return true;
        }
    }
}
