
using QuanLyTiemSach.StatisticFrms;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    public partial class MainDashboard : Form
    {
        private Form activeForm = null;
        public MainDashboard()
        {
            InitializeComponent();
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
            OpenChildForm(new FormUsers());
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
    }
}
