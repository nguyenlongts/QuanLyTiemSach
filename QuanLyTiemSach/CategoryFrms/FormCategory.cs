using QuanLyTiemSach.BookFrms;
using QuanLyTiemSach.CategoryFrms;
using QuanLyTiemSach.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    public partial class FormCategory : Form
    {
        public FormCategory()
        {
            InitializeComponent();
            LoadSampleData();
        }

        public void LoadSampleData()
        {
            dgvCategory.Columns.Add("CategoryID", "ID");
            dgvCategory.Columns.Add("CategoryName", "Tên danh mục");
            dgvCategory.Columns.Add("Description", "Mô tả");

            dgvCategory.Rows.Add(1, "Văn học", "Sách thuộc thể loại văn học");
            dgvCategory.Rows.Add(2, "Khoa học", "Sách thuộc thể loại khoa học");
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void panelButtons_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddCategoryMain_Click(object sender, EventArgs e)
        {
            FormAddCategory addCategoryForm = new FormAddCategory();

            if (addCategoryForm.ShowDialog() == DialogResult.OK)
            {
                Category newCategory = addCategoryForm.category;
                dgvCategory.Rows.Add(newCategory.Id, newCategory.Name, newCategory.Description);
            }
        }
        private void btnEditCategoryMain_Click(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count == 0)
                return;

            var row = dgvCategory.SelectedRows[0];
            Category selectedCategory = new Category
            {
                Id =(int) row.Cells["CategoryID"].Value,
                Name = row.Cells["CategoryName"].Value.ToString(),
                Description = row.Cells["Description"].Value.ToString(),
            };

            FormUpdateCategory updateForm = new FormUpdateCategory(selectedCategory);


            if (updateForm.ShowDialog() == DialogResult.OK)
            {

                row.Cells["CategoryName"].Value = selectedCategory.Name;
                row.Cells["Description"].Value = selectedCategory.Description;
            }
        }


    }
}
