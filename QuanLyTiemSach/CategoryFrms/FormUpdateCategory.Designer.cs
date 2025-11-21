namespace QuanLyTiemSach.CategoryFrms
{
    partial class FormUpdateCategory
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
            btnn = new Button();
            txtDesCategory = new TextBox();
            txtNameCategory = new TextBox();
            txtIdCategory = new TextBox();
            lblCategoryDes = new Label();
            lblCategoryName = new Label();
            lblidcategory = new Label();
            SuspendLayout();
            // 
            // btnn
            // 
            btnn.BackColor = SystemColors.ActiveCaption;
            btnn.Location = new Point(267, 231);
            btnn.Name = "btnn";
            btnn.Size = new Size(94, 29);
            btnn.TabIndex = 13;
            btnn.Text = "Thêm";
            btnn.UseVisualStyleBackColor = false;
            btnn.Click += btnUpdate_Click;
            // 
            // txtDesCategory
            // 
            txtDesCategory.Location = new Point(236, 180);
            txtDesCategory.Name = "txtDesCategory";
            txtDesCategory.Size = new Size(125, 27);
            txtDesCategory.TabIndex = 12;
            // 
            // txtNameCategory
            // 
            txtNameCategory.Location = new Point(236, 132);
            txtNameCategory.Name = "txtNameCategory";
            txtNameCategory.Size = new Size(125, 27);
            txtNameCategory.TabIndex = 11;
            // 
            // txtIdCategory
            // 
            txtIdCategory.Location = new Point(236, 85);
            txtIdCategory.Name = "txtIdCategory";
            txtIdCategory.Size = new Size(125, 27);
            txtIdCategory.TabIndex = 10;
            // 
            // lblCategoryDes
            // 
            lblCategoryDes.AutoSize = true;
            lblCategoryDes.Location = new Point(120, 183);
            lblCategoryDes.Name = "lblCategoryDes";
            lblCategoryDes.Size = new Size(48, 20);
            lblCategoryDes.TabIndex = 9;
            lblCategoryDes.Text = "Mô tả";
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(120, 132);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(101, 20);
            lblCategoryName.TabIndex = 8;
            lblCategoryName.Text = "Tên danh mục";
            // 
            // lblidcategory
            // 
            lblidcategory.AutoSize = true;
            lblidcategory.Location = new Point(120, 85);
            lblidcategory.Name = "lblidcategory";
            lblidcategory.Size = new Size(22, 20);
            lblidcategory.TabIndex = 7;
            lblidcategory.Text = "Id";
            // 
            // FormUpdateCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 333);
            Controls.Add(btnn);
            Controls.Add(txtDesCategory);
            Controls.Add(txtNameCategory);
            Controls.Add(txtIdCategory);
            Controls.Add(lblCategoryDes);
            Controls.Add(lblCategoryName);
            Controls.Add(lblidcategory);
            Name = "FormUpdateCategory";
            Text = "FormUpdateCategory";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnn;
        private TextBox txtDesCategory;
        private TextBox txtNameCategory;
        private TextBox txtIdCategory;
        private Label lblCategoryDes;
        private Label lblCategoryName;
        private Label lblidcategory;
    }
}