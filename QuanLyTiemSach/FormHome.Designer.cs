namespace QuanLyTiemSach
{
    partial class FormHome
    {
        private System.ComponentModel.IContainer components = null;

        #region UI Controls

        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Panel recentOrdersPanel;
        private System.Windows.Forms.Panel topBooksPanel;
        private System.Windows.Forms.Panel lowStockPanel;
        private System.Windows.Forms.Label lblDateTime;

        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblDateTime = new Label();
            statsPanel = new Panel();
            lblStats = new Label();
            recentOrdersPanel = new Panel();
            lblRecent = new Label();
            topBooksPanel = new Panel();
            lblTopBooks = new Label();
            lowStockPanel = new Panel();
            lblLowStock = new Label();
            statsPanel.SuspendLayout();
            recentOrdersPanel.SuspendLayout();
            topBooksPanel.SuspendLayout();
            lowStockPanel.SuspendLayout();
            SuspendLayout();
            // 
            // lblDateTime
            // 
            lblDateTime.AutoSize = true;
            lblDateTime.Font = new Font("Segoe UI", 10F);
            lblDateTime.Location = new Point(13, 8);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(41, 19);
            lblDateTime.TabIndex = 0;
            lblDateTime.Text = "Ngày";
            // 
            // statsPanel
            // 
            statsPanel.BackColor = Color.WhiteSmoke;
            statsPanel.Controls.Add(lblStats);
            statsPanel.Location = new Point(13, 30);
            statsPanel.Margin = new Padding(3, 2, 3, 2);
            statsPanel.Name = "statsPanel";
            statsPanel.Size = new Size(875, 98);
            statsPanel.TabIndex = 1;
            // 
            // lblStats
            // 
            lblStats.AutoSize = true;
            lblStats.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStats.Location = new Point(9, 8);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(81, 21);
            lblStats.TabIndex = 0;
            lblStats.Text = "Thống kê";
            // 
            // recentOrdersPanel
            // 
            recentOrdersPanel.BackColor = Color.WhiteSmoke;
            recentOrdersPanel.Controls.Add(lblRecent);
            recentOrdersPanel.Location = new Point(13, 135);
            recentOrdersPanel.Margin = new Padding(3, 2, 3, 2);
            recentOrdersPanel.Name = "recentOrdersPanel";
            recentOrdersPanel.Size = new Size(394, 150);
            recentOrdersPanel.TabIndex = 2;
            // 
            // lblRecent
            // 
            lblRecent.AutoSize = true;
            lblRecent.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRecent.Location = new Point(9, 8);
            lblRecent.Name = "lblRecent";
            lblRecent.Size = new Size(147, 21);
            lblRecent.TabIndex = 0;
            lblRecent.Text = "Đơn hàng vừa đặt";
            // 
            // topBooksPanel
            // 
            topBooksPanel.BackColor = Color.WhiteSmoke;
            topBooksPanel.Controls.Add(lblTopBooks);
            topBooksPanel.Location = new Point(420, 135);
            topBooksPanel.Margin = new Padding(3, 2, 3, 2);
            topBooksPanel.Name = "topBooksPanel";
            topBooksPanel.Size = new Size(468, 150);
            topBooksPanel.TabIndex = 3;
            // 
            // lblTopBooks
            // 
            lblTopBooks.AutoSize = true;
            lblTopBooks.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTopBooks.Location = new Point(9, 8);
            lblTopBooks.Name = "lblTopBooks";
            lblTopBooks.Size = new Size(82, 21);
            lblTopBooks.TabIndex = 0;
            lblTopBooks.Text = "Top Sách ";
            // 
            // lowStockPanel
            // 
            lowStockPanel.BackColor = Color.WhiteSmoke;
            lowStockPanel.Controls.Add(lblLowStock);
            lowStockPanel.Location = new Point(13, 300);
            lowStockPanel.Margin = new Padding(3, 2, 3, 2);
            lowStockPanel.Name = "lowStockPanel";
            lowStockPanel.Size = new Size(875, 105);
            lowStockPanel.TabIndex = 4;
            // 
            // lblLowStock
            // 
            lblLowStock.AutoSize = true;
            lblLowStock.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLowStock.Location = new Point(9, 8);
            lblLowStock.Name = "lblLowStock";
            lblLowStock.Size = new Size(148, 21);
            lblLowStock.TabIndex = 0;
            lblLowStock.Text = "Sách sắp hết hàng";
            // 
            // FormHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 420);
            Controls.Add(lblDateTime);
            Controls.Add(statsPanel);
            Controls.Add(recentOrdersPanel);
            Controls.Add(topBooksPanel);
            Controls.Add(lowStockPanel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormHome";
            Text = "Dashboard - Quản Lý Tiệm Sách";
            statsPanel.ResumeLayout(false);
            statsPanel.PerformLayout();
            recentOrdersPanel.ResumeLayout(false);
            recentOrdersPanel.PerformLayout();
            topBooksPanel.ResumeLayout(false);
            topBooksPanel.PerformLayout();
            lowStockPanel.ResumeLayout(false);
            lowStockPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStats;
        private Label lblRecent;
        private Label lblTopBooks;
        private Label lblLowStock;
    }
}
