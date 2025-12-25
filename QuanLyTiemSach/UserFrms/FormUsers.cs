using QuanLyTiemSach.BLL.Services;
using QuanLyTiemSach.Domain.Model;
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
        private readonly UserService _userService;
        private int selectedUserId = -1;


        public FormUsers()
        {
            InitializeComponent();
            _userService = new UserService();
            LoadUsers();
        }


        private void LoadUsers()
        {
            dgvUsers.DataSource = _userService.GetAll();
            dgvUsers.ClearSelection();
            selectedUserId = -1;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvUsers.Rows[e.RowIndex];
            selectedUserId = (int)row.Cells["UserID"].Value;

            txtUsername.Text = row.Cells["Username"].Value.ToString();
            txtFullName.Text = row.Cells["FullName"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            cboRole.Text = row.Cells["Role"].Value.ToString();
            cboStatus.Text = row.Cells["Status"].Value.ToString();

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
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



        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var user = new User
            {
                Username = txtUsername.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                Role = cboRole.Text,
                Status = cboStatus.Text
            };

            _userService.Add(user);
            MessageBox.Show("Thêm người dùng thành công!");
            LoadUsers();
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1) return;

            var user = _userService.GetById(selectedUserId);
            if (user == null) return;

            user.Username = txtUsername.Text.Trim();
            user.FullName = txtFullName.Text.Trim();
            user.Email = txtEmail.Text.Trim();
            user.Password = txtPassword.Text.Trim();
            user.Role = cboRole.Text;
            user.Status = cboStatus.Text;

            _userService.Update(user);
            MessageBox.Show("Cập nhật thành công!");
            LoadUsers();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1) return;

            if (MessageBox.Show("Xóa người dùng này?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _userService.Delete(selectedUserId);
                LoadUsers();
                ClearInputs();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvUsers.DataSource = _userService.Search(txtSearch.Text.Trim());
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