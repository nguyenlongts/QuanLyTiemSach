using Microsoft.Extensions.DependencyInjection;
using QuanLyTiemSach.APP;
using QuanLyTiemSach.BLL.Services;
using QuanLyTiemSach.Domain.Enums;
using QuanLyTiemSach.UserFrms;
using System.Windows.Forms;
using WorkShiftManagement.Forms;

using QuanLyTiemSach.SalaryFrms;
using QuanLyTiemSach.StatisticFrms;


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
            btnBooks_Click(btnBooks, EventArgs.Empty);
            this.FormClosed += (s, e) =>
            {
                Application.Exit();
            };

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
            foreach (Control ctrl in menuPanel.Controls)
            {
                if (ctrl is Button btn && btn != btnLogout)
                {
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.FromArgb(236, 240, 241);
                }
            }
            if (button != null && button != btnLogout)
            {
                button.BackColor = Color.FromArgb(52, 152, 219);
                button.ForeColor = Color.White;
                currentButton = button;
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
                var shiftService = ServiceDI.GetWorkShiftService();
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
                var bookService = ServiceDI.GetBookService();
                OpenChildForm(new FormCategory(categoryService,bookService));
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
                btnUsers.Visible = false;
                btnThongKe.Visible = false;
                btnManageCase.Visible = false;
                btnBooks.Visible = true;
                btnOrders.Visible = true;
                btnCategory.Visible = true;
            }
            else
            {
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

        private void btnSalary_Click(object sender, EventArgs e)
        {
            try
            {
                var salaryService = ServiceDI.GetSalaryService();
                OpenChildForm(new FormSalary(salaryService));
                SetActiveButton(sender as Button);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi mở form tính tiền: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.BackColor == Color.Transparent)
            {
                btn.BackColor = Color.FromArgb(44, 62, 80);
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.BackColor != Color.FromArgb(52, 152, 219))
            {
                btn.BackColor = Color.Transparent;
            }
        }

        private void BtnLogout_MouseEnter(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(231, 76, 60);
        }

        private void BtnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.FromArgb(192, 57, 43);
        }

    }
}