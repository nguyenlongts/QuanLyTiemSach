namespace QuanLyTiemSach.CategoryFrms
{
    partial class FormAddCategory
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
            lblidcategory = new Label();
            lblCategoryName = new Label();
            lblCategoryDes = new Label();
            txtIdCategory = new TextBox();
            txtNameCategory = new TextBox();
            txtDesCategory = new TextBox();
            btnAddCategory = new Button();
            SuspendLayout();
            // 
            // lblidcategory
            // 
            lblidcategory.AutoSize = true;
            lblidcategory.Location = new Point(71, 92);
            lblidcategory.Name = "lblidcategory";
            lblidcategory.Size = new Size(22, 20);
            lblidcategory.TabIndex = 0;
            lblidcategory.Text = "Id";
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(71, 139);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(101, 20);
            lblCategoryName.TabIndex = 1;
            lblCategoryName.Text = "Tên danh mục";
            // 
            // lblCategoryDes
            // 
            lblCategoryDes.AutoSize = true;
            lblCategoryDes.Location = new Point(71, 190);
            lblCategoryDes.Name = "lblCategoryDes";
            lblCategoryDes.Size = new Size(48, 20);
            lblCategoryDes.TabIndex = 2;
            lblCategoryDes.Text = "Mô tả";
            // 
            // txtIdCategory
            // 
            txtIdCategory.Location = new Point(187, 92);
            txtIdCategory.Name = "txtIdCategory";
            txtIdCategory.Size = new Size(125, 27);
            txtIdCategory.TabIndex = 3;
            // 
            // txtNameCategory
            // 
            txtNameCategory.Location = new Point(187, 139);
            txtNameCategory.Name = "txtNameCategory";
            txtNameCategory.Size = new Size(125, 27);
            txtNameCategory.TabIndex = 4;
            // 
            // txtDesCategory
            // 
            txtDesCategory.Location = new Point(187, 187);
            txtDesCategory.Name = "txtDesCategory";
            txtDesCategory.Size = new Size(125, 27);
            txtDesCategory.TabIndex = 5;
            // 
            // btnAddCategory
            // 
            btnAddCategory.BackColor = SystemColors.ActiveCaption;
            btnAddCategory.Location = new Point(218, 238);
            btnAddCategory.Name = "btnAddCategory";
            btnAddCategory.Size = new Size(94, 29);
            btnAddCategory.TabIndex = 6;
            btnAddCategory.Text = "Thêm";
            btnAddCategory.UseVisualStyleBackColor = false;
            btnAddCategory.Click += btnAddCategory_Click;
            // 
            // FormAddCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 319);
            Controls.Add(btnAddCategory);
            Controls.Add(txtDesCategory);
            Controls.Add(txtNameCategory);
            Controls.Add(txtIdCategory);
            Controls.Add(lblCategoryDes);
            Controls.Add(lblCategoryName);
            Controls.Add(lblidcategory);
            Name = "FormAddCategory";
            Text = "FormAddCategory";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblidcategory;
        private Label lblCategoryName;
        private Label lblCategoryDes;
        private TextBox txtIdCategory;
        private TextBox txtNameCategory;
        private TextBox txtDesCategory;
        private Button btnAddCategory;
    }
}