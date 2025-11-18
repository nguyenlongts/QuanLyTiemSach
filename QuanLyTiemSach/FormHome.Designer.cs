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
            this.components = new System.ComponentModel.Container();

            this.lblDateTime = new System.Windows.Forms.Label();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.recentOrdersPanel = new System.Windows.Forms.Panel();
            this.topBooksPanel = new System.Windows.Forms.Panel();
            this.lowStockPanel = new System.Windows.Forms.Panel();

            this.SuspendLayout();

            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDateTime.Location = new System.Drawing.Point(15, 10);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(100, 23);
            this.lblDateTime.TabIndex = 0;
            this.lblDateTime.Text = "Ngày";


            this.statsPanel.Location = new System.Drawing.Point(15, 40);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(1000, 130);
            this.statsPanel.TabIndex = 1;
            this.statsPanel.BackColor = System.Drawing.Color.WhiteSmoke;


            var lblStats = new System.Windows.Forms.Label();
            lblStats.Text = "Thống kê";
            lblStats.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblStats.AutoSize = true;
            lblStats.Location = new System.Drawing.Point(10, 10);
            this.statsPanel.Controls.Add(lblStats);

            this.recentOrdersPanel.Location = new System.Drawing.Point(15, 180);
            this.recentOrdersPanel.Name = "recentOrdersPanel";
            this.recentOrdersPanel.Size = new System.Drawing.Size(450, 200);
            this.recentOrdersPanel.TabIndex = 2;
            this.recentOrdersPanel.BackColor = System.Drawing.Color.WhiteSmoke;

            var lblRecent = new System.Windows.Forms.Label();
            lblRecent.Text = "Đơn hàng vừa đặt";
            lblRecent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblRecent.AutoSize = true;
            lblRecent.Location = new System.Drawing.Point(10, 10);
            this.recentOrdersPanel.Controls.Add(lblRecent);

            this.topBooksPanel.Location = new System.Drawing.Point(480, 180);
            this.topBooksPanel.Name = "topBooksPanel";
            this.topBooksPanel.Size = new System.Drawing.Size(450, 200);
            this.topBooksPanel.TabIndex = 3;
            this.topBooksPanel.BackColor = System.Drawing.Color.WhiteSmoke;

            var lblTopBooks = new System.Windows.Forms.Label();
            lblTopBooks.Text = "Top Sách ";
            lblTopBooks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTopBooks.AutoSize = true;
            lblTopBooks.Location = new System.Drawing.Point(10, 10);
            this.topBooksPanel.Controls.Add(lblTopBooks);

            this.lowStockPanel.Location = new System.Drawing.Point(15, 400);
            this.lowStockPanel.Name = "lowStockPanel";
            this.lowStockPanel.Size = new System.Drawing.Size(1000, 140);
            this.lowStockPanel.TabIndex = 4;
            this.lowStockPanel.BackColor = System.Drawing.Color.WhiteSmoke;


            var lblLowStock = new System.Windows.Forms.Label();
            lblLowStock.Text = "Sách sắp hết hàng";
            lblLowStock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblLowStock.AutoSize = true;
            lblLowStock.Location = new System.Drawing.Point(10, 10);
            this.lowStockPanel.Controls.Add(lblLowStock);


            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 560);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.statsPanel);
            this.Controls.Add(this.recentOrdersPanel);
            this.Controls.Add(this.topBooksPanel);
            this.Controls.Add(this.lowStockPanel);
            this.Name = "FormHome";
            this.Text = "Dashboard - Quản Lý Tiệm Sách";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
