namespace QuanLyTiemSach.APP
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

        private void InitializeComponent()
        {
            this.chartBookSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartBookSales)).BeginInit();
            this.SuspendLayout();

            // chartBookSales
            this.chartBookSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartBookSales.Name = "chartBookSales";
            this.chartBookSales.TabIndex = 0;

            // FrmBookStatistic
            this.Controls.Add(this.chartBookSales);
            this.Text = "Thống kê sách bán chạy";
            this.Load += new System.EventHandler(this.FrmBookStatistic_Load);

            ((System.ComponentModel.ISupportInitialize)(this.chartBookSales)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
