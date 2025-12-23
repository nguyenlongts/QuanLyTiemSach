using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyTiemSach.OrderFrms
{
    public partial class FormSelectBook : Form
    {
        private List<Book> _books;
        public Book SelectedBook { get; private set; }
        public int Quantity { get; private set; }

        public FormSelectBook(List<Book> books)
        {
            _books = books;
            InitializeComponent();
            LoadBooks();
        }

        private void LoadBooks()
        {
            dgvBooks.Rows.Clear();
            foreach (var book in _books)
            {
                dgvBooks.Rows.Add(
                    book.BookID,
                    book.Title,
                    book.Author,
                    book.Price,
                    book.Quantity
                );
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower().Trim();
            dgvBooks.Rows.Clear();

            var filtered = _books.Where(b =>
                b.BookID.ToLower().Contains(search) ||
                b.Title.ToLower().Contains(search) ||
                b.Author.ToLower().Contains(search));

            foreach (var book in filtered)
            {
                dgvBooks.Rows.Add(
                    book.BookID,
                    book.Title,
                    book.Author,
                    book.Price,
                    book.Quantity
                );
            }
        }

        private void DgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0) return;

            string bookId = dgvBooks.SelectedRows[0].Cells["BookID"].Value?.ToString();
            var book = _books.FirstOrDefault(b => b.BookID == bookId);

            if (book != null)
            {
                lblQuantity.Text = $"Tồn kho: {book.Quantity}";
                numQuantity.Maximum = book.Quantity;
                numQuantity.Value = Math.Min(1, book.Quantity);
            }
        }

        private void DgvBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                BtnOK_Click(sender, e);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sách!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string bookId = dgvBooks.SelectedRows[0].Cells["BookID"].Value.ToString();
            SelectedBook = _books.First(b => b.BookID == bookId);
            Quantity = (int)numQuantity.Value;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
