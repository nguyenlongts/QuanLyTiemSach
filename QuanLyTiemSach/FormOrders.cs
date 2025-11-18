using System;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    public partial class FormOrders : Form
    {
        public FormOrders()
        {
            InitializeComponent();
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            dgvOrders.Columns.Add("OrderID", "ID");
            dgvOrders.Columns.Add("CustomerName", "Khách hàng");
            dgvOrders.Columns.Add("BookTitle", "Tên sách");
            dgvOrders.Columns.Add("Quantity", "Số lượng");
            dgvOrders.Columns.Add("TotalPrice", "Tổng tiền");

            dgvOrders.Rows.Add("1", "Nguyễn Văn A", "C# cơ bản", "2", "400000");
            dgvOrders.Rows.Add("2", "Trần Thị B", "WinForms", "1", "250000");
            dgvOrders.Rows.Add("3", "Lê Văn C", "SQL Server", "3", "540000");
        }

        private void BtnAdd_Click(object sender, EventArgs e) => MessageBox.Show("Thêm hóa đơn");
        private void BtnEdit_Click(object sender, EventArgs e) { if (dgvOrders.SelectedRows.Count > 0) MessageBox.Show("Sửa hóa đơn"); }
        private void BtnDelete_Click(object sender, EventArgs e) { if (dgvOrders.SelectedRows.Count > 0) dgvOrders.Rows.Remove(dgvOrders.SelectedRows[0]); }
    }
}
