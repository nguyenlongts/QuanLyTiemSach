namespace QuanLyTiemSach.OrderFrms
{
    partial class FormOrderDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblHeader;

        private System.Windows.Forms.Panel customerPanel;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblCustomerPhone;
        private System.Windows.Forms.Label lblCustomerAddress;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.TextBox txtCustomerAddress;
        private System.Windows.Forms.Button btnSearchCustomer;

        private System.Windows.Forms.Panel itemsPanel;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;

        private System.Windows.Forms.Panel summaryPanel;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            this.components = new System.ComponentModel.Container();

            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();

            this.customerPanel = new System.Windows.Forms.Panel();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerPhone = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.lblCustomerAddress = new System.Windows.Forms.Label();
            this.txtCustomerAddress = new System.Windows.Forms.TextBox();

            this.itemsPanel = new System.Windows.Forms.Panel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();

            this.summaryPanel = new System.Windows.Forms.Panel();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.SuspendLayout();

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tạo Hóa Đơn Mới";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

     
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Height = 60;
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.headerPanel.Controls.Add(this.lblHeader);

       
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Text = "📋 TẠO HÓA ĐƠN MỚI";
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.customerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.customerPanel.Height = 140;
            this.customerPanel.Padding = new System.Windows.Forms.Padding(20);

            this.lblCustomerName.Text = "Tên khách hàng:";
            this.lblCustomerName.Location = new System.Drawing.Point(20, 20);

            // txtCustomerName
            this.txtCustomerName.Location = new System.Drawing.Point(20, 45);
            this.txtCustomerName.Width = 250;

            
            this.lblCustomerPhone.Text = "Số điện thoại:";
            this.lblCustomerPhone.Location = new System.Drawing.Point(290, 20);

            // txtCustomerPhone
            this.txtCustomerPhone.Location = new System.Drawing.Point(290, 45);
            this.txtCustomerPhone.Width = 200;

            this.btnSearchCustomer.Text = "🔍 Tìm";
            this.btnSearchCustomer.Location = new System.Drawing.Point(500, 43);
            this.btnSearchCustomer.Click += new System.EventHandler(this.BtnSearchCustomer_Click);

            this.lblCustomerAddress.Text = "Địa chỉ:";
            this.lblCustomerAddress.Location = new System.Drawing.Point(20, 80);

            this.txtCustomerAddress.Location = new System.Drawing.Point(20, 105);
            this.txtCustomerAddress.Width = 560;

            this.customerPanel.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.lblCustomerName,
                this.txtCustomerName,
                this.lblCustomerPhone,
                this.txtCustomerPhone,
                this.btnSearchCustomer,
                this.lblCustomerAddress,
                this.txtCustomerAddress
            });

            this.itemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsPanel.Padding = new System.Windows.Forms.Padding(20);
            this.itemsPanel.Controls.Add(this.dgvItems);

            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.ReadOnly = true;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
 
            this.summaryPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.summaryPanel.Height = 100;
            this.summaryPanel.Padding = new System.Windows.Forms.Padding(20);

     
            this.lblTotalAmount.Text = "TỔNG TIỀN: 0 đ";
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.Dock = System.Windows.Forms.DockStyle.Top;

            this.btnSave.Text = "💾 Lưu hóa đơn";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            this.btnCancel.Text = "Hủy";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;

            this.summaryPanel.Controls.Add(this.lblTotalAmount);

            this.Controls.Add(this.itemsPanel);
            this.Controls.Add(this.summaryPanel);
            this.Controls.Add(this.customerPanel);
            this.Controls.Add(this.headerPanel);

            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
