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

            // ================== HOME BUTTON ==================
            btnHome.Text = "  🏠  Trang chủ";
            btnHome.Dock = DockStyle.Top;
            btnHome.Height = 50;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.ForeColor = Color.FromArgb(236, 240, 241);
            btnHome.BackColor = Color.Transparent;
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.Padding = new Padding(20, 0, 0, 0);
            btnHome.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnHome.Cursor = Cursors.Hand;
            btnHome.Click += btnHome_Click;
            btnHome.MouseEnter += Button_MouseEnter;
            btnHome.MouseLeave += Button_MouseLeave;

            // ================== BOOKS BUTTON ==================
            btnBooks.Text = "  📖  Quản lý sách";
            btnBooks.Dock = DockStyle.Top;
            btnBooks.Height = 50;
            btnBooks.FlatStyle = FlatStyle.Flat;
            btnBooks.FlatAppearance.BorderSize = 0;
            btnBooks.ForeColor = Color.FromArgb(236, 240, 241);
            btnBooks.BackColor = Color.Transparent;
            btnBooks.TextAlign = ContentAlignment.MiddleLeft;
            btnBooks.Padding = new Padding(20, 0, 0, 0);
            btnBooks.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnBooks.Cursor = Cursors.Hand;
            btnBooks.Click += btnBooks_Click;
            btnBooks.MouseEnter += Button_MouseEnter;
            btnBooks.MouseLeave += Button_MouseLeave;

            // ================== ORDERS BUTTON ==================
            btnOrders.Text = "  🧾  Quản lý hóa đơn";
            btnOrders.Dock = DockStyle.Top;
            btnOrders.Height = 50;
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.FlatAppearance.BorderSize = 0;
            btnOrders.ForeColor = Color.FromArgb(236, 240, 241);
            btnOrders.BackColor = Color.Transparent;
            btnOrders.TextAlign = ContentAlignment.MiddleLeft;
            btnOrders.Padding = new Padding(20, 0, 0, 0);
            btnOrders.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnOrders.Cursor = Cursors.Hand;
            btnOrders.Click += btnOrders_Click;
            btnOrders.MouseEnter += Button_MouseEnter;
            btnOrders.MouseLeave += Button_MouseLeave;

            // ================== CATEGORY BUTTON ==================
            btnCategory.Text = "  📂  Quản lý danh mục";
            btnCategory.Dock = DockStyle.Top;
            btnCategory.Height = 50;
            btnCategory.FlatStyle = FlatStyle.Flat;
            btnCategory.FlatAppearance.BorderSize = 0;
            btnCategory.ForeColor = Color.FromArgb(236, 240, 241);
            btnCategory.BackColor = Color.Transparent;
            btnCategory.TextAlign = ContentAlignment.MiddleLeft;
            btnCategory.Padding = new Padding(20, 0, 0, 0);
            btnCategory.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnCategory.Cursor = Cursors.Hand;
            btnCategory.Click += btnCategory_Click;
            btnCategory.MouseEnter += Button_MouseEnter;
            btnCategory.MouseLeave += Button_MouseLeave;

            // ================== USERS BUTTON ==================
            btnUsers.Text = "  👥  Quản lý người dùng";
            btnUsers.Dock = DockStyle.Top;
            btnUsers.Height = 50;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.ForeColor = Color.FromArgb(236, 240, 241);
            btnUsers.BackColor = Color.Transparent;
            btnUsers.TextAlign = ContentAlignment.MiddleLeft;
            btnUsers.Padding = new Padding(20, 0, 0, 0);
            btnUsers.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnUsers.Cursor = Cursors.Hand;
            btnUsers.Click += btnUsers_Click;
            btnUsers.MouseEnter += Button_MouseEnter;
            btnUsers.MouseLeave += Button_MouseLeave;

            // ================== MANAGE CASE BUTTON ==================
            btnManageCase.Text = "  ⏰  Quản lý ca làm";
            btnManageCase.Dock = DockStyle.Top;
            btnManageCase.Height = 50;
            btnManageCase.FlatStyle = FlatStyle.Flat;
            btnManageCase.FlatAppearance.BorderSize = 0;
            btnManageCase.ForeColor = Color.FromArgb(236, 240, 241);
            btnManageCase.BackColor = Color.Transparent;
            btnManageCase.TextAlign = ContentAlignment.MiddleLeft;
            btnManageCase.Padding = new Padding(20, 0, 0, 0);
            btnManageCase.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnManageCase.Cursor = Cursors.Hand;
            btnManageCase.Click += btnManageCase_Click;
            btnManageCase.MouseEnter += Button_MouseEnter;
            btnManageCase.MouseLeave += Button_MouseLeave;

            // ================== THONG KE BUTTON ==================
            btnThongKe.Text = "  📊  Thống kê";
            btnThongKe.Dock = DockStyle.Top;
            btnThongKe.Height = 50;
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnThongKe.ForeColor = Color.FromArgb(236, 240, 241);
            btnThongKe.BackColor = Color.Transparent;
            btnThongKe.TextAlign = ContentAlignment.MiddleLeft;
            btnThongKe.Padding = new Padding(20, 0, 0, 0);
            btnThongKe.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnThongKe.Cursor = Cursors.Hand;
            btnThongKe.Click += btnThongKe_Click;
            btnThongKe.MouseEnter += Button_MouseEnter;
            btnThongKe.MouseLeave += Button_MouseLeave;

            // ================== LOGOUT BUTTON ==================
            btnLogout.Text = "  🚪  Đăng xuất";
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.Height = 50;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.ForeColor = Color.White;
            btnLogout.BackColor = Color.FromArgb(192, 57, 43);
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.Padding = new Padding(20, 0, 0, 0);
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.MouseEnter += BtnLogout_MouseEnter;
            btnLogout.MouseLeave += BtnLogout_MouseLeave;

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

        #endregion

        // Event handlers for button hover effects
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.BackColor == Color.Transparent)
            {
                btn.BackColor = Color.FromArgb(44, 62, 80);
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.BackColor != Color.FromArgb(52, 152, 219))
            {
                btn.BackColor = Color.Transparent;
            }
        }

        private void BtnLogout_MouseEnter(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(231, 76, 60);
        }

        private void BtnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(192, 57, 43);
        }

        // Helper method to highlight active button
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
    }
}