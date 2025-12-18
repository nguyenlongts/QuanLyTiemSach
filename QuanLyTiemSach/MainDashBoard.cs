
using QuanLyTiemSach.APP;
using QuanLyTiemSach.Domain.Enums;
using QuanLyTiemSach.StatisticFrms;
using QuanLyTiemSach.UserFrms;
using System.Windows.Forms;
namespace QuanLyTiemSach
{
    public partial class MainDashboard : Form
    {
        private Form activeForm = null;
        public MainDashboard()
        {
            InitializeComponent();
            ApplyAuthorization();
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
        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormHome());
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormBooks());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new UserFrms.FormUsers());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormOrders());
        }

        private void btnManageCase_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormManagerShift());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCategory());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormStatistic());
        }


        private void ApplyAuthorization()
        {
            lblUser.Text = $"Xin chào, {AuthenSession.CurrentUser.Username}";

            if (AuthenSession.IsAdmin ==false)
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
    }
}
