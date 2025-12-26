using QuanLyTiemSach.BLL.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    public partial class LoginForm : Form
    {
        private readonly IUserService _userService;

        public LoginForm()
        {
            InitializeComponent();
            _userService = ServiceDI.GetUserService();
            btnLogin.Click += BtnLogin_Click;
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;

            try
            {
                string username = txtUser.Text.Trim();
                string password = txtPass.Text;

                if (string.IsNullOrWhiteSpace(username) ||
                    string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }

                var user = await _userService.LoginAsync(username, password);

                if (user == null)
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!","Đăng nhập thất bại",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtPass.Clear();
                    txtPass.Focus();
                    return;
                }

                AuthenSession.CurrentUser = user;

                var dashboard = new MainDashboard();
                dashboard.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,"Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
            }
        }
    }
}
