using System.Windows.Forms;

namespace QuanLyTiemSach.BookFrms
{
    partial class FormAddBook
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

        private void InitializeComponent()
        {
            label1 = new Label();
            txtId = new TextBox();
            txtName = new TextBox();
            label2 = new Label();
            txtAuthor = new TextBox();
            label3 = new Label();
            txtPrice = new TextBox();
            label4 = new Label();
            btnAdd = new Button();
            SuspendLayout();

            // label1
            label1.AutoSize = true;
            label1.Location = new Point(50, 40);
            label1.Text = "Book ID";

            // txtId
            txtId.Location = new Point(150, 37);
            txtId.Size = new Size(150, 23);

            // label2
            label2.AutoSize = true;
            label2.Location = new Point(50, 80);
            label2.Text = "Name";

            // txtName
            txtName.Location = new Point(150, 77);
            txtName.Size = new Size(150, 23);

            // label3
            label3.AutoSize = true;
            label3.Location = new Point(50, 120);
            label3.Text = "Author";

            // txtAuthor
            txtAuthor.Location = new Point(150, 117);
            txtAuthor.Size = new Size(150, 23);

            // label4
            label4.AutoSize = true;
            label4.Location = new Point(50, 160);
            label4.Text = "Price";

            // txtPrice
            txtPrice.Location = new Point(150, 157);
            txtPrice.Size = new Size(150, 23);

            // btnAdd
            btnAdd.Location = new Point(150, 210);
            btnAdd.Size = new Size(100, 35);
            btnAdd.Text = "Add Book";
            btnAdd.Click += btnAdd_Click;

            // FormAddBook
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 300);
            Controls.Add(label1);
            Controls.Add(txtId);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(txtAuthor);
            Controls.Add(label4);
            Controls.Add(txtPrice);
            Controls.Add(btnAdd);
            Text = "Add Book";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtId;
        private TextBox txtName;
        private Label label2;
        private TextBox txtAuthor;
        private Label label3;
        private TextBox txtPrice;
        private Label label4;
        private Button btnAdd;
    }
}
