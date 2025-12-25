
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
    public partial class FormAddCategory : Form


    {
        public Category category { get; private set; }
        public FormAddCategory()
        {
            InitializeComponent();
        }


        private void btnAddCategory_Click(object sender, EventArgs e)
        {

            var category = new Category
            {
                Id = int.Parse(txtIdCategory.Text.Trim()),
                Name = txtNameCategory.Text.Trim(),
                Description = txtDesCategory.Text.Trim()
            };

            if (!category.IsValid(out string msg))
            {
                MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.category = category;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
