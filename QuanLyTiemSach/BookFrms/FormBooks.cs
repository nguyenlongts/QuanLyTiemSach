using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLyTiemSach.BLL.Services;
using QuanLyTiemSach.Domain.Model;
using QuanLyTiemSach.BookFrms;

namespace QuanLyTiemSach
{
    public partial class FormBooks : Form
    {
        private readonly BookService _bookService;

        public FormBooks()
        {
            InitializeComponent();
            _bookService = new BookService();
            LoadData();
        }

        private void LoadData()
        {
            dgvBooks.Rows.Clear();
            dgvBooks.Columns.Clear();

            dgvBooks.Columns.Add("BookID", "ID");
            dgvBooks.Columns.Add("Title", "Tên sách");
            dgvBooks.Columns.Add("Author", "Tác giả");
            dgvBooks.Columns.Add("Price", "Giá");

            List<Book> books = _bookService.GetAll();

            foreach (var b in books)
            {
                dgvBooks.Rows.Add(b.BookID, b.Title, b.Author, b.Price);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var frm = new FormAddBook();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _bookService.Add(frm.Book);
                LoadData();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0) return;

            var row = dgvBooks.SelectedRows[0];
            var book = new Book
            {
                BookID = row.Cells["BookID"].Value.ToString(),
                Title = row.Cells["Title"].Value.ToString(),
                Author = row.Cells["Author"].Value.ToString(),
                Price = Convert.ToDecimal(row.Cells["Price"].Value)
            };

            var frm = new FormUpdateBook(book);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _bookService.Update(book);
                LoadData();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0) return;

            var id = dgvBooks.SelectedRows[0]
                        .Cells["BookID"].Value.ToString();

            if (MessageBox.Show("Xóa sách này?",
                "Confirm",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _bookService.Delete(id);
                LoadData();
            }
        }

        private void txtSearchBook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            string keyword = txtSearchBook.Text.Trim().ToLower();
            dgvBooks.Rows.Clear();

            var result = _bookService.GetAll()
                .Where(b =>
                    b.BookID.ToLower().Contains(keyword) ||
                    b.Title.ToLower().Contains(keyword) ||
                    b.Author.ToLower().Contains(keyword))
                .ToList();

            foreach (var b in result)
            {
                dgvBooks.Rows.Add(b.BookID, b.Title, b.Author, b.Price);
            }
        }
    }
}
