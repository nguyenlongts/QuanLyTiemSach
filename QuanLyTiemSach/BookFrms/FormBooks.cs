using QuanLyTiemSach.BookFrms;
using QuanLyTiemSach.Model;
using static System.Reflection.Metadata.BlobBuilder;

namespace QuanLyTiemSach
{
    public partial class FormBooks : Form
    {
        public FormBooks()
        {
            InitializeComponent();
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            dgvBooks.Columns.Add("BookID", "ID");
            dgvBooks.Columns.Add("Title", "Tên sách");
            dgvBooks.Columns.Add("Author", "Tác giả");
            dgvBooks.Columns.Add("Price", "Giá");

            dgvBooks.Rows.Add("1", "C# cơ bản", "Nguyễn Văn A", "200000");
            dgvBooks.Rows.Add("2", "WinForms nâng cao", "Trần Thị B", "250000");
            dgvBooks.Rows.Add("3", "SQL Server", "Lê Văn C", "180000");
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FormAddBook addBookForm = new FormAddBook();

            if (addBookForm.ShowDialog() == DialogResult.OK)
            {
                Book newBook = addBookForm.Book;
                dgvBooks.Rows.Add(newBook.BookID, newBook.Title, newBook.Author, newBook.Price);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
                return;

            var row = dgvBooks.SelectedRows[0];
            Book selectedBook = new Book
            {
                BookID = row.Cells["BookID"].Value.ToString(),
                Title = row.Cells["Title"].Value.ToString(),
                Author = row.Cells["Author"].Value.ToString(),
                Price = decimal.Parse(row.Cells["Price"].Value.ToString())
            };

            FormUpdateBook updateForm = new FormUpdateBook(selectedBook);


            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                row.Cells["Title"].Value = selectedBook.Title;
                row.Cells["Author"].Value = selectedBook.Author;
                row.Cells["Price"].Value = selectedBook.Price;
            }
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                dgvBooks.Rows.Remove(dgvBooks.SelectedRows[0]);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void SearchBook()
        {
            string keyword = txtSearchBook.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvBooks.Rows)
            {
                if (!row.IsNewRow)
                {
                    bool match =
                        row.Cells[0].Value.ToString().ToLower().Contains(keyword) ||
                        row.Cells[1].Value.ToString().ToLower().Contains(keyword) ||
                        row.Cells[2].Value.ToString().ToLower().Contains(keyword);

                    row.Visible = match;
                }
            }

        }
        private void txtSearchBook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {   
                SearchBook();
                e.SuppressKeyPress = true; 
            }
        }
    }
}
