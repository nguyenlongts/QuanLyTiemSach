namespace QuanLyTiemSach
{
    partial class MainDashboard
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnBooks;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnManageCase;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            menuPanel = new Panel();
            lblUser = new Label();

            btnHome = new Button();
            btnBooks = new Button();
            btnOrders = new Button();
            btnCategory = new Button();
            btnUsers = new Button();
            btnManageCase = new Button();
            btnThongKe = new Button();
            btnLogout = new Button();

            mainPanel = new Panel();

            menuPanel.SuspendLayout();
            SuspendLayout();

            // ================== MENU PANEL ==================
            menuPanel.BackColor = Color.FromArgb(41, 128, 185);
            menuPanel.Dock = DockStyle.Left;
            menuPanel.Width = 200;
            menuPanel.Controls.Add(btnLogout);
            menuPanel.Controls.Add(btnThongKe);
            menuPanel.Controls.Add(btnManageCase);
            menuPanel.Controls.Add(btnUsers);
            menuPanel.Controls.Add(btnCategory);
            menuPanel.Controls.Add(btnOrders);
            menuPanel.Controls.Add(btnBooks);
            menuPanel.Controls.Add(btnHome);
            menuPanel.Controls.Add(lblUser);

            // ================== USER LABEL ==================
            lblUser.Dock = DockStyle.Top;
            lblUser.Height = 50;
            lblUser.Text = "Xin chào, User";
            lblUser.ForeColor = Color.White;
            lblUser.TextAlign = ContentAlignment.MiddleLeft;
            lblUser.Padding = new Padding(10, 0, 0, 0);
            lblUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // ================== BUTTON STYLE ==================
            void StyleButton(Button btn, string text)
            {
                btn.Text = text;
                btn.Dock = DockStyle.Top;
                btn.Height = 45;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
                btn.BackColor = Color.FromArgb(52, 152, 219);
            }

            StyleButton(btnHome, "Trang chủ");
            StyleButton(btnBooks, "Quản lý sách");
            StyleButton(btnOrders, "Quản lý hóa đơn");
            StyleButton(btnCategory, "Quản lý danh mục");
            StyleButton(btnUsers, "Quản lý người dùng");
            StyleButton(btnManageCase, "Quản lý ca làm");
            StyleButton(btnThongKe, "Thống kê");
            StyleButton(btnLogout, "Đăng xuất");

            // ================== EVENTS ==================
            btnHome.Click += btnHome_Click;
            btnBooks.Click += btnBooks_Click;
            btnOrders.Click += btnOrders_Click;
            btnCategory.Click += btnCategory_Click;
            btnUsers.Click += btnUsers_Click;
            btnManageCase.Click += btnManageCase_Click;
            btnThongKe.Click += btnThongKe_Click;

            // ================== LOGOUT ==================
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.BackColor = Color.FromArgb(231, 76, 60);

            // ================== MAIN PANEL ==================
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.BackColor = Color.LightGray;

            // ================== FORM ==================
            ClientSize = new Size(1000, 600);
            Controls.Add(mainPanel);
            Controls.Add(menuPanel);
            Text = "Dashboard - Quản Lý Tiệm Sách";
            StartPosition = FormStartPosition.CenterScreen;

            menuPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
