namespace QuanLyTiemSach
{
    partial class FormCategory
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
            lblCateogy = new Label();
            btnCategoryMain = new Button();
            btnEditCategory = new Button();
            btnDelete = new Button();
            dgvCategory = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).BeginInit();
            SuspendLayout();
            // 
            // lblCateogy
            // 
            lblCateogy.BackColor = SystemColors.MenuHighlight;
            lblCateogy.Dock = DockStyle.Top;
            lblCateogy.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCateogy.ForeColor = SystemColors.ButtonHighlight;
            lblCateogy.Location = new Point(0, 0);
            lblCateogy.Name = "lblCateogy";
            lblCateogy.Size = new Size(800, 51);
            lblCateogy.TabIndex = 0;
            lblCateogy.Text = "Quản lý danh mục";
            // 
            // btnCategoryMain
            // 
            btnCategoryMain.BackColor = Color.FromArgb(0, 192, 0);
            btnCategoryMain.ForeColor = Color.White;
            btnCategoryMain.Location = new Point(44, 376);
            btnCategoryMain.Name = "btnCategoryMain";
            btnCategoryMain.Size = new Size(116, 43);
            btnCategoryMain.TabIndex = 1;
            btnCategoryMain.Text = "Thêm";
            btnCategoryMain.UseVisualStyleBackColor = false;
            btnCategoryMain.Click += btnAddCategoryMain_Click;
            // 
            // btnEditCategory
            // 
            btnEditCategory.BackColor = Color.Goldenrod;
            btnEditCategory.ForeColor = Color.White;
            btnEditCategory.Location = new Point(169, 376);
            btnEditCategory.Name = "btnEditCategory";
            btnEditCategory.Size = new Size(111, 43);
            btnEditCategory.TabIndex = 2;
            btnEditCategory.Text = "Sửa";
            btnEditCategory.UseVisualStyleBackColor = false;
            btnEditCategory.Click += btnEditCategoryMain_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(286, 376);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 43);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgvCategory
            // 
            dgvCategory.BackgroundColor = Color.White;
            dgvCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategory.Location = new Point(13, 79);
            dgvCategory.Name = "dgvCategory";
            dgvCategory.RowHeadersWidth = 51;
            dgvCategory.Size = new Size(775, 282);
            dgvCategory.TabIndex = 4;
            // 
            // FormCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvCategory);
            Controls.Add(btnDelete);
            Controls.Add(btnEditCategory);
            Controls.Add(btnCategoryMain);
            Controls.Add(lblCateogy);
            Name = "FormCategory";
            Text = "FormCategory";
            ((System.ComponentModel.ISupportInitialize)dgvCategory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblCateogy;
        private Button btnCategoryMain;
        private Button btnEditCategory;
        private Button btnDelete;
        private DataGridView dgvCategory;
    }
}