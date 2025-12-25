using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.Domain.Model;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    public partial class FormCategory : Form
    {
        private readonly ICategoryService _categoryService;
        private int _selectedCategoryId;
        private readonly IBookService _bookService;

        public FormCategory(ICategoryService categoryService,IBookService bookService)
        {
            InitializeComponent();
            _categoryService = categoryService;
            _bookService = bookService;

            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            dgvCategory.DataSource = null;
            dgvCategory.DataSource = await _categoryService.GetAllCategoriesAsync();
            ClearForm();
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
            var category = new Category
            {
                Name = txtCategoryName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            if (await _categoryService.AddCategoryAsync(category))
            {
                MessageBox.Show("Thêm danh mục thành công!");
                await LoadDataAsync();
            }
            else
            {
                MessageBox.Show("Thêm danh mục thất bại!");
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedCategoryId == 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa!");
                return;
            }

            var category = new Category
            {
                Id = _selectedCategoryId,
                Name = txtCategoryName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            if (await _categoryService.UpdateCategoryAsync(category))
            {
                MessageBox.Show("Cập nhật thành công!");
                await LoadDataAsync();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCategoryId == 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục!");
                return;
            }

            var books = await _bookService.GetBooksByCategoryAsync(_selectedCategoryId);

            if (books.Any())
            {
                var confirm = MessageBox.Show(
                    $"Danh mục này có {books.Count} sách.\n" +
                    "Xóa danh mục sẽ xóa toàn bộ sách.\n\nBạn có chắc chắn?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes)
                    return;
            }

            bool success = await _categoryService.DeleteCategoryAsync(_selectedCategoryId);

            MessageBox.Show(
                success ? "Xóa thành công!" : "Xóa thất bại!",
                "Thông báo");

            if (success)
                await LoadDataAsync();
        }


        private async void btnSearch_Click(object sender, EventArgs e)
        {
            dgvCategory.DataSource = await _categoryService
                .SearchCategoriesAsync(txtSearch.Text.Trim());
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            await LoadDataAsync();
        }

        private async void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await Task.Run(() => { });
                btnSearch.PerformClick();
                e.SuppressKeyPress = true;
            }
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
