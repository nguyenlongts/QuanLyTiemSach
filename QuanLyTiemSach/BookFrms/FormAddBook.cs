using System;
using System.Windows.Forms;
using System.Xml.Linq;
using QuanLyTiemSach.Model;
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
            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price))
            {
                MessageBox.Show("Giá phải là số hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var book = new Book
            {
                BookID = txtId.Text.Trim(),
                Title = txtName.Text.Trim(),
                Author = txtAuthor.Text.Trim(),
                Price = price
            };

            if (!book.IsValid(out string msg))
            {
                MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Book = book;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}