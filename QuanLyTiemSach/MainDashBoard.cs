using Microsoft.Extensions.DependencyInjection;
using QuanLyTiemSach.APP;
using QuanLyTiemSach.BLL.Services;
using QuanLyTiemSach.Domain.Enums;
using QuanLyTiemSach.UserFrms;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    public partial class MainDashboard : Form
    {
        private Form activeForm = null;
        private Button currentButton = null;

        public MainDashboard()
        {
            InitializeComponent();
            ApplyAuthorization();
            btnHome_Click(btnHome, EventArgs.Empty);
        }

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;

            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(activeForm);
            this.mainPanel.Tag = activeForm;
            activeForm.BringToFront();
            activeForm.Show();
        }

        private void SetActiveButton(Button button)
        {
            if (currentButton != null)
            {
                // Reset màu button cũ
                currentButton.BackColor = SystemColors.Control;
                currentButton.ForeColor = Color.Black;
            }

            // Highlight button mới
            if (button != null)
            {
                button.BackColor = Color.FromArgb(41, 128, 185);
                button.ForeColor = Color.White;
                currentButton = button;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new FormHome());
                SetActiveButton(sender as Button);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở trang chủ: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            try
            {
                var bookService = ServiceDI.GetBookService();
                OpenChildForm(new FormBooks(bookService));
                SetActiveButton(sender as Button);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form quản lý sách: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new UserFrms.FormUsers());
                SetActiveButton(sender as Button);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form quản lý người dùng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new FormOrders());
                SetActiveButton(sender as Button);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form quản lý đơn hàng: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManageCase_Click(object sender, EventArgs e)
        {
            try
            {
                OpenChildForm(new FormManagerShift());
                SetActiveButton(sender as Button);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form quản lý ca làm: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            try
            {
                var categoryService = ServiceDI.GetCategoryService();
                OpenChildForm(new FormCategory(categoryService));
                SetActiveButton(sender as Button);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form quản lý danh mục: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {

            try
            {
                var orderService = ServiceDI.GetOrderService();
                OpenChildForm(new FormStatistic(orderService));
                SetActiveButton(sender as Button);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form thống kê: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyAuthorization()
        {
            lblUser.Text = $"Xin chào, {AuthenSession.CurrentUser.Username}";

            if (AuthenSession.IsAdmin == false)
            {
                // Nhân viên thường
                btnUsers.Visible = false;
                btnThongKe.Visible = false;
                btnManageCase.Visible = false;
                btnBooks.Visible = true;
                btnOrders.Visible = true;
                btnCategory.Visible = true;
            }
            else
            {
                // Admin
                btnUsers.Visible = true;
                btnThongKe.Visible = true;
                btnManageCase.Visible = true;
                btnBooks.Visible = true;
                btnOrders.Visible = true;
                btnCategory.Visible = true;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}