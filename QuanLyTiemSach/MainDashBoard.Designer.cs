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
            btnLogout = new Button();
            btnThongKe = new Button();
            btnManageCase = new Button();
            btnUsers = new Button();
            btnCategory = new Button();
            btnOrders = new Button();
            btnBooks = new Button();
            btnHome = new Button();
            lblTitle = new Label();
            activeIndicator = new Panel();
            headerPanel = new Panel();
            lblUser = new Label();
            mainPanel = new Panel();
            menuPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuPanel
            // 
            menuPanel.BackColor = Color.FromArgb(52, 152, 219);
            menuPanel.Controls.Add(btnLogout);
            menuPanel.Controls.Add(btnThongKe);
            menuPanel.Controls.Add(btnManageCase);
            menuPanel.Controls.Add(btnUsers);
            menuPanel.Controls.Add(btnCategory);
            menuPanel.Controls.Add(btnOrders);
            menuPanel.Controls.Add(btnBooks);
            menuPanel.Controls.Add(btnHome);
            menuPanel.Controls.Add(lblTitle);
            menuPanel.Dock = DockStyle.Left;
            menuPanel.Location = new Point(0, 0);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(240, 700);
            menuPanel.TabIndex = 2;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(192, 57, 43);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 650);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(20, 0, 0, 0);
            btnLogout.Size = new Size(240, 50);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "  🚪  Đăng xuất";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            btnLogout.MouseEnter += BtnLogout_MouseEnter;
            btnLogout.MouseLeave += BtnLogout_MouseLeave;
            // 
            // btnThongKe
            // 
            btnThongKe.BackColor = Color.Transparent;
            btnThongKe.Cursor = Cursors.Hand;
            btnThongKe.Dock = DockStyle.Top;
            btnThongKe.FlatAppearance.BorderSize = 0;
            btnThongKe.FlatStyle = FlatStyle.Flat;
            btnThongKe.Font = new Font("Segoe UI", 10F);
            btnThongKe.ForeColor = Color.FromArgb(236, 240, 241);
            btnThongKe.Location = new Point(0, 380);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Padding = new Padding(20, 0, 0, 0);
            btnThongKe.Size = new Size(240, 50);
            btnThongKe.TabIndex = 1;
            btnThongKe.Text = "  📊  Thống kê";
            btnThongKe.TextAlign = ContentAlignment.MiddleLeft;
            btnThongKe.UseVisualStyleBackColor = false;
            btnThongKe.Click += btnThongKe_Click;
            btnThongKe.MouseEnter += Button_MouseEnter;
            btnThongKe.MouseLeave += Button_MouseLeave;
            // 
            // btnManageCase
            // 
            btnManageCase.BackColor = Color.Transparent;
            btnManageCase.Cursor = Cursors.Hand;
            btnManageCase.Dock = DockStyle.Top;
            btnManageCase.FlatAppearance.BorderSize = 0;
            btnManageCase.FlatStyle = FlatStyle.Flat;
            btnManageCase.Font = new Font("Segoe UI", 10F);
            btnManageCase.ForeColor = Color.FromArgb(236, 240, 241);
            btnManageCase.Location = new Point(0, 330);
            btnManageCase.Name = "btnManageCase";
            btnManageCase.Padding = new Padding(20, 0, 0, 0);
            btnManageCase.Size = new Size(240, 50);
            btnManageCase.TabIndex = 2;
            btnManageCase.Text = "  ⏰  Quản lý ca làm";
            btnManageCase.TextAlign = ContentAlignment.MiddleLeft;
            btnManageCase.UseVisualStyleBackColor = false;
            btnManageCase.Click += btnManageCase_Click;
            btnManageCase.MouseEnter += Button_MouseEnter;
            btnManageCase.MouseLeave += Button_MouseLeave;
            // 
            // btnUsers
            // 
            btnUsers.BackColor = Color.Transparent;
            btnUsers.Cursor = Cursors.Hand;
            btnUsers.Dock = DockStyle.Top;
            btnUsers.FlatAppearance.BorderSize = 0;
            btnUsers.FlatStyle = FlatStyle.Flat;
            btnUsers.Font = new Font("Segoe UI", 10F);
            btnUsers.ForeColor = Color.FromArgb(236, 240, 241);
            btnUsers.Location = new Point(0, 280);
            btnUsers.Name = "btnUsers";
            btnUsers.Padding = new Padding(20, 0, 0, 0);
            btnUsers.Size = new Size(240, 50);
            btnUsers.TabIndex = 3;
            btnUsers.Text = "  👥  Quản lý người dùng";
            btnUsers.TextAlign = ContentAlignment.MiddleLeft;
            btnUsers.UseVisualStyleBackColor = false;
            btnUsers.Click += btnUsers_Click;
            btnUsers.MouseEnter += Button_MouseEnter;
            btnUsers.MouseLeave += Button_MouseLeave;
            // 
            // btnCategory
            // 
            btnCategory.BackColor = Color.Transparent;
            btnCategory.Cursor = Cursors.Hand;
            btnCategory.Dock = DockStyle.Top;
            btnCategory.FlatAppearance.BorderSize = 0;
            btnCategory.FlatStyle = FlatStyle.Flat;
            btnCategory.Font = new Font("Segoe UI", 10F);
            btnCategory.ForeColor = Color.FromArgb(236, 240, 241);
            btnCategory.Location = new Point(0, 230);
            btnCategory.Name = "btnCategory";
            btnCategory.Padding = new Padding(20, 0, 0, 0);
            btnCategory.Size = new Size(240, 50);
            btnCategory.TabIndex = 4;
            btnCategory.Text = "  📂  Quản lý danh mục";
            btnCategory.TextAlign = ContentAlignment.MiddleLeft;
            btnCategory.UseVisualStyleBackColor = false;
            btnCategory.Click += btnCategory_Click;
            btnCategory.MouseEnter += Button_MouseEnter;
            btnCategory.MouseLeave += Button_MouseLeave;
            // 
            // btnOrders
            // 
            btnOrders.BackColor = Color.Transparent;
            btnOrders.Cursor = Cursors.Hand;
            btnOrders.Dock = DockStyle.Top;
            btnOrders.FlatAppearance.BorderSize = 0;
            btnOrders.FlatStyle = FlatStyle.Flat;
            btnOrders.Font = new Font("Segoe UI", 10F);
            btnOrders.ForeColor = Color.FromArgb(236, 240, 241);
            btnOrders.Location = new Point(0, 180);
            btnOrders.Name = "btnOrders";
            btnOrders.Padding = new Padding(20, 0, 0, 0);
            btnOrders.Size = new Size(240, 50);
            btnOrders.TabIndex = 5;
            btnOrders.Text = "  \U0001f9fe  Quản lý hóa đơn";
            btnOrders.TextAlign = ContentAlignment.MiddleLeft;
            btnOrders.UseVisualStyleBackColor = false;
            btnOrders.Click += btnOrders_Click;
            btnOrders.MouseEnter += Button_MouseEnter;
            btnOrders.MouseLeave += Button_MouseLeave;
            // 
            // btnBooks
            // 
            btnBooks.BackColor = Color.Transparent;
            btnBooks.Cursor = Cursors.Hand;
            btnBooks.Dock = DockStyle.Top;
            btnBooks.FlatAppearance.BorderSize = 0;
            btnBooks.FlatStyle = FlatStyle.Flat;
            btnBooks.Font = new Font("Segoe UI", 10F);
            btnBooks.ForeColor = Color.FromArgb(236, 240, 241);
            btnBooks.Location = new Point(0, 130);
            btnBooks.Name = "btnBooks";
            btnBooks.Padding = new Padding(20, 0, 0, 0);
            btnBooks.Size = new Size(240, 50);
            btnBooks.TabIndex = 6;
            btnBooks.Text = "  📖  Quản lý sách";
            btnBooks.TextAlign = ContentAlignment.MiddleLeft;
            btnBooks.UseVisualStyleBackColor = false;
            btnBooks.Click += btnBooks_Click;
            btnBooks.MouseEnter += Button_MouseEnter;
            btnBooks.MouseLeave += Button_MouseLeave;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.Transparent;
            btnHome.Cursor = Cursors.Hand;
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 10F);
            btnHome.ForeColor = Color.FromArgb(236, 240, 241);
            btnHome.Location = new Point(0, 80);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(20, 0, 0, 0);
            btnHome.Size = new Size(240, 50);
            btnHome.TabIndex = 7;
            btnHome.Text = "  🏠  Trang chủ";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            btnHome.MouseEnter += Button_MouseEnter;
            btnHome.MouseLeave += Button_MouseLeave;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.FromArgb(23, 32, 38);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(240, 80);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "📚 BOOKSTORE";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // activeIndicator
            // 
            activeIndicator.Location = new Point(0, 0);
            activeIndicator.Name = "activeIndicator";
            activeIndicator.Size = new Size(200, 100);
            activeIndicator.TabIndex = 0;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(lblUser);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(240, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(20, 0, 20, 0);
            headerPanel.Size = new Size(960, 70);
            headerPanel.TabIndex = 1;
            // 
            // lblUser
            // 
            lblUser.Dock = DockStyle.Fill;
            lblUser.Font = new Font("Segoe UI", 12F);
            lblUser.ForeColor = Color.FromArgb(44, 62, 80);
            lblUser.Location = new Point(20, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(920, 70);
            lblUser.TabIndex = 0;
            lblUser.Text = "👤 Xin chào, User";
            lblUser.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(236, 240, 241);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(240, 70);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(10);
            mainPanel.Size = new Size(960, 630);
            mainPanel.TabIndex = 0;
            // 
            // MainDashboard
            // 
            ClientSize = new Size(1200, 700);
            Controls.Add(mainPanel);
            Controls.Add(headerPanel);
            Controls.Add(menuPanel);
            MinimumSize = new Size(1000, 600);
            Name = "MainDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard - Quản Lý Tiệm Sách";
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
        //private void SetActiveButton(Button activeBtn)
        //{
        //    foreach (Control ctrl in menuPanel.Controls)
        //    {
        //        if (ctrl is Button btn && btn != btnLogout)
        //        {
        //            btn.BackColor = Color.Transparent;
        //            btn.ForeColor = Color.FromArgb(236, 240, 241);
        //        }
        //    }
        //    activeBtn.BackColor = Color.FromArgb(52, 152, 219);
        //    activeBtn.ForeColor = Color.White;
        //}
    }
}