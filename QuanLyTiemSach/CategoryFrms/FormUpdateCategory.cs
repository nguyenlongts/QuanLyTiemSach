
using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyTiemSach.CategoryFrms
{
    public partial class FormUpdateCategory : Form
    {

        public Category category { get; private set; }
        public FormUpdateCategory(Category category)
        {
            InitializeComponent();
            txtIdCategory.Enabled = false;
            txtIdCategory.Text = category.Id.ToString();
            txtNameCategory.Text = category.Name;
            txtDesCategory.Text = category.Description;

            this.category= category;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateCategory(out string msg, out decimal price))
            {
                MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            category.Description = txtDesCategory.Text.Trim();
            category.Name = txtNameCategory.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateCategory(out string errorMessage, out decimal price)
        {
            errorMessage = string.Empty;
            price = 0;

            if (string.IsNullOrWhiteSpace(txtNameCategory.Text))
            {
                errorMessage = "Tên danh mục trống!";
                txtNameCategory.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDesCategory.Text))
            {
                errorMessage = "Chưa nhập mô tả của danh mục!";
                txtDesCategory.Focus();
                return false;
            }

            return true;
        }
    }
}
