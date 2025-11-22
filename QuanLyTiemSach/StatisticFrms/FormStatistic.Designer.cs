namespace QuanLyTiemSach.StatisticFrms
{
    partial class FormStatistic
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            lblDoanhThu = new Label();
            chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            btnXemDoanhThu = new Button();
            cbTimeRangeDt = new ComboBox();
            lbll = new Label();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).BeginInit();
            SuspendLayout();
            // 
            // lblDoanhThu
            // 
            lblDoanhThu.BackColor = SystemColors.Highlight;
            lblDoanhThu.Dock = DockStyle.Top;
            lblDoanhThu.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDoanhThu.ForeColor = Color.White;
            lblDoanhThu.Location = new Point(0, 0);
            lblDoanhThu.Name = "lblDoanhThu";
            lblDoanhThu.Size = new Size(800, 54);
            lblDoanhThu.TabIndex = 1;
            lblDoanhThu.Text = "Thống kê doanh thu";
            // 
            // chartDoanhThu
            // 
            chartArea1.AxisX.Title = "Tháng";
            chartArea1.AxisX.TitleAlignment = StringAlignment.Far;
            chartArea1.AxisX2.Title = "zz";
            chartArea1.AxisY.Title = "Triệu đồng";
            chartArea1.Name = "ChartArea1";
            chartDoanhThu.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartDoanhThu.Legends.Add(legend1);
            chartDoanhThu.Location = new Point(31, 63);
            chartDoanhThu.Name = "chartDoanhThu";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Sách";
            chartDoanhThu.Series.Add(series1);
            chartDoanhThu.Size = new Size(375, 375);
            chartDoanhThu.TabIndex = 2;
            chartDoanhThu.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Biểu đồ doanh thu";
            chartDoanhThu.Titles.Add(title1);
            // 
            // btnXemDoanhThu
            // 
            btnXemDoanhThu.BackColor = SystemColors.ActiveCaption;
            btnXemDoanhThu.Location = new Point(625, 172);
            btnXemDoanhThu.Name = "btnXemDoanhThu";
            btnXemDoanhThu.Size = new Size(94, 31);
            btnXemDoanhThu.TabIndex = 3;
            btnXemDoanhThu.Text = "Lọc";
            btnXemDoanhThu.UseVisualStyleBackColor = false;
            btnXemDoanhThu.Click += btnXemDoanhThu_Click;
            // 
            // cbTimeRangeDt
            // 
            cbTimeRangeDt.FormattingEnabled = true;
            cbTimeRangeDt.Location = new Point(534, 126);
            cbTimeRangeDt.Name = "cbTimeRangeDt";
            cbTimeRangeDt.Size = new Size(185, 28);
            cbTimeRangeDt.TabIndex = 4;
            // 
            // lbll
            // 
            lbll.AutoSize = true;
            lbll.Location = new Point(606, 87);
            lbll.Name = "lbll";
            lbll.Size = new Size(113, 20);
            lbll.TabIndex = 5;
            lbll.Text = "Xem doanh thu:";
            // 
            // FormStatistic
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbll);
            Controls.Add(cbTimeRangeDt);
            Controls.Add(btnXemDoanhThu);
            Controls.Add(chartDoanhThu);
            Controls.Add(lblDoanhThu);
            Name = "FormStatistic";
            Text = "FormStatistic";
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblDoanhThu;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private Button btnXemDoanhThu;
        private ComboBox cbTimeRangeDt;
        private Label lbll;
    }
}