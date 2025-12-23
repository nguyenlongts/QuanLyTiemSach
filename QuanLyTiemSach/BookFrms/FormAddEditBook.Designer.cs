using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    partial class FormAddEditBook
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Label lblHeader;

        private GroupBox groupBookInfo;
        private Label lblBookId;
        private TextBox txtBookId;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblAuthor;
        private TextBox txtAuthor;
        private Label lblPublisher;
        private TextBox txtPublisher;
        private Label lblPublishedYear;
        private NumericUpDown numPublishedYear;
        private Label lblPrice;
        private NumericUpDown numPrice;
        private Label lblQuantity;
        private NumericUpDown numQuantity;
        private Label lblCategory;
        private ComboBox cboCategory;

        private GroupBox groupActions;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblHeader = new Label();
            groupBookInfo = new GroupBox();
            lblBookId = new Label();
            txtBookId = new TextBox();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblAuthor = new Label();
            txtAuthor = new TextBox();
            lblPublisher = new Label();
            txtPublisher = new TextBox();
            lblPublishedYear = new Label();
            numPublishedYear = new NumericUpDown();
            lblPrice = new Label();
            numPrice = new NumericUpDown();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            lblCategory = new Label();
            cboCategory = new ComboBox();
            groupActions = new GroupBox();
            btnSave = new Button();
            btnCancel = new Button();
            panelHeader.SuspendLayout();
            groupBookInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPublishedYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            groupActions.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(52, 152, 219);
            panelHeader.Controls.Add(lblHeader);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(700, 60);
            panelHeader.TabIndex = 2;
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(700, 60);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Thêm / Sửa thông tin sách";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBookInfo
            // 
            groupBookInfo.Controls.Add(lblBookId);
            groupBookInfo.Controls.Add(txtBookId);
            groupBookInfo.Controls.Add(lblTitle);
            groupBookInfo.Controls.Add(txtTitle);
            groupBookInfo.Controls.Add(lblAuthor);
            groupBookInfo.Controls.Add(txtAuthor);
            groupBookInfo.Controls.Add(lblPublisher);
            groupBookInfo.Controls.Add(txtPublisher);
            groupBookInfo.Controls.Add(lblPublishedYear);
            groupBookInfo.Controls.Add(numPublishedYear);
            groupBookInfo.Controls.Add(lblPrice);
            groupBookInfo.Controls.Add(numPrice);
            groupBookInfo.Controls.Add(lblQuantity);
            groupBookInfo.Controls.Add(numQuantity);
            groupBookInfo.Controls.Add(lblCategory);
            groupBookInfo.Controls.Add(cboCategory);
            groupBookInfo.Location = new Point(20, 80);
            groupBookInfo.Name = "groupBookInfo";
            groupBookInfo.Size = new Size(660, 420);
            groupBookInfo.TabIndex = 1;
            groupBookInfo.TabStop = false;
            groupBookInfo.Text = "Thông tin sách";
            // 
            // lblBookId
            // 
            lblBookId.Location = new Point(20, 30);
            lblBookId.Name = "lblBookId";
            lblBookId.Size = new Size(100, 23);
            lblBookId.TabIndex = 0;
            lblBookId.Text = "Mã sách";
            // 
            // txtBookId
            // 
            txtBookId.Location = new Point(150, 27);
            txtBookId.Name = "txtBookId";
            txtBookId.Size = new Size(200, 23);
            txtBookId.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(20, 70);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 23);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Tên sách";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(150, 67);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(460, 23);
            txtTitle.TabIndex = 3;
            // 
            // lblAuthor
            // 
            lblAuthor.Location = new Point(20, 110);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(100, 23);
            lblAuthor.TabIndex = 4;
            lblAuthor.Text = "Tác giả";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(150, 107);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(300, 23);
            txtAuthor.TabIndex = 5;
            // 
            // lblPublisher
            // 
            lblPublisher.Location = new Point(20, 150);
            lblPublisher.Name = "lblPublisher";
            lblPublisher.Size = new Size(100, 23);
            lblPublisher.TabIndex = 6;
            lblPublisher.Text = "Nhà xuất bản";
            // 
            // txtPublisher
            // 
            txtPublisher.Location = new Point(150, 147);
            txtPublisher.Name = "txtPublisher";
            txtPublisher.Size = new Size(300, 23);
            txtPublisher.TabIndex = 7;
            // 
            // lblPublishedYear
            // 
            lblPublishedYear.Location = new Point(20, 190);
            lblPublishedYear.Name = "lblPublishedYear";
            lblPublishedYear.Size = new Size(100, 23);
            lblPublishedYear.TabIndex = 8;
            lblPublishedYear.Text = "Năm xuất bản";
            // 
            // numPublishedYear
            // 
            numPublishedYear.Location = new Point(150, 187);
            numPublishedYear.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numPublishedYear.Name = "numPublishedYear";
            numPublishedYear.Size = new Size(120, 23);
            numPublishedYear.TabIndex = 9;
            // 
            // lblPrice
            // 
            lblPrice.Location = new Point(20, 230);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(100, 23);
            lblPrice.TabIndex = 10;
            lblPrice.Text = "Giá";
            // 
            // numPrice
            // 
            numPrice.Location = new Point(150, 227);
            numPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(120, 23);
            numPrice.TabIndex = 11;
            // 
            // lblQuantity
            // 
            lblQuantity.Location = new Point(20, 270);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(100, 23);
            lblQuantity.TabIndex = 12;
            lblQuantity.Text = "Số lượng";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(150, 267);
            numQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(120, 23);
            numQuantity.TabIndex = 13;
            // 
            // lblCategory
            // 
            lblCategory.Location = new Point(20, 310);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(100, 23);
            lblCategory.TabIndex = 14;
            lblCategory.Text = "Danh mục";
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.Location = new Point(150, 307);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(300, 23);
            cboCategory.TabIndex = 15;
            // 
            // groupActions
            // 
            groupActions.Controls.Add(btnSave);
            groupActions.Controls.Add(btnCancel);
            groupActions.Location = new Point(20, 520);
            groupActions.Name = "groupActions";
            groupActions.Size = new Size(660, 80);
            groupActions.TabIndex = 0;
            groupActions.TabStop = false;
            groupActions.Text = "Thao tác";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(400, 30);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 0;
            btnSave.Text = "Lưu";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(510, 30);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            // 
            // FormAddEditBook
            // 
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(700, 630);
            Controls.Add(groupActions);
            Controls.Add(groupBookInfo);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FormAddEditBook";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm / Sửa thông tin sách";
            panelHeader.ResumeLayout(false);
            groupBookInfo.ResumeLayout(false);
            groupBookInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPublishedYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            groupActions.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
