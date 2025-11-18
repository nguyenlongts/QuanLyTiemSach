using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel headerPanel;
        private Label lblHeader;
        private Label lblUser, lblPass;
        private TextBox txtUser, txtPass;
        private Button btnLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.headerPanel = new Panel();
            this.lblHeader = new Label();
            this.lblUser = new Label();
            this.txtUser = new TextBox();
            this.lblPass = new Label();
            this.txtPass = new TextBox();
            this.btnLogin = new Button();

            this.SuspendLayout();

            // --- headerPanel ---
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 80;
            headerPanel.BackColor = Color.FromArgb(52, 152, 219);

            lblHeader.Text = "Đăng nhập";
            lblHeader.ForeColor = Color.White;
            lblHeader.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;

            headerPanel.Controls.Add(lblHeader);

            // --- lblUser ---
            lblUser.Text = "Tên đăng nhập";
            lblUser.Font = new Font("Segoe UI", 10);
            lblUser.Location = new Point(40, 100);
            lblUser.AutoSize = true;

            // --- txtUser ---
            txtUser.Location = new Point(40, 130);
            txtUser.Width = 300;
            txtUser.Font = new Font("Segoe UI", 10);

            // --- lblPass ---
            lblPass.Text = "Mật khẩu";
            lblPass.Font = new Font("Segoe UI", 10);
            lblPass.Location = new Point(40, 180);
            lblPass.AutoSize = true;

            // --- txtPass ---
            txtPass.Location = new Point(40, 210);
            txtPass.Width = 300;
            txtPass.Font = new Font("Segoe UI", 10);
            txtPass.PasswordChar = '*';

            // --- btnLogin ---
            btnLogin.Text = "Đăng nhập";
            btnLogin.BackColor = Color.FromArgb(41, 128, 185);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnLogin.Width = 300;
            btnLogin.Height = 40;
            btnLogin.Location = new Point(40, 270);

            // --- LoginForm ---
            this.ClientSize = new Size(400, 350);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Controls.AddRange(new Control[] { headerPanel, lblUser, txtUser, lblPass, txtPass, btnLogin });
            this.Text = "Đăng nhập";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
