using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyTiemSach.OrderFrms
{
    public partial class FormSelectBook : Form
    {
        private List<Book> _books;
        public Book SelectedBook { get; private set; }
        public int Quantity { get; private set; }

        private Panel headerPanel;
        private Label lblHeader;
        private Panel searchPanel;
        private TextBox txtSearch;
        private DataGridView dgvBooks;
        private Panel inputPanel;
        private Label lblQuantity, lblStock;
        private NumericUpDown numQuantity;
        private Button btnOK, btnCancel;

        public FormSelectBook(List<Book> books)
        {
            _books = books;
            InitializeComponent();
            BuildUI();
            LoadBooks();
        }

        private void BuildUI()
        {
            // Header
            headerPanel = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.FromArgb(52, 152, 219) };
            lblHeader = new Label
            {
                Text = "📚 CHỌN SÁCH",
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            headerPanel.Controls.Add(lblHeader);

            // Search
            searchPanel = new Panel { Dock = DockStyle.Top, Height = 50, Padding = new Padding(20, 10, 20, 10) };
            var lblSearch = new Label { Text = "🔍 Tìm kiếm:", Location = new Point(0, 8), AutoSize = true };
            txtSearch = new TextBox { Location = new Point(90, 5), Width = 400 };
            txtSearch.TextChanged += TxtSearch_TextChanged;
            searchPanel.Controls.AddRange(new Control[] { lblSearch, txtSearch });

            // Grid
            dgvBooks = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };
            dgvBooks.SelectionChanged += DgvBooks_SelectionChanged;
            dgvBooks.CellDoubleClick += DgvBooks_CellDoubleClick;

            dgvBooks.Columns.Add("BookID", "Mã sách");
            dgvBooks.Columns.Add("Title", "Tên sách");
            dgvBooks.Columns.Add("Author", "Tác giả");
            dgvBooks.Columns.Add("Price", "Giá");
            dgvBooks.Columns.Add("Quantity", "Tồn kho");

            // Bottom panel
            inputPanel = new Panel { Dock = DockStyle.Bottom, Height = 100, Padding = new Padding(20) };

            lblStock = new Label { Text = "Tồn kho: 0", AutoSize = true };
            lblQuantity = new Label { Text = "Số lượng:", Location = new Point(0, 30), AutoSize = true };
            numQuantity = new NumericUpDown { Location = new Point(80, 27), Minimum = 1, Maximum = 1000 };

            btnOK = new Button { Text = "✓ Chọn", Width = 100 };
            btnCancel = new Button { Text = "Hủy", Width = 100, DialogResult = DialogResult.Cancel };

            btnOK.Click += BtnOK_Click;

            inputPanel.Controls.AddRange(new Control[] { lblStock, lblQuantity, numQuantity, btnOK, btnCancel });

            Controls.AddRange(new Control[] { dgvBooks, inputPanel, searchPanel, headerPanel });
        }

        private void LoadBooks()
        {
            dgvBooks.Rows.Clear();
            foreach (var book in _books)
            {
                dgvBooks.Rows.Add(book.BookID, book.Title, book.Author, book.Price, book.Quantity);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            var search = txtSearch.Text.ToLower();
            dgvBooks.Rows.Clear();

            foreach (var book in _books.Where(b =>
                b.BookID.ToLower().Contains(search) ||
                b.Title.ToLower().Contains(search) ||
                b.Author.ToLower().Contains(search)))
            {
                dgvBooks.Rows.Add(book.BookID, book.Title, book.Author, book.Price, book.Quantity);
            }
        }

        private void DgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0) return;

            var bookId = dgvBooks.SelectedRows[0].Cells["BookID"].Value.ToString();
            var book = _books.FirstOrDefault(b => b.BookID == bookId);

            if (book != null)
            {
                lblStock.Text = $"Tồn kho: {book.Quantity}";
                numQuantity.Maximum = book.Quantity;
                numQuantity.Value = Math.Min(1, book.Quantity);
            }
        }

        private void DgvBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) BtnOK_Click(sender, e);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sách!");
                return;
            }

            var bookId = dgvBooks.SelectedRows[0].Cells["BookID"].Value.ToString();
            SelectedBook = _books.First(b => b.BookID == bookId);
            Quantity = (int)numQuantity.Value;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
