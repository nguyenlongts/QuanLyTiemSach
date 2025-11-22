using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace QuanLyTiemSach.StatisticFrms
{
    public partial class FormStatistic : Form
    {
        public FormStatistic()
        {
            InitializeComponent();
            cbTimeRangeDt.Items.AddRange(new string[] { "2022","2024", "2025", "2026" });
        }
        public void LoadChartDoanhThu(int year)
        {

            chartDoanhThu.Series.Clear();

            Series series = new Series
            {
                Name = "DoanhThu",
                Color = Color.Blue,
                IsVisibleInLegend = true,
                ChartType = SeriesChartType.Column
            };

            Random rand = new Random();
            for (int month = 1; month <= 12; month++)
            {

                double revenue = rand.Next(50, 200);
                series.Points.AddXY(month, revenue);
            }

            chartDoanhThu.Series.Add(series);

            chartDoanhThu.Titles.Clear();
            chartDoanhThu.Titles.Add($"Doanh Thu Năm {year}");
        }

        private void btnXemDoanhThu_Click(object sender, EventArgs e)
        {
            int selectedYear=int.Parse(cbTimeRangeDt.SelectedItem.ToString());
            LoadChartDoanhThu(selectedYear);

        }
    }
}
