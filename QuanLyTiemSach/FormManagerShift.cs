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
    public partial class FormManagerShift : Form
    {
        public FormManagerShift()
        {
            InitializeComponent();
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            cbShift.Items.AddRange(new string[] { "Ca sáng (7:00 - 11:00)", "Ca trưa (11:00 - 15:00)", "Ca chiều (15:00 - 19:00)", "Ca tối (19:00 - 23:00)" });
            cbEmployee.Items.AddRange(new string[] { "Nguyễn Văn A", "Trần Thị B", "Lê Văn C", "Phạm Thị D" });


            gridShift.Rows.Add("Nguyễn Văn A", "2025-01-01", "Ca trưa");
            gridShift.Rows.Add("Trần Thị B", "2025-01-01", "Ca sáng");
            gridShift.Rows.Add("Lê Văn C", "2025-01-02", "Ca chiều");
            gridShift.Rows.Add("Phạm Thị D", "2025-01-02", "Ca tối");
            gridShift.Rows.Add("Trần Thị B", "2025-01-03", "Ca sáng");
        }

        private void cbShift_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedEmployee = cbEmployee.SelectedItem?.ToString();
            string selectedDate = dpShift.Value.ToString("yyyy-MM-dd");
            string selectedShift = cbShift.SelectedItem?.ToString();
            gridShift.Rows.Add(selectedEmployee, selectedDate, selectedShift);
        }
    }
}
