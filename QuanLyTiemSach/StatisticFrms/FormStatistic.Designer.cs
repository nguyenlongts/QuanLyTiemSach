
﻿using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyTiemSach.StatisticFrms
{
    partial class FormStatistic
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBookSales;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            ChartArea chartArea3 = new ChartArea();
            Legend legend3 = new Legend();
            Series series3 = new Series();
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlTopStats = new Panel();
            pnlTotalRevenue = new Panel();
            lblTotalRevenueValue = new Label();
            lblTotalRevenue = new Label();
            pnlTotalOrders = new Panel();
            lblTotalOrdersValue = new Label();
            lblTotalOrders = new Label();
            pnlAvgOrder = new Panel();
            lblAvgOrderValue = new Label();
            lblAvgOrder = new Label();
            pnlBestMonth = new Panel();
            lblBestMonthValue = new Label();
            lblBestMonth = new Label();
            pnlFilters = new Panel();
            lblFilterTitle = new Label();
            rbYear = new RadioButton();
            rbMonth = new RadioButton();
            cbYear = new ComboBox();
            cbMonth = new ComboBox();
            cbChartType = new ComboBox();
            lblChartType = new Label();
            btnFilter = new Button();
            btnExport = new Button();
            pnlCharts = new Panel();
            chartDoanhThu = new Chart();
            pnlHeader.SuspendLayout();
            pnlTopStats.SuspendLayout();
            pnlTotalRevenue.SuspendLayout();
            pnlTotalOrders.SuspendLayout();
            pnlAvgOrder.SuspendLayout();
            pnlBestMonth.SuspendLayout();
            pnlFilters.SuspendLayout();
            pnlCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(41, 128, 185);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 2, 3, 2);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(932, 52);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 11);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(390, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📊 Thống Kê Doanh Thu";
            // 
            // pnlTopStats
            // 
            pnlTopStats.BackColor = Color.FromArgb(236, 240, 241);
            pnlTopStats.Controls.Add(pnlTotalRevenue);
            pnlTopStats.Controls.Add(pnlTotalOrders);
            pnlTopStats.Controls.Add(pnlAvgOrder);
            pnlTopStats.Controls.Add(pnlBestMonth);
            pnlTopStats.Location = new Point(0, 52);
            pnlTopStats.Margin = new Padding(3, 2, 3, 2);
            pnlTopStats.Name = "pnlTopStats";
            pnlTopStats.Padding = new Padding(18, 15, 18, 8);
            pnlTopStats.Size = new Size(929, 90);
            pnlTopStats.TabIndex = 1;
            // 
            // pnlTotalRevenue
            // 
            pnlTotalRevenue.BackColor = Color.FromArgb(46, 204, 113);
            pnlTotalRevenue.Controls.Add(lblTotalRevenueValue);
            pnlTotalRevenue.Controls.Add(lblTotalRevenue);
            pnlTotalRevenue.Location = new Point(7, 15);
            pnlTotalRevenue.Margin = new Padding(3, 2, 3, 2);
            pnlTotalRevenue.Name = "pnlTotalRevenue";
            pnlTotalRevenue.Size = new Size(209, 68);
            pnlTotalRevenue.TabIndex = 0;
            // 
            // lblTotalRevenueValue
            // 
            lblTotalRevenueValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalRevenueValue.ForeColor = Color.White;
            lblTotalRevenueValue.Location = new Point(7, 26);
            lblTotalRevenueValue.Name = "lblTotalRevenueValue";
            lblTotalRevenueValue.Size = new Size(197, 34);
            lblTotalRevenueValue.TabIndex = 1;
            lblTotalRevenueValue.Text = "0 VNĐ";
            lblTotalRevenueValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.Font = new Font("Segoe UI", 11F);
            lblTotalRevenue.ForeColor = Color.White;
            lblTotalRevenue.Location = new Point(9, 8);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(197, 19);
            lblTotalRevenue.TabIndex = 0;
            lblTotalRevenue.Text = "💰 Tổng Doanh Thu";
            lblTotalRevenue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlTotalOrders
            // 
            pnlTotalOrders.BackColor = Color.FromArgb(52, 152, 219);
            pnlTotalOrders.Controls.Add(lblTotalOrdersValue);
            pnlTotalOrders.Controls.Add(lblTotalOrders);
            pnlTotalOrders.Location = new Point(237, 15);
            pnlTotalOrders.Margin = new Padding(3, 2, 3, 2);
            pnlTotalOrders.Name = "pnlTotalOrders";
            pnlTotalOrders.Size = new Size(209, 68);
            pnlTotalOrders.TabIndex = 1;
            // 
            // lblTotalOrdersValue
            // 
            lblTotalOrdersValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalOrdersValue.ForeColor = Color.White;
            lblTotalOrdersValue.Location = new Point(9, 26);
            lblTotalOrdersValue.Name = "lblTotalOrdersValue";
            lblTotalOrdersValue.Size = new Size(200, 34);
            lblTotalOrdersValue.TabIndex = 1;
            lblTotalOrdersValue.Text = "0";
            lblTotalOrdersValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.Font = new Font("Segoe UI", 11F);
            lblTotalOrders.ForeColor = Color.White;
            lblTotalOrders.Location = new Point(9, 8);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(200, 19);
            lblTotalOrders.TabIndex = 0;
            lblTotalOrders.Text = "📦 Tổng Đơn Hàng";
            lblTotalOrders.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlAvgOrder
            // 
            pnlAvgOrder.BackColor = Color.FromArgb(155, 89, 182);
            pnlAvgOrder.Controls.Add(lblAvgOrderValue);
            pnlAvgOrder.Controls.Add(lblAvgOrder);
            pnlAvgOrder.Location = new Point(469, 15);
            pnlAvgOrder.Margin = new Padding(3, 2, 3, 2);
            pnlAvgOrder.Name = "pnlAvgOrder";
            pnlAvgOrder.Size = new Size(209, 68);
            pnlAvgOrder.TabIndex = 2;
            // 
            // lblAvgOrderValue
            // 
            lblAvgOrderValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblAvgOrderValue.ForeColor = Color.White;
            lblAvgOrderValue.Location = new Point(9, 26);
            lblAvgOrderValue.Name = "lblAvgOrderValue";
            lblAvgOrderValue.Size = new Size(197, 34);
            lblAvgOrderValue.TabIndex = 1;
            lblAvgOrderValue.Text = "0 VNĐ";
            lblAvgOrderValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAvgOrder
            // 
            lblAvgOrder.Font = new Font("Segoe UI", 11F);
            lblAvgOrder.ForeColor = Color.White;
            lblAvgOrder.Location = new Point(9, 8);
            lblAvgOrder.Name = "lblAvgOrder";
            lblAvgOrder.Size = new Size(197, 19);
            lblAvgOrder.TabIndex = 0;
            lblAvgOrder.Text = "📈 Giá Trị Trung Bình";
            lblAvgOrder.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBestMonth
            // 
            pnlBestMonth.BackColor = Color.FromArgb(230, 126, 34);
            pnlBestMonth.Controls.Add(lblBestMonthValue);
            pnlBestMonth.Controls.Add(lblBestMonth);
            pnlBestMonth.Location = new Point(715, 15);
            pnlBestMonth.Margin = new Padding(3, 2, 3, 2);
            pnlBestMonth.Name = "pnlBestMonth";
            pnlBestMonth.Size = new Size(209, 68);
            pnlBestMonth.TabIndex = 3;
            // 
            // lblBestMonthValue
            // 
            lblBestMonthValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblBestMonthValue.ForeColor = Color.White;
            lblBestMonthValue.Location = new Point(9, 26);
            lblBestMonthValue.Name = "lblBestMonthValue";
            lblBestMonthValue.Size = new Size(197, 34);
            lblBestMonthValue.TabIndex = 1;
            lblBestMonthValue.Text = "Tháng --";
            lblBestMonthValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBestMonth
            // 
            lblBestMonth.Font = new Font("Segoe UI", 11F);
            lblBestMonth.ForeColor = Color.White;
            lblBestMonth.Location = new Point(9, 8);
            lblBestMonth.Name = "lblBestMonth";
            lblBestMonth.Size = new Size(197, 19);
            lblBestMonth.TabIndex = 0;
            lblBestMonth.Text = "🏆 Cao Nhất";
            lblBestMonth.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.White;
            pnlFilters.Controls.Add(lblFilterTitle);
            pnlFilters.Controls.Add(rbYear);
            pnlFilters.Controls.Add(rbMonth);
            pnlFilters.Controls.Add(cbYear);
            pnlFilters.Controls.Add(cbMonth);
            pnlFilters.Controls.Add(cbChartType);
            pnlFilters.Controls.Add(lblChartType);
            pnlFilters.Controls.Add(btnFilter);
            pnlFilters.Controls.Add(btnExport);
            pnlFilters.Location = new Point(0, 150);
            pnlFilters.Margin = new Padding(3, 2, 3, 2);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(935, 60);
            pnlFilters.TabIndex = 2;
            // 
            // lblFilterTitle
            // 
            lblFilterTitle.AutoSize = true;
            lblFilterTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFilterTitle.ForeColor = Color.FromArgb(52, 73, 94);
            lblFilterTitle.Location = new Point(5, 21);
            lblFilterTitle.Name = "lblFilterTitle";
            lblFilterTitle.Size = new Size(87, 21);
            lblFilterTitle.TabIndex = 0;
            lblFilterTitle.Text = "Xem theo:";
            // 
            // rbYear
            // 
            rbYear.AutoSize = true;
            rbYear.Checked = true;
            rbYear.Font = new Font("Segoe UI", 10F);
            rbYear.Location = new Point(107, 21);
            rbYear.Margin = new Padding(3, 2, 3, 2);
            rbYear.Name = "rbYear";
            rbYear.Size = new Size(56, 23);
            rbYear.TabIndex = 1;
            rbYear.TabStop = true;
            rbYear.Text = "Năm";
            rbYear.UseVisualStyleBackColor = true;
            rbYear.CheckedChanged += rbYear_CheckedChanged;
            // 
            // rbMonth
            // 
            rbMonth.AutoSize = true;
            rbMonth.Font = new Font("Segoe UI", 10F);
            rbMonth.Location = new Point(172, 21);
            rbMonth.Margin = new Padding(3, 2, 3, 2);
            rbMonth.Name = "rbMonth";
            rbMonth.Size = new Size(65, 23);
            rbMonth.TabIndex = 2;
            rbMonth.Text = "Tháng";
            rbMonth.UseVisualStyleBackColor = true;
            rbMonth.CheckedChanged += rbMonth_CheckedChanged;
            // 
            // cbYear
            // 
            cbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cbYear.Font = new Font("Segoe UI", 11F);
            cbYear.FormattingEnabled = true;
            cbYear.Location = new Point(247, 20);
            cbYear.Margin = new Padding(3, 2, 3, 2);
            cbYear.Name = "cbYear";
            cbYear.Size = new Size(106, 28);
            cbYear.TabIndex = 3;
            // 
            // cbMonth
            // 
            cbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMonth.Enabled = false;
            cbMonth.Font = new Font("Segoe UI", 11F);
            cbMonth.FormattingEnabled = true;
            cbMonth.Location = new Point(365, 20);
            cbMonth.Margin = new Padding(3, 2, 3, 2);
            cbMonth.Name = "cbMonth";
            cbMonth.Size = new Size(106, 28);
            cbMonth.TabIndex = 4;
            // 
            // cbChartType
            // 
            cbChartType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbChartType.Font = new Font("Segoe UI", 11F);
            cbChartType.FormattingEnabled = true;
            cbChartType.Location = new Point(592, 20);
            cbChartType.Margin = new Padding(3, 2, 3, 2);
            cbChartType.Name = "cbChartType";
            cbChartType.Size = new Size(103, 28);
            cbChartType.TabIndex = 6;
            // 
            // lblChartType
            // 
            lblChartType.AutoSize = true;
            lblChartType.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblChartType.ForeColor = Color.FromArgb(52, 73, 94);
            lblChartType.Location = new Point(480, 21);
            lblChartType.Name = "lblChartType";
            lblChartType.Size = new Size(110, 21);
            lblChartType.TabIndex = 5;
            lblChartType.Text = "Loại Biểu Đồ:";
            // 
            // btnFilter
            // 
            btnFilter.BackColor = Color.FromArgb(41, 128, 185);
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(706, 20);
            btnFilter.Margin = new Padding(3, 2, 3, 2);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(91, 28);
            btnFilter.TabIndex = 7;
            btnFilter.Text = "🔍 Xem";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(39, 174, 96);
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(806, 20);
            btnExport.Margin = new Padding(3, 2, 3, 2);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(118, 30);
            btnExport.TabIndex = 8;
            btnExport.Text = "📥 Xuất Excel";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // pnlCharts
            // 
            pnlCharts.BackColor = Color.FromArgb(236, 240, 241);
            pnlCharts.Controls.Add(chartDoanhThu);
            pnlCharts.Location = new Point(0, 218);
            pnlCharts.Margin = new Padding(3, 2, 3, 2);
            pnlCharts.Name = "pnlCharts";
            pnlCharts.Size = new Size(935, 338);
            pnlCharts.TabIndex = 3;
            // 
            // chartDoanhThu
            // 
            chartArea3.AxisX.LabelStyle.Font = new Font("Segoe UI", 9F);
            chartArea3.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea3.AxisX.Title = "Thời gian";
            chartArea3.AxisX.TitleFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            chartArea3.AxisY.LabelStyle.Font = new Font("Segoe UI", 9F);
            chartArea3.AxisY.LabelStyle.Format = "{0:N0}";
            chartArea3.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea3.AxisY.Title = "Doanh Thu (Triệu VNĐ)";
            chartArea3.AxisY.TitleFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            chartArea3.BackColor = Color.White;
            chartArea3.Name = "ChartArea1";
            chartDoanhThu.ChartAreas.Add(chartArea3);
            legend3.Font = new Font("Segoe UI", 9F);
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            chartDoanhThu.Legends.Add(legend3);
            chartDoanhThu.Location = new Point(9, 21);
            chartDoanhThu.Margin = new Padding(3, 2, 3, 2);
            chartDoanhThu.Name = "chartDoanhThu";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Doanh Thu";
            chartDoanhThu.Series.Add(series3);
            chartDoanhThu.Size = new Size(923, 315);
            chartDoanhThu.TabIndex = 0;
            // 
            // FormStatistic
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(973, 570);
            Controls.Add(pnlCharts);
            Controls.Add(pnlFilters);
            Controls.Add(pnlTopStats);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormStatistic";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống Kê Doanh Thu";
            Load += FormStatistic_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlTopStats.ResumeLayout(false);
            pnlTotalRevenue.ResumeLayout(false);
            pnlTotalOrders.ResumeLayout(false);
            pnlAvgOrder.ResumeLayout(false);
            pnlBestMonth.ResumeLayout(false);
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            pnlCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlTopStats;
        private Panel pnlTotalRevenue;
        private Label lblTotalRevenueValue;
        private Label lblTotalRevenue;
        private Panel pnlTotalOrders;
        private Label lblTotalOrdersValue;
        private Label lblTotalOrders;
        private Panel pnlAvgOrder;
        private Label lblAvgOrderValue;
        private Label lblAvgOrder;
        private Panel pnlBestMonth;
        private Label lblBestMonthValue;
        private Label lblBestMonth;
        private Panel pnlFilters;
        private Label lblFilterTitle;
        private RadioButton rbYear;
        private RadioButton rbMonth;
        private ComboBox cbYear;
        private ComboBox cbMonth;
        private ComboBox cbChartType;
        private Label lblChartType;
        private Button btnFilter;
        private Button btnExport;
        private Panel pnlCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
    }
}
