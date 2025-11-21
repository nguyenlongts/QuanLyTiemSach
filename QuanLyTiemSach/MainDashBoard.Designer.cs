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
            btnCategory = new Button();
            btnManageCase = new Button();
            lblUser = new Label();
            btnHome = new Button();
            btnBooks = new Button();
            btnUsers = new Button();
            btnOrders = new Button();
            btnLogout = new Button();
            mainPanel = new Panel();
            menuPanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuPanel
            // 
            menuPanel.BackColor = Color.FromArgb(41, 128, 185);
            menuPanel.Controls.Add(btnCategory);
            menuPanel.Controls.Add(btnManageCase);
            menuPanel.Controls.Add(lblUser);
            menuPanel.Controls.Add(btnHome);
            menuPanel.Controls.Add(btnBooks);
            menuPanel.Controls.Add(btnUsers);
            menuPanel.Controls.Add(btnOrders);
            menuPanel.Controls.Add(btnLogout);
            menuPanel.Location = new Point(0, 0);
            menuPanel.Name = "menuPanel";
            menuPanel.Size = new Size(200, 600);
            menuPanel.TabIndex = 0;
            // 
            // btnCategory
            // 
            btnCategory.Location = new Point(0, 371);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(200, 50);
            btnCategory.TabIndex = 8;
            btnCategory.Text = "Danh mục";
            btnCategory.UseVisualStyleBackColor = true;
            btnCategory.Click += btnCategory_Click;
            // 
            // btnManageCase
            // 
            btnManageCase.Location = new Point(0, 299);
            btnManageCase.Name = "btnManageCase";
            btnManageCase.Size = new Size(200, 50);
            btnManageCase.TabIndex = 7;
            btnManageCase.Text = "Quản lý ca làm";
            btnManageCase.UseVisualStyleBackColor = true;
            btnManageCase.Click += btnManageCase_Click;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUser.ForeColor = Color.White;
            lblUser.Location = new Point(10, 10);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(123, 23);
            lblUser.TabIndex = 1;
            lblUser.Text = "Xin chào, User";
            // 
            // btnHome
            // 
            btnHome.Location = new Point(0, 50);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(200, 50);
            btnHome.TabIndex = 2;
            btnHome.Text = "Trang chủ";
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // btnBooks
            // 
            btnBooks.Location = new Point(0, 110);
            btnBooks.Name = "btnBooks";
            btnBooks.Size = new Size(200, 50);
            btnBooks.TabIndex = 3;
            btnBooks.Text = "Sách";
            btnBooks.UseVisualStyleBackColor = true;
            btnBooks.Click += btnBooks_Click;
            // 
            // btnUsers
            // 
            btnUsers.Location = new Point(0, 170);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(200, 50);
            btnUsers.TabIndex = 4;
            btnUsers.Text = "Người dùng";
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnOrders
            // 
            btnOrders.Location = new Point(0, 230);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(200, 50);
            btnOrders.TabIndex = 5;
            btnOrders.Text = "Hóa đơn";
            btnOrders.UseVisualStyleBackColor = true;
            btnOrders.Click += btnOrders_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(3, 447);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(200, 50);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.LightGray;
            mainPanel.Location = new Point(200, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(800, 600);
            mainPanel.TabIndex = 7;
            // 
            // MainDashboard
            // 
            ClientSize = new Size(1000, 600);
            Controls.Add(menuPanel);
            Controls.Add(mainPanel);
            Name = "MainDashboard";
            Text = "Dashboard - Quản Lý Tiệm Sách";
            menuPanel.ResumeLayout(false);
            menuPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnManageCase;
        private Button btnCategory;
    }
}
