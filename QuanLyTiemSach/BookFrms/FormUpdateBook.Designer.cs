namespace QuanLyTiemSach.BookFrms
{
    partial class FormUpdateBook
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
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
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 30);
            label1.Text = "Book ID";
            // 
            // txtId
            // 
            txtId.Location = new Point(140, 27);
            txtId.Size = new Size(180, 23);
            // 
            // txtName
            // 
            txtName.Location = new Point(140, 67);
            txtName.Size = new Size(180, 23);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 70);
            label2.Text = "Tên sách";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(140, 107);
            txtAuthor.Size = new Size(180, 23);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 110);
            label3.Text = "Tác giả";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(140, 147);
            txtPrice.Size = new Size(180, 23);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 150);
            label4.Text = "Giá";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(140, 200);
            btnUpdate.Size = new Size(120, 35);
            btnUpdate.Text = "Cập nhật";
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FormUpdateBook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 280);
            Controls.Add(btnUpdate);
            Controls.Add(txtPrice);
            Controls.Add(label4);
            Controls.Add(txtAuthor);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Text = "Cập nhật sách";
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
        private Button btnUpdate;
    }
}
