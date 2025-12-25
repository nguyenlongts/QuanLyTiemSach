using QuanLyTiemSach.BLL.Services;
using QuanLyTiemSach.Domain.Model;

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    public partial class FormCategory : Form
    {
        private readonly ICategoryService _categoryService;
        private int _selectedCategoryId = 0;

        public FormCategory(ICategoryService categoryService)
        {
            InitializeComponent();
            _categoryService = categoryService;

            // Setup events
            SetupEvents();

            // Load data
            LoadData();
        }

        private void SetupEvents()
        {
            // Subscribe to events
            dgvCategory.CellClick += dgvCategory_CellClick;
            btnSearch.Click += btnSearch_Click;
            btnRefresh.Click += btnRefresh_Click;
            txtSearch.KeyDown += txtSearch_KeyDown;
        }

        private void LoadData()
        {
            try
            {
                var categories = _categoryService.GetAllCategories();
                dgvCategory.DataSource = null;
                dgvCategory.DataSource = categories;

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
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

        private void btnAddCategoryMain_Click(object sender, EventArgs e)
        {
            try
            {
                var category = new Category
                {
                    Name = txtCategoryName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                var (success, message) = _categoryService.AddCategory(category);

                MessageBox.Show(message, success ? "Thành công" : "Lỗi",
                    MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (success)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditCategoryMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedCategoryId == 0)
                {
                    MessageBox.Show("Vui lòng chọn danh mục cần sửa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var category = new Category
                {
                    Id = _selectedCategoryId,
                    Name = txtCategoryName.Text.Trim(),
                    Description = txtDescription.Text.Trim()
                };

                var (success, message) = _categoryService.UpdateCategory(category);

                MessageBox.Show(message, success ? "Thành công" : "Lỗi",
                    MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (success)
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedCategoryId == 0)
                {
                    MessageBox.Show("Vui lòng chọn danh mục cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa danh mục này?\n\nMã: {_selectedCategoryId}\nTên: {txtCategoryName.Text}",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    var (success, message) = _categoryService.DeleteCategory(_selectedCategoryId);

                    MessageBox.Show(message, success ? "Thành công" : "Lỗi",
                        MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                    if (success)
                    {
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < dgvCategory.Rows.Count)
                {
                    DataGridViewRow row = dgvCategory.Rows[e.RowIndex];
                    if (row.Cells["Id"].Value != null)
                    {
                        _selectedCategoryId = Convert.ToInt32(row.Cells["Id"].Value);
                        txtCategoryName.Text = row.Cells["Name"].Value?.ToString() ?? "";
                        txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";

                        btnAdd.Enabled = false;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chọn dòng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                var categories = _categoryService.SearchCategories(keyword);
                dgvCategory.DataSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {

            dgvCategory.CellClick -= dgvCategory_CellClick;
            btnSearch.Click -= btnSearch_Click;
            btnRefresh.Click -= btnRefresh_Click;
            txtSearch.KeyDown -= txtSearch_KeyDown;

            base.OnFormClosing(e);
        }
    }
}

