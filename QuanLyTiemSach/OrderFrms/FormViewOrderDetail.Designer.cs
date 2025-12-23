using System.Windows.Forms;

namespace QuanLyTiemSach.OrderFrms
{
    partial class FormViewOrderDetail : Form
    {
        private System.ComponentModel.IContainer components = null;

        private Panel headerPanel;
        private Label lblHeader;
        private Panel infoPanel;
        private Label lblOrderId, lblOrderDate, lblCustomerName, lblCustomerPhone;
        private DataGridView dgvItems;
        private Panel summaryPanel;
        private Label lblTotalAmount;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            // Form
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Chi Tiết Hóa Đơn";

            this.ResumeLayout(false);
        }

        #endregion
    }
}
