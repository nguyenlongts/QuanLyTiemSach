namespace QuanLyTiemSach.BookFrms
{
    partial class FormUpdateBook
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
            label1.Location = new Point(50, 40);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 0;
            label1.Text = "Book ID";
            // 
            // txtId
            // 
            txtId.Location = new Point(150, 37);
            txtId.Name = "txtId";
            txtId.Size = new Size(150, 23);
            txtId.TabIndex = 1;
            txtId.ReadOnly = true;
            txtId.BackColor = System.Drawing.SystemColors.Control;
            // 
            // txtName
            // 
            txtName.Location = new Point(150, 77);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 23);
            txtName.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 80);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 3;
            label2.Text = "Name";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(150, 117);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(150, 23);
            txtAuthor.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 120);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 4;
            label3.Text = "Author";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(150, 157);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(150, 23);
            txtPrice.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 160);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 5;
            label4.Text = "Price";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(150, 210);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 35);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Update Book";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FormUpdateBook
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 300);
            Controls.Add(btnUpdate);
            Controls.Add(txtPrice);
            Controls.Add(label4);
            Controls.Add(txtAuthor);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Name = "FormUpdateBook";
            Text = "Update Book";
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