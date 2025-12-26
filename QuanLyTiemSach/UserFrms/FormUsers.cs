using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.Domain.Model;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemSach.UserFrms
{
    public partial class FormUsers : Form
    {
        private readonly IUserService _userService;
        private int selectedUserId = -1;
        private bool _isGridFormatted = false;

        public FormUsers()
        {
            InitializeComponent();
            _userService = ServiceDI.GetUserService();
        }

        private async void FormUsers_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadUsersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                dgvUsers.DataSource = await _userService.GetAllAsync();

                if (!_isGridFormatted)
                {
                    FormatDataGridView();
                    _isGridFormatted = true;
                }

                dgvUsers.ClearSelection();
                selectedUserId = -1;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể tải danh sách người dùng.", ex);
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvUsers.Rows[e.RowIndex];
            selectedUserId = (int)row.Cells["UserID"].Value;

            txtUsername.Text = row.Cells["Username"].Value?.ToString();
            txtFullName.Text = row.Cells["FullName"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
            cboRole.Text = row.Cells["Role"].Value?.ToString();
            cboStatus.Text = row.Cells["Status"].Value?.ToString();

            txtPassword.Clear();

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void FormatDataGridView()
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
        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isStaff = cboRole.Text == "Staff";

            lblPhone.Visible = isStaff;
            txtPhone.Visible = isStaff;

            if (!isStaff)
                txtPhone.Clear();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            btnAdd.Enabled = false;

            try
            {
                var user = new User
                {
                    Username = txtUsername.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    Role = cboRole.Text,
                    Status = cboStatus.Text
                };
                await _userService.AddAsync(user,
                    cboRole.Text == "Staff" ? txtPhone.Text.Trim() : null);
                MessageBox.Show("Thêm người dùng thành công!");
                await LoadUsersAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnAdd.Enabled = true;
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1) return;

            btnUpdate.Enabled = false;

            try
            {
                var user = await _userService.GetByIdAsync(selectedUserId);
                if (user == null)
                    throw new Exception("Người dùng không tồn tại.");

                user.Username = txtUsername.Text.Trim();
                user.FullName = txtFullName.Text.Trim();
                user.Email = txtEmail.Text.Trim();
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    user.Password = user.Password;
                }
                else
                {
                    user.Password = txtPassword.Text.Trim();
                }
                user.Role = cboRole.Text;
                user.Status = cboStatus.Text;

                await _userService.UpdateAsync(user);
                MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadUsersAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnUpdate.Enabled = true;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1) return;

            if (MessageBox.Show("Xóa người dùng này?", "Xác nhận",
                MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            btnDelete.Enabled = false;

            try
            {
                await _userService.DeleteAsync(selectedUserId);
                await LoadUsersAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                btnDelete.Enabled = true;
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgvUsers.DataSource =
                    await _userService.SearchAsync(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                try
                {
                    dgvUsers.DataSource =
                        await _userService.SearchAsync(txtSearch.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Clear();
                await LoadUsersAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }

            if (cboRole.SelectedIndex == -1 || cboStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn vai trò và trạng thái!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboRole.Text == "Staff")
            {
                if (string.IsNullOrWhiteSpace(txtPhone.Text))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại nhân viên!",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhone.Focus();
                    return false;
                }
            }


            return true;
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
    }
}
