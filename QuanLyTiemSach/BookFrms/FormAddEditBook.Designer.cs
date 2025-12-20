// ==================== FormAddEditBook.Designer.cs ====================
using QuanLyTiemSach.BLL.Services;
using QuanLyTiemSach.Domain.Model;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    partial class FormAddEditBook
    {
        private System.ComponentModel.IContainer components = null;
        private Panel headerPanel;
        private Label lblHeader;
        private Panel mainPanel;
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
        private Panel buttonPanel;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            lblHeader = new Label();
            mainPanel = new Panel();
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
            buttonPanel = new Panel();
            btnSave = new Button();
            btnCancel = new Button();

            headerPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPublishedYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            buttonPanel.SuspendLayout();
            SuspendLayout();

            // ================== HEADER PANEL ==================
            headerPanel.BackColor = Color.FromArgb(52, 152, 219);
            headerPanel.Controls.Add(lblHeader);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = 70;
            headerPanel.Padding = new Padding(20);

            // lblHeader
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Text = "📚 Thêm sách mới";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;

            // ================== MAIN PANEL ==================
            mainPanel.BackColor = Color.White;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Padding = new Padding(30, 20, 30, 20);
            mainPanel.AutoScroll = true;

            // Controls
            mainPanel.Controls.Add(cboCategory);
            mainPanel.Controls.Add(lblCategory);
            mainPanel.Controls.Add(numQuantity);
            mainPanel.Controls.Add(lblQuantity);
            mainPanel.Controls.Add(numPrice);
            mainPanel.Controls.Add(lblPrice);
            mainPanel.Controls.Add(numPublishedYear);
            mainPanel.Controls.Add(lblPublishedYear);
            mainPanel.Controls.Add(txtPublisher);
            mainPanel.Controls.Add(lblPublisher);
            mainPanel.Controls.Add(txtAuthor);
            mainPanel.Controls.Add(lblAuthor);
            mainPanel.Controls.Add(txtTitle);
            mainPanel.Controls.Add(lblTitle);
            mainPanel.Controls.Add(txtBookId);
            mainPanel.Controls.Add(lblBookId);

            // ================== FIELDS LAYOUT ==================
            int yPosition = 10;
            int labelHeight = 20;
            int controlHeight = 35;
            int spacing = 15;

            // BookID
            lblBookId.Location = new Point(30, yPosition);
            lblBookId.Size = new Size(150, labelHeight);
            lblBookId.Text = "Mã sách *";
            lblBookId.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            yPosition += labelHeight + 5;
            txtBookId.Location = new Point(30, yPosition);
            txtBookId.Size = new Size(300, controlHeight);
            txtBookId.Font = new Font("Segoe UI", 11F);

            yPosition += controlHeight + spacing;

            // Title
            lblTitle.Location = new Point(30, yPosition);
            lblTitle.Size = new Size(150, labelHeight);
            lblTitle.Text = "Tên sách *";
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            yPosition += labelHeight + 5;
            txtTitle.Location = new Point(30, yPosition);
            txtTitle.Size = new Size(500, controlHeight);
            txtTitle.Font = new Font("Segoe UI", 11F);

            yPosition += controlHeight + spacing;

            // Author
            lblAuthor.Location = new Point(30, yPosition);
            lblAuthor.Size = new Size(150, labelHeight);
            lblAuthor.Text = "Tác giả *";
            lblAuthor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            yPosition += labelHeight + 5;
            txtAuthor.Location = new Point(30, yPosition);
            txtAuthor.Size = new Size(350, controlHeight);
            txtAuthor.Font = new Font("Segoe UI", 11F);

            yPosition += controlHeight + spacing;

            // Publisher
            lblPublisher.Location = new Point(30, yPosition);
            lblPublisher.Size = new Size(150, labelHeight);
            lblPublisher.Text = "Nhà xuất bản";
            lblPublisher.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            yPosition += labelHeight + 5;
            txtPublisher.Location = new Point(30, yPosition);
            txtPublisher.Size = new Size(350, controlHeight);
            txtPublisher.Font = new Font("Segoe UI", 11F);

            yPosition += controlHeight + spacing;

            // Published Year
            lblPublishedYear.Location = new Point(30, yPosition);
            lblPublishedYear.Size = new Size(150, labelHeight);
            lblPublishedYear.Text = "Năm xuất bản";
            lblPublishedYear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            yPosition += labelHeight + 5;
            numPublishedYear.Location = new Point(30, yPosition);
            numPublishedYear.Size = new Size(150, controlHeight);
            numPublishedYear.Font = new Font("Segoe UI", 11F);
            numPublishedYear.Minimum = 1000;
            numPublishedYear.Maximum = DateTime.Now.Year;
            numPublishedYear.Value = DateTime.Now.Year;

            yPosition += controlHeight + spacing;

            // Price
            lblPrice.Location = new Point(30, yPosition);
            lblPrice.Size = new Size(150, labelHeight);
            lblPrice.Text = "Giá *";
            lblPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            yPosition += labelHeight + 5;
            numPrice.Location = new Point(30, yPosition);
            numPrice.Size = new Size(200, controlHeight);
            numPrice.Font = new Font("Segoe UI", 11F);
            numPrice.Minimum = 0;
            numPrice.Maximum = 999999999;
            numPrice.ThousandsSeparator = true;
            numPrice.DecimalPlaces = 0;

            yPosition += controlHeight + spacing;

            // Quantity
            lblQuantity.Location = new Point(30, yPosition);
            lblQuantity.Size = new Size(150, labelHeight);
            lblQuantity.Text = "Số lượng *";
            lblQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            yPosition += labelHeight + 5;
            numQuantity.Location = new Point(30, yPosition);
            numQuantity.Size = new Size(150, controlHeight);
            numQuantity.Font = new Font("Segoe UI", 11F);
            numQuantity.Minimum = 0;
            numQuantity.Maximum = 9999;

            yPosition += controlHeight + spacing;

            // Category
            lblCategory.Location = new Point(30, yPosition);
            lblCategory.Size = new Size(150, labelHeight);
            lblCategory.Text = "Danh mục *";
            lblCategory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            yPosition += labelHeight + 5;
            cboCategory.Location = new Point(30, yPosition);
            cboCategory.Size = new Size(300, controlHeight);
            cboCategory.Font = new Font("Segoe UI", 11F);
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            // ================== BUTTON PANEL ==================
            buttonPanel.BackColor = Color.FromArgb(236, 240, 241);
            buttonPanel.Dock = DockStyle.Bottom;
            buttonPanel.Height = 80;
            buttonPanel.Padding = new Padding(30, 15, 30, 15);
            buttonPanel.Controls.Add(btnCancel);
            buttonPanel.Controls.Add(btnSave);

            // btnSave
            btnSave.Location = new Point(30, 20);
            btnSave.Size = new Size(150, 45);
            btnSave.Text = "💾 Lưu";
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Click += btnSave_Click;

            // btnCancel
            btnCancel.Location = new Point(190, 20);
            btnCancel.Size = new Size(150, 45);
            btnCancel.Text = "❌ Hủy";
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += btnCancel_Click;

            // ================== FORM ==================
            ClientSize = new Size(600, 650);
            Controls.Add(mainPanel);
            Controls.Add(buttonPanel);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Thêm/Sửa sách";

            headerPanel.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPublishedYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}

