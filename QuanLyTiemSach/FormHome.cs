using System;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {

            dataGridView1.Rows.Add("DH001");
            dataGridView1.Rows.Add("DH002");
            dataGridView1.Rows.Add("DH003");

  
            dataGridView2.Rows.Add("Sách A", 50);
            dataGridView2.Rows.Add("Sách B", 35);
            dataGridView2.Rows.Add("Sách C", 20);

            lowStockPanel.Controls.Add(new Label { Text = "Sách D", Location = new System.Drawing.Point(10, 10) });
            lowStockPanel.Controls.Add(new Label { Text = "Sách E", Location = new System.Drawing.Point(10, 40) });

 
            UpdateStatistics();
        }

        private void UpdateStatistics()
        {

            int totalBooks = 0;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    totalBooks += Convert.ToInt32(row.Cells[1].Value);
                }
            }

            lblStats.Text = $"Thống kê: {totalBooks} sách";


            int totalEmployees = 10;
            lblStats.Text += $" | {totalEmployees} nhân viên";
        }
    }
}
