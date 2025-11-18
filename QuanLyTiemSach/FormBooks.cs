using System;
using System.Windows.Forms;

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
            MessageBox.Show("Thêm sách");
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0) MessageBox.Show("Sửa sách");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0) dgvBooks.Rows.Remove(dgvBooks.SelectedRows[0]);
        }
    }
}
