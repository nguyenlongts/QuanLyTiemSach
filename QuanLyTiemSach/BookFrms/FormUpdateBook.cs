using System;
using System.Windows.Forms;
using QuanLyTiemSach.Model;

namespace QuanLyTiemSach.BookFrms
{
    public partial class FormUpdateBook : Form
    {
        public Book Book { get; private set; }

        public FormUpdateBook(Book book)
        {
            InitializeComponent();
            txtId.Enabled = false;
            txtId.Text = book.BookID;
            txtName.Text = book.Title;
            txtAuthor.Text = book.Author;
            txtPrice.Text = book.Price.ToString();


            this.Book = book;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateBook(out string msg, out decimal price))
            {
                MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Book.Title = txtName.Text.Trim();
            Book.Author = txtAuthor.Text.Trim();
            Book.Price = price;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateBook(out string errorMessage, out decimal price)
        {
            errorMessage = string.Empty;
            price = 0;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorMessage = "Tên sách trống!";
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                errorMessage = "Chưa nhập tên tác giả!";
                txtAuthor.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out price) || price <=0)
            {
                errorMessage = "Giá không hợp l";
                txtPrice.Focus();
                return false;
            }
            return true;
        }

    }
}
