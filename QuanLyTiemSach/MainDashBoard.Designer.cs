namespace QuanLyTiemSach
{
    partial class MainDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnBooks;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnManageCase;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel activeIndicator;

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
            lblTitle = new Label();
            btnHome = new Button();
            btnBooks = new Button();
            btnOrders = new Button();
            btnCategory = new Button();
            btnUsers = new Button();
            btnManageCase = new Button();
            btnThongKe = new Button();
            btnLogout = new Button();
            activeIndicator = new Panel();
            headerPanel = new Panel();
            lblUser = new Label();
            mainPanel = new Panel();

            menuPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            SuspendLayout();

            // ================== MENU PANEL ==================
            menuPanel.BackColor = Color.FromArgb(52, 152, 219);
            menuPanel.Dock = DockStyle.Left;
            menuPanel.Width = 240;
            menuPanel.Controls.Add(btnLogout);
            menuPanel.Controls.Add(btnThongKe);
            menuPanel.Controls.Add(btnManageCase);
            menuPanel.Controls.Add(btnUsers);
            menuPanel.Controls.Add(btnCategory);
            menuPanel.Controls.Add(btnOrders);
            menuPanel.Controls.Add(btnBooks);
            menuPanel.Controls.Add(btnHome);
            menuPanel.Controls.Add(lblTitle);

            // ================== TITLE LABEL ==================
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 80;
            lblTitle.Text = "📚 BOOKSTORE";
            lblTitle.ForeColor = Color.White;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.BackColor = Color.FromArgb(23, 32, 38);

            // ================== HEADER PANEL ==================
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 70;
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(lblUser);
            headerPanel.Padding = new Padding(20, 0, 20, 0);

            // ================== USER LABEL ==================
            lblUser.Dock = DockStyle.Fill;
            lblUser.Text = "👤 Xin chào, User";
            lblUser.ForeColor = Color.FromArgb(44, 62, 80);
            lblUser.TextAlign = ContentAlignment.MiddleLeft;
            lblUser.Font = new Font("Segoe UI", 12F, FontStyle.Regular);

            // ================== BUTTON STYLE ==================
            void StyleButton(Button btn, string text, string icon)
            {
                btn.Text = $"  {icon}  {text}";
                btn.Dock = DockStyle.Top;
                btn.Height = 50;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.FromArgb(236, 240, 241);
                btn.BackColor = Color.Transparent;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Padding = new Padding(20, 0, 0, 0);
                btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                btn.Cursor = Cursors.Hand;

                btn.MouseEnter += (s, e) => {
                    if (btn.BackColor == Color.Transparent)
                        btn.BackColor = Color.FromArgb(44, 62, 80);
                };
                btn.MouseLeave += (s, e) => {
                    if (btn.BackColor != Color.FromArgb(52, 152, 219))
                        btn.BackColor = Color.Transparent;
                };
            }

            StyleButton(btnHome, "Trang chủ", "🏠");
            StyleButton(btnBooks, "Quản lý sách", "📖");
            StyleButton(btnOrders, "Quản lý hóa đơn", "🧾");
            StyleButton(btnCategory, "Quản lý danh mục", "📂");
            StyleButton(btnUsers, "Quản lý người dùng", "👥");
            StyleButton(btnManageCase, "Quản lý ca làm", "⏰");
            StyleButton(btnThongKe, "Thống kê", "📊");
            StyleButton(btnLogout, "Đăng xuất", "🚪");

            // ================== EVENTS ==================
            btnHome.Click += btnHome_Click;
            btnBooks.Click += btnBooks_Click;
            btnOrders.Click += btnOrders_Click;
            btnCategory.Click += btnCategory_Click;
            btnUsers.Click += btnUsers_Click;
            btnManageCase.Click += btnManageCase_Click;
            btnThongKe.Click += btnThongKe_Click;

            // ================== LOGOUT BUTTON ==================
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.BackColor = Color.FromArgb(192, 57, 43);
            btnLogout.ForeColor = Color.White;
            btnLogout.MouseEnter += (s, e) => btnLogout.BackColor = Color.FromArgb(231, 76, 60);
            btnLogout.MouseLeave += (s, e) => btnLogout.BackColor = Color.FromArgb(192, 57, 43);

            // ================== MAIN PANEL ==================
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.BackColor = Color.FromArgb(236, 240, 241);
            mainPanel.Padding = new Padding(10);

            // ================== FORM ==================
            ClientSize = new Size(1200, 700);
            Controls.Add(mainPanel);
            Controls.Add(headerPanel);
            Controls.Add(menuPanel);
            Text = "Dashboard - Quản Lý Tiệm Sách";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(1000, 600);

            menuPanel.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        // Helper method để highlight button active
        private void SetActiveButton(Button activeBtn)
        {
            foreach (Control ctrl in menuPanel.Controls)
            {
                if (ctrl is Button btn && btn != btnLogout)
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.FromArgb(236, 240, 241);
                }
            }
            activeBtn.BackColor = Color.FromArgb(52, 152, 219);
            activeBtn.ForeColor = Color.White;
        }

        #endregion
    }
}