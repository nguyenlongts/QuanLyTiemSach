using System.Windows.Forms;

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

        //private void InitializeComponent()
        //{
        //    lblDateTime = new Label();
        //    statsPanel = new Panel();
        //    lblStats = new Label();
        //    recentOrdersPanel = new Panel();
        //    dataGridView1 = new DataGridView();
        //    Column3 = new DataGridViewTextBoxColumn();
        //    lblRecent = new Label();
        //    topBooksPanel = new Panel();
        //    dataGridView2 = new DataGridView();
        //    Column1 = new DataGridViewTextBoxColumn();
        //    Column2 = new DataGridViewTextBoxColumn();
        //    lblTopBooks = new Label();
        //    lowStockPanel = new Panel();
        //    lblLowStock = new Label();
        //    statsPanel.SuspendLayout();
        //    recentOrdersPanel.SuspendLayout();
        //    ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        //    topBooksPanel.SuspendLayout();
        //    ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
        //    lowStockPanel.SuspendLayout();
        //    SuspendLayout();
        //    // 
        //    // lblDateTime
        //    // 
        //    lblDateTime.AutoSize = true;
        //    lblDateTime.Font = new Font("Segoe UI", 10F);
        //    lblDateTime.Location = new Point(13, 8);
        //    lblDateTime.Name = "lblDateTime";
        //    lblDateTime.Size = new Size(41, 19);
        //    lblDateTime.TabIndex = 0;
        //    lblDateTime.Text = "Ngày";
        //    // 
        //    // statsPanel
        //    // 
        //    statsPanel.BackColor = Color.WhiteSmoke;
        //    statsPanel.Controls.Add(lblStats);
        //    statsPanel.Location = new Point(13, 30);
        //    statsPanel.Margin = new Padding(3, 2, 3, 2);
        //    statsPanel.Name = "statsPanel";
        //    statsPanel.Size = new Size(875, 98);
        //    statsPanel.TabIndex = 1;
        //    // 
        //    // lblStats
        //    // 
        //    lblStats.AutoSize = true;
        //    lblStats.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        //    lblStats.Location = new Point(9, 8);
        //    lblStats.Name = "lblStats";
        //    lblStats.Size = new Size(81, 21);
        //    lblStats.TabIndex = 0;
        //    lblStats.Text = "Thống kê";
        //    // 
        //    // recentOrdersPanel
        //    // 
        //    recentOrdersPanel.BackColor = Color.WhiteSmoke;
        //    recentOrdersPanel.Controls.Add(dataGridView1);
        //    recentOrdersPanel.Controls.Add(lblRecent);
        //    recentOrdersPanel.Location = new Point(13, 135);
        //    recentOrdersPanel.Margin = new Padding(3, 2, 3, 2);
        //    recentOrdersPanel.Name = "recentOrdersPanel";
        //    recentOrdersPanel.Size = new Size(394, 150);
        //    recentOrdersPanel.TabIndex = 2;
        //    // 
        //    // dataGridView1
        //    // 
        //    dataGridView1.BackgroundColor = SystemColors.Window;
        //    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        //    dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column3 });
        //    dataGridView1.Location = new Point(3, 34);
        //    dataGridView1.Name = "dataGridView1";
        //    dataGridView1.Size = new Size(388, 113);
        //    dataGridView1.TabIndex = 1;
        //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    // 
        //    // Column3
        //    // 
        //    Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //    Column3.HeaderText = "Mã Đơn Hàng";
        //    Column3.Name = "Column3";
        //    Column3.Width = 106;
        //    // 
        //    // lblRecent
        //    // 
        //    lblRecent.AutoSize = true;
        //    lblRecent.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        //    lblRecent.Location = new Point(9, 8);
        //    lblRecent.Name = "lblRecent";
        //    lblRecent.Size = new Size(147, 21);
        //    lblRecent.TabIndex = 0;
        //    lblRecent.Text = "Đơn hàng vừa đặt";
        //    // 
        //    // topBooksPanel
        //    // 
        //    topBooksPanel.BackColor = Color.WhiteSmoke;
        //    topBooksPanel.Controls.Add(dataGridView2);
        //    topBooksPanel.Controls.Add(lblTopBooks);
        //    topBooksPanel.Location = new Point(420, 135);
        //    topBooksPanel.Margin = new Padding(3, 2, 3, 2);
        //    topBooksPanel.Name = "topBooksPanel";
        //    topBooksPanel.Size = new Size(468, 150);
        //    topBooksPanel.TabIndex = 3;
        //    // 
        //    // dataGridView2
        //    // 
        //    dataGridView2.BackgroundColor = SystemColors.Window;
        //    dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        //    dataGridView2.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
        //    dataGridView2.Location = new Point(9, 34);
        //    dataGridView2.Name = "dataGridView2";
        //    dataGridView2.Size = new Size(443, 111);
        //    dataGridView2.TabIndex = 2;
        //    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        //    // 
        //    // Column1
        //    // 
        //    Column1.HeaderText = "Tên sách";
        //    Column1.Name = "Column1";
        //    // 
        //    // Column2
        //    // 
        //    Column2.HeaderText = "Số lượng";
        //    Column2.Name = "Column2";
        //    // 
        //    // lblTopBooks
        //    // 
        //    lblTopBooks.AutoSize = true;
        //    lblTopBooks.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        //    lblTopBooks.Location = new Point(9, 8);
        //    lblTopBooks.Name = "lblTopBooks";
        //    lblTopBooks.Size = new Size(82, 21);
        //    lblTopBooks.TabIndex = 0;
        //    lblTopBooks.Text = "Top Sách ";
        //    // 
        //    // lowStockPanel
        //    // 
        //    lowStockPanel.BackColor = Color.WhiteSmoke;
        //    lowStockPanel.Controls.Add(lblLowStock);
        //    lowStockPanel.Location = new Point(13, 300);
        //    lowStockPanel.Margin = new Padding(3, 2, 3, 2);
        //    lowStockPanel.Name = "lowStockPanel";
        //    lowStockPanel.Size = new Size(875, 105);
        //    lowStockPanel.TabIndex = 4;
        //    // 
        //    // lblLowStock
        //    // 
        //    lblLowStock.AutoSize = true;
        //    lblLowStock.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        //    lblLowStock.Location = new Point(9, 8);
        //    lblLowStock.Name = "lblLowStock";
        //    lblLowStock.Size = new Size(148, 21);
        //    lblLowStock.TabIndex = 0;
        //    lblLowStock.Text = "Sách sắp hết hàng";
        //    // 
        //    // FormHome
        //    // 
        //    AutoScaleDimensions = new SizeF(7F, 15F);
        //    AutoScaleMode = AutoScaleMode.Font;
        //    ClientSize = new Size(910, 420);
        //    Controls.Add(lblDateTime);
        //    Controls.Add(statsPanel);
        //    Controls.Add(recentOrdersPanel);
        //    Controls.Add(topBooksPanel);
        //    Controls.Add(lowStockPanel);
        //    Margin = new Padding(3, 2, 3, 2);
        //    Name = "FormHome";
        //    Text = "Dashboard - Quản Lý Tiệm Sách";
        //    statsPanel.ResumeLayout(false);
        //    statsPanel.PerformLayout();
        //    recentOrdersPanel.ResumeLayout(false);
        //    recentOrdersPanel.PerformLayout();
        //    ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        //    topBooksPanel.ResumeLayout(false);
        //    topBooksPanel.PerformLayout();
        //    ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
        //    lowStockPanel.ResumeLayout(false);
        //    lowStockPanel.PerformLayout();
        //    ResumeLayout(false);
        //    PerformLayout();
        //}
        private void InitializeComponent()
        {
            lblDateTime = new Label();
            statsPanel = new Panel();
            lblStats = new Label();
            recentOrdersPanel = new Panel();
            dgv5LatestOrders = new DataGridView();
            Column3 = new DataGridViewTextBoxColumn();
            lblRecent = new Label();
            topBooksPanel = new Panel();
            dgv5BestSellBook = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            lblTopBooks = new Label();
            lowStockPanel = new Panel();
            lblLowStock = new Label();
            statsPanel.SuspendLayout();
            recentOrdersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv5LatestOrders).BeginInit();
            topBooksPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv5BestSellBook).BeginInit();
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
            recentOrdersPanel.Controls.Add(dgv5LatestOrders);
            recentOrdersPanel.Controls.Add(lblRecent);
            recentOrdersPanel.Location = new Point(13, 135);
            recentOrdersPanel.Margin = new Padding(3, 2, 3, 2);
            recentOrdersPanel.Name = "recentOrdersPanel";
            recentOrdersPanel.Size = new Size(394, 150);
            recentOrdersPanel.TabIndex = 2;
            // 
            // dgv5LatestOrders
            // 
            dgv5LatestOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv5LatestOrders.BackgroundColor = SystemColors.Window;
            dgv5LatestOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv5LatestOrders.Columns.AddRange(new DataGridViewColumn[] { Column3 });
            dgv5LatestOrders.Dock = DockStyle.Fill;
            dgv5LatestOrders.Location = new Point(0, 0);
            dgv5LatestOrders.Name = "dgv5LatestOrders";
            dgv5LatestOrders.Size = new Size(394, 150);
            dgv5LatestOrders.TabIndex = 0;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.HeaderText = "Mã Đơn Hàng";
            Column3.Name = "Column3";
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
            topBooksPanel.Controls.Add(dgv5BestSellBook);
            topBooksPanel.Controls.Add(lblTopBooks);
            topBooksPanel.Location = new Point(420, 135);
            topBooksPanel.Margin = new Padding(3, 2, 3, 2);
            topBooksPanel.Name = "topBooksPanel";
            topBooksPanel.Size = new Size(468, 150);
            topBooksPanel.TabIndex = 3;
            // 
            // dgv5BestSellBook
            // 
            dgv5BestSellBook.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv5BestSellBook.BackgroundColor = SystemColors.Window;
            dgv5BestSellBook.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv5BestSellBook.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dgv5BestSellBook.Dock = DockStyle.Fill;
            dgv5BestSellBook.Location = new Point(0, 0);
            dgv5BestSellBook.Name = "dgv5BestSellBook";
            dgv5BestSellBook.Size = new Size(468, 150);
            dgv5BestSellBook.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "Tên sách";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "Số lượng";
            Column2.Name = "Column2";
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
            ((System.ComponentModel.ISupportInitialize)dgv5LatestOrders).EndInit();
            topBooksPanel.ResumeLayout(false);
            topBooksPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv5BestSellBook).EndInit();
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
        private DataGridView dgv5LatestOrders;
        private DataGridView dgv5BestSellBook;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
    }
}
