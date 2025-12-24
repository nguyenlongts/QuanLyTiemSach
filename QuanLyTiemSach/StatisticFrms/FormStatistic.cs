using QuanLyTiemSach.BLL.Services;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyTiemSach.APP
{
    public partial class FormStatistic : Form
    {
        private readonly IStatisticService _statisticService;

        public FormStatistic(IStatisticService statisticService)
        {
            _statisticService = statisticService;
            InitializeComponent();
        }

        private async void FrmBookStatistic_Load(object sender, EventArgs e)
        {
            var data = await _statisticService.GetBookSalesAsync();

            chartBookSales.Series.Clear();
            chartBookSales.ChartAreas.Clear();

            ChartArea area = new ChartArea("Main");
            chartBookSales.ChartAreas.Add(area);

            Series series = new Series("Số lượng bán")
            {
                ChartType = SeriesChartType.Column
            };

            foreach (var item in data)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            chartBookSales.Series.Add(series);
        }
    }
}
