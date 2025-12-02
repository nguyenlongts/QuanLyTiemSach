using QuanLyTiemSach.BookFrms;
using QuanLyTiemSach.Model;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyTiemSach.UserFrms
{
    public partial class FormUsers : Form
    {
        private DataTable dtUsers;
        private bool isEditing = false;
        private int selectedUserId = -1;

        public FormUsers()
        {
            InitializeComponent();
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            // Khởi tạo DataTable
            dtUsers = new DataTable();
            dtUsers.Columns.Add("UserID", typeof(int));
            dtUsers.Columns.Add("Username", typeof(string));
            dtUsers.Columns.Add("FullName", typeof(string));
            dtUsers.Columns.Add("Email", typeof(string));
            dtUsers.Columns.Add("Role", typeof(string));
            dtUsers.Columns.Add("Status", typeof(string));
            dtUsers.Columns.Add("CreatedDate", typeof(DateTime));

            // Thêm dữ liệu mẫu
            dtUsers.Rows.Add(1, "admin", "Nguyễn Văn A", "admin@gmail.com", "Admin", "Active", DateTime.Now.AddMonths(-6));
            dtUsers.Rows.Add(2, "user001", "Trần Thị B", "trantb@gmail.com", "User", "Active", DateTime.Now.AddMonths(-3));
            dtUsers.Rows.Add(3, "manager01", "Lê Văn C", "levanc@gmail.com", "Manager", "Active", DateTime.Now.AddMonths(-1));
            dtUsers.Rows.Add(4, "user002", "Phạm Thị D", "phamthid@gmail.com", "User", "Inactive", DateTime.Now.AddDays(-15));

            dgvUsers.DataSource = dtUsers;
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            if (dgvUsers.Columns.Count > 0)
            {
                dgvUsers.Columns["UserID"].HeaderText = "ID";
                dgvUsers.Columns["UserID"].Width = 50;
                dgvUsers.Columns["Username"].HeaderText = "Tên đăng nhập";
                dgvUsers.Columns["Username"].Width = 120;
                dgvUsers.Columns["FullName"].HeaderText = "Họ và tên";
                dgvUsers.Columns["FullName"].Width = 150;
                dgvUsers.Columns["Email"].HeaderText = "Email";
                dgvUsers.Columns["Email"].Width = 180;
                dgvUsers.Columns["Role"].HeaderText = "Vai trò";
                dgvUsers.Columns["Role"].Width = 100;
                dgvUsers.Columns["Status"].HeaderText = "Trạng thái";
                dgvUsers.Columns["Status"].Width = 100;
                dgvUsers.Columns["CreatedDate"].HeaderText = "Ngày tạo";
                dgvUsers.Columns["CreatedDate"].Width = 120;
                dgvUsers.Columns["CreatedDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

                dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUsers.MultiSelect = false;
                dgvUsers.AllowUserToAddRows = false;
                dgvUsers.ReadOnly = true;
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                selectedUserId = Convert.ToInt32(row.Cells["UserID"].Value);

                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                cboRole.Text = row.Cells["Role"].Value.ToString();
                cboStatus.Text = row.Cells["Status"].Value.ToString();

                isEditing = true;
                btnAdd.Text = "Hủy";
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                // Hủy chế độ chỉnh sửa
                ClearInputs();
                isEditing = false;
                btnAdd.Text = "Thêm mới";
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                // Thêm người dùng mới
                if (ValidateInputs())
                {
                    int newId = dtUsers.AsEnumerable().Max(r => r.Field<int>("UserID")) + 1;

                    DataRow newRow = dtUsers.NewRow();
                    newRow["UserID"] = newId;
                    newRow["Username"] = txtUsername.Text.Trim();
                    newRow["FullName"] = txtFullName.Text.Trim();
                    newRow["Email"] = txtEmail.Text.Trim();
                    newRow["Role"] = cboRole.Text;
                    newRow["Status"] = cboStatus.Text;
                    newRow["CreatedDate"] = DateTime.Now;

                    dtUsers.Rows.Add(newRow);

                    MessageBox.Show("Thêm người dùng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearInputs();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Vui lòng chọn người dùng cần cập nhật!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateInputs())
            {
                DataRow[] rows = dtUsers.Select($"UserID = {selectedUserId}");
                if (rows.Length > 0)
                {
                    rows[0]["Username"] = txtUsername.Text.Trim();
                    rows[0]["FullName"] = txtFullName.Text.Trim();
                    rows[0]["Email"] = txtEmail.Text.Trim();
                    rows[0]["Role"] = cboRole.Text;
                    rows[0]["Status"] = cboStatus.Text;

                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearInputs();
                    isEditing = false;
                    btnAdd.Text = "Thêm mới";
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Vui lòng chọn người dùng cần xóa!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa người dùng này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DataRow[] rows = dtUsers.Select($"UserID = {selectedUserId}");
                if (rows.Length > 0)
                {
                    dtUsers.Rows.Remove(rows[0]);

                    MessageBox.Show("Xóa người dùng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearInputs();
                    isEditing = false;
                    btnAdd.Text = "Thêm mới";
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                dgvUsers.DataSource = dtUsers;
                return;
            }

            DataView dv = dtUsers.DefaultView;
            dv.RowFilter = $"Username LIKE '%{searchText}%' OR FullName LIKE '%{searchText}%' OR Email LIKE '%{searchText}%'";
            dgvUsers.DataSource = dv.ToTable();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            dgvUsers.DataSource = dtUsers;
            ClearInputs();
            isEditing = false;
            btnAdd.Text = "Thêm mới";
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Email không hợp lệ!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (cboRole.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn vai trò!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRole.Focus();
                return false;
            }

            if (cboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboStatus.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ClearInputs()
        {
            txtUsername.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            cboRole.SelectedIndex = -1;
            cboStatus.SelectedIndex = -1;
            selectedUserId = -1;
            dgvUsers.ClearSelection();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void pnlCenter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void FormUsers_Load(object sender, EventArgs e)
        {

        }

        private void grpUserInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}