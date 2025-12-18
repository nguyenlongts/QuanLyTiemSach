using System.Drawing;
using System.Windows.Forms;

namespace QuanLyTiemSach.BookFrms
{
    partial class FormAddBook
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private Label lblTitle;
        private Label lblId;
        private Label lblName;
        private Label lblAuthor;
        private Label lblPrice;
        private Label lblCategory;

        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtAuthor;
        private TextBox txtPrice;
        private TextBox txtCategoryId;

        private Button btnAdd;
        private Button btnCancel;

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblId = new Label();
            lblName = new Label();
            lblAuthor = new Label();
            lblPrice = new Label();
            lblCategory = new Label();

            txtId = new TextBox();
            txtName = new TextBox();
            txtAuthor = new TextBox();
            txtPrice = new TextBox();
            txtCategoryId = new TextBox();

            btnAdd = new Button();
            btnCancel = new Button();

            SuspendLayout();

            // ===== Title =====
            lblTitle.Text = "THÊM SÁCH MỚI";
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(90, 15);
            lblTitle.AutoSize = true;

            // ===== Labels =====
            lblId.Text = "Book ID:";
            lblName.Text = "Tên sách:";
            lblAuthor.Text = "Tác giả:";
            lblPrice.Text = "Giá:";
            lblCategory.Text = "Category ID:";

            lblId.Location = new Point(40, 70);
            lblName.Location = new Point(40, 110);
            lblAuthor.Location = new Point(40, 150);
            lblPrice.Location = new Point(40, 190);
            lblCategory.Location = new Point(40, 230);

            // ===== TextBoxes =====
            txtId.Location = new Point(150, 67);
            txtName.Location = new Point(150, 107);
            txtAuthor.Location = new Point(150, 147);
            txtPrice.Location = new Point(150, 187);
            txtCategoryId.Location = new Point(150, 227);

            txtId.Width = txtName.Width = txtAuthor.Width = txtPrice.Width = txtCategoryId.Width = 170;

            // ===== Buttons =====
            btnAdd.Text = "Lưu";
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(90, 280);
            btnAdd.Size = new Size(100, 35);
            btnAdd.Click += btnAdd_Click;

            btnCancel.Text = "Hủy";
            btnCancel.BackColor = Color.FromArgb(231, 76, 60);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(210, 280);
            btnCancel.Size = new Size(100, 35);
            btnCancel.Click += (s, e) => Close();

            // ===== Form =====
            ClientSize = new Size(380, 340);
            Controls.AddRange(new Control[]
            {
                lblTitle,
                lblId, lblName, lblAuthor, lblPrice, lblCategory,
                txtId, txtName, txtAuthor, txtPrice, txtCategoryId,
                btnAdd, btnCancel
            });

            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            Text = "Add Book";

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
