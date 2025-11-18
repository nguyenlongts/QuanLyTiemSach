using System;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    public partial class FormUsers : Form
    {
        public FormUsers()
        {
            InitializeComponent();
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            dgvUsers.Columns.Add("UserID", "ID");
            dgvUsers.Columns.Add("FullName", "Họ và tên");
            dgvUsers.Columns.Add("Username", "Tên đăng nhập");
            dgvUsers.Columns.Add("Role", "Vai trò");

            dgvUsers.Rows.Add("1", "Nguyễn Văn A", "nguyena", "Admin");
            dgvUsers.Rows.Add("2", "Trần Thị B", "tranb", "Staff");
            dgvUsers.Rows.Add("3", "Lê Văn C", "levanc", "Staff");
        }

        private void BtnAdd_Click(object sender, EventArgs e) => MessageBox.Show("Thêm người dùng");
        private void BtnEdit_Click(object sender, EventArgs e) { if (dgvUsers.SelectedRows.Count > 0) MessageBox.Show("Sửa người dùng"); }
        private void BtnDelete_Click(object sender, EventArgs e) { if (dgvUsers.SelectedRows.Count > 0) dgvUsers.Rows.Remove(dgvUsers.SelectedRows[0]); }
    }
}
