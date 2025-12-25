using QuanLyTiemSach.BLL.Services;
using QuanLyTiemSach.BLL.Services.Implements;
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
            _userService = new UserService();
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text;

            var user = _userService.Login(username, password);

            if (user == null)
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AuthenSession.CurrentUser = user;

            MainDashboard dashboard = new MainDashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
