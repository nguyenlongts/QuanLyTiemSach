using System;
using System.Windows.Forms;
using QuanLyTiemSach.Domain.Model;

namespace QuanLyTiemSach.BookFrms
{
    public partial class FormAddBook : Form
    {
        public Book Book { get; private set; }

        public FormAddBook()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out decimal price, out int categoryId))
                return;

            var book = new Book
            {
                BookID = txtId.Text.Trim(),
                Title = txtName.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                Price = price,
                CategoryId = categoryId
            };

            if (!book.IsValid(out string msg))
            {
                MessageBox.Show(msg, "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Book = book;
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool ValidateInput(out decimal price, out int categoryId)
        {
            price = 0;
            categoryId = 0;

            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Vui lòng nhập Book ID");
                txtId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sách");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Vui lòng nhập tác giả");
                txtAuthor.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out price) || price <= 0)
            {
                MessageBox.Show("Giá phải là số > 0");
                txtPrice.Focus();
                return false;
            }

            if (!int.TryParse(txtCategoryId.Text.Trim(), out categoryId) || categoryId <= 0)
            {
                MessageBox.Show("CategoryId không hợp lệ");
                txtCategoryId.Focus();
                return false;
            }

            return true;
        }
    }
}
