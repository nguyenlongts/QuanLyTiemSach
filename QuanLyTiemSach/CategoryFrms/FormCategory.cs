using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.Domain.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    public partial class FormCategory : Form
    {
        private readonly ICategoryService _categoryService;
        private readonly IBookService _bookService;
        private int _selectedCategoryId;

        public FormCategory(
            ICategoryService categoryService,
            IBookService bookService)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _bookService = bookService;

            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                dgvCategory.DataSource = null;
                dgvCategory.DataSource = await _categoryService.GetAllCategoriesAsync();
                if (dgvCategory.Columns.Contains("Books"))
                {
                    dgvCategory.Columns["Books"].Visible = false;
                }
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            _selectedCategoryId = 0;
            txtCategoryName.Clear();
            txtDescription.Clear();
            txtCategoryName.Focus();

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var category = new Category
                {
                    Name = txtCategoryName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                await _categoryService.AddCategoryAsync(category);

                MessageBox.Show("Thêm danh mục thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedCategoryId == 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa!");
                return;
            }

            try
            {
                var category = new Category
                {
                    Id = _selectedCategoryId,
                    Name = txtCategoryName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                await _categoryService.UpdateCategoryAsync(category);

                MessageBox.Show("Cập nhật thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCategoryId == 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục!");
                return;
            }

            try
            {
                var confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa danh mục này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes)
                    return;

                await _categoryService.DeleteCategoryAsync(_selectedCategoryId);

                MessageBox.Show("Xóa danh mục thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dgvCategory.DataSource = await _categoryService
                    .SearchCategoriesAsync(txtSearch.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            await LoadDataAsync();
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvCategory.Rows[e.RowIndex];
            _selectedCategoryId = Convert.ToInt32(row.Cells["Id"].Value);

            txtCategoryName.Text = row.Cells["Name"].Value?.ToString();
            txtDescription.Text = row.Cells["Description"].Value?.ToString();

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
    }
}
