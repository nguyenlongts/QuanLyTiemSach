using ClosedXML.Excel;
using QuanLyTiemSach.BLL.Services;
using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyTiemSach.StatisticFrms
{
    public partial class FormStatistic : Form
    {
        private readonly IOrderService _orderService;
        private List<Order> _currentOrders;
        private bool _isMonthView = false;

        public FormStatistic(IOrderService orderService)
        {
            InitializeComponent();
            _orderService = orderService;
        }

        private void FormStatistic_Load(object sender, EventArgs e)
        {
            InitializeForm();
        }
        private void InitializeForm()
        {
            cbYear.Items.Clear();
            for (int year = 2020; year <= DateTime.Now.Year + 1; year++)
            {
                cbYear.Items.Add(year.ToString());
            }
            cbYear.SelectedItem = DateTime.Now.Year.ToString();

            cbMonth.Items.Clear();
            for (int month = 1; month <= 12; month++)
            {
                cbMonth.Items.Add($"Tháng {month}");
            }
            cbMonth.SelectedIndex = DateTime.Now.Month - 1;

            cbChartType.Items.AddRange(new string[]
            {
                "Cột",
                "Đường",
                "Vùng",
                "Thanh ngang"
            });
            cbChartType.SelectedIndex = 0;
            LoadStatisticsByYear(DateTime.Now.Year);
        }

        private void rbYear_CheckedChanged(object sender, EventArgs e)
        {
            if (rbYear.Checked)
            {
                _isMonthView = false;
                cbYear.Enabled = true;
                cbMonth.Enabled = false;
                lblBestMonth.Text = "Tháng Cao Nhất";
            }
        }

        private void rbMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMonth.Checked)
            {
                _isMonthView = true;
                cbYear.Enabled = true;
                cbMonth.Enabled = true;
                lblBestMonth.Text = "Ngày Cao Nhất";
            }
        }

        private async void LoadStatisticsByYear(int year)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                DateTime startDate = new DateTime(year, 1, 1);
                DateTime endDate = new DateTime(year, 12, 31, 23, 59, 59);

                _currentOrders = await _orderService.GetOrdersByDateRangeAsync(startDate, endDate);

                UpdateTopStatistics(_currentOrders, $"Năm {year}");
                LoadChartByYear(year, _currentOrders);

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadStatisticsByMonth(int year, int month)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                DateTime startDate = new DateTime(year, month, 1);
                DateTime endDate = startDate.AddMonths(1).AddSeconds(-1);

                _currentOrders = await _orderService.GetOrdersByDateRangeAsync(startDate, endDate);

                UpdateTopStatistics(_currentOrders, $"Tháng {month}/{year}");
                LoadChartByMonth(year, month, _currentOrders);

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTopStatistics(List<Order> orders, string period)
        {
            if (orders == null || !orders.Any())
            {
                lblTotalRevenueValue.Text = "0 VNĐ";
                lblTotalOrdersValue.Text = "0";
                lblAvgOrderValue.Text = "0 VNĐ";
                lblBestMonthValue.Text = _isMonthView ? "Ngày --" : "Tháng --";
                return;
            }

            decimal totalRevenue = orders.Sum(o => o.TotalAmount);
            lblTotalRevenueValue.Text = FormatCurrency(totalRevenue);

            lblTotalOrdersValue.Text = orders.Count.ToString("N0");

            decimal avgOrder = orders.Count > 0 ? totalRevenue / orders.Count : 0;
            lblAvgOrderValue.Text = FormatCurrency(avgOrder);

            if (_isMonthView)
            {
                var bestDay = orders
                    .GroupBy(o => o.OrderDate.Day)
                    .Select(g => new { Day = g.Key, Revenue = g.Sum(o => o.TotalAmount) })
                    .OrderByDescending(x => x.Revenue)
                    .FirstOrDefault();

                if (bestDay != null)
                {
                    lblBestMonthValue.Text = $"Ngày {bestDay.Day}";
                }
            }
            else
            {
                var bestMonth = orders
                    .GroupBy(o => o.OrderDate.Month)
                    .Select(g => new { Month = g.Key, Revenue = g.Sum(o => o.TotalAmount) })
                    .OrderByDescending(x => x.Revenue)
                    .FirstOrDefault();

                if (bestMonth != null)
                {
                    lblBestMonthValue.Text = $"Tháng {bestMonth.Month}";
                }
            }
        }

        private void LoadChartByYear(int year, List<Order> orders)
        {
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();

            Series series = CreateSeries();

            var monthlyRevenue = orders
                .GroupBy(o => o.OrderDate.Month)
                .Select(g => new { Month = g.Key, Revenue = g.Sum(o => o.TotalAmount) })
                .OrderBy(x => x.Month)
                .ToDictionary(x => x.Month, x => x.Revenue);

            for (int month = 1; month <= 12; month++)
            {
                decimal revenue = monthlyRevenue.ContainsKey(month)
                    ? monthlyRevenue[month] / 1000000
                    : 0;

                var point = new DataPoint(month, (double)revenue);
                point.AxisLabel = $"T{month}";
                point.Label = revenue > 0 ? revenue.ToString("N1") : "";
                point.Font = new Font("Segoe UI", 8F);

                series.Points.Add(point);
            }

            chartDoanhThu.Series.Add(series);

            Title title = new Title
            {
                Text = $"📊 BIỂU ĐỒ DOANH THU NĂM {year}",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            chartDoanhThu.Titles.Add(title);
        }

        private void LoadChartByMonth(int year, int month, List<Order> orders)
        {
            chartDoanhThu.Series.Clear();
            chartDoanhThu.Titles.Clear();

            Series series = CreateSeries();

            int daysInMonth = DateTime.DaysInMonth(year, month);

            var dailyRevenue = orders
                .GroupBy(o => o.OrderDate.Day)
                .Select(g => new { Day = g.Key, Revenue = g.Sum(o => o.TotalAmount) })
                .OrderBy(x => x.Day)
                .ToDictionary(x => x.Day, x => x.Revenue);

            for (int day = 1; day <= daysInMonth; day++)
            {
                decimal revenue = dailyRevenue.ContainsKey(day)
                    ? dailyRevenue[day] / 1000000
                    : 0;

                var point = new DataPoint(day, (double)revenue);
                point.AxisLabel = day.ToString();
                point.Label = revenue > 0 ? revenue.ToString("N1") : "";
                point.Font = new Font("Segoe UI", 7F);

                series.Points.Add(point);
            }

            chartDoanhThu.Series.Add(series);

            Title title = new Title
            {
                Text = $"📊 BIỂU ĐỒ DOANH THU THÁNG {month}/{year}",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94)
            };
            chartDoanhThu.Titles.Add(title);

            chartDoanhThu.ChartAreas[0].AxisX.Title = "Ngày";
            chartDoanhThu.ChartAreas[0].AxisX.Interval = daysInMonth > 15 ? 2 : 1;
        }

        private Series CreateSeries()
        {
            Series series = new Series
            {
                Name = "Doanh Thu",
                IsVisibleInLegend = true,
                LegendText = "Doanh Thu (Triệu VNĐ)"
            };

            switch (cbChartType.SelectedIndex)
            {
                case 0:
                    series.ChartType = SeriesChartType.Column;
                    series.Color = Color.FromArgb(41, 128, 185);
                    break;
                case 1:
                    series.ChartType = SeriesChartType.Line;
                    series.Color = Color.FromArgb(46, 204, 113);
                    series.BorderWidth = 3;
                    series.MarkerStyle = MarkerStyle.Circle;
                    series.MarkerSize = 8;
                    break;
                case 2:
                    series.ChartType = SeriesChartType.Area;
                    series.Color = Color.FromArgb(150, 155, 89, 182);
                    break;
                case 3:
                    series.ChartType = SeriesChartType.Bar;
                    series.Color = Color.FromArgb(230, 126, 34);
                    break;
            }

            return series;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (cbYear.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn năm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedYear = int.Parse(cbYear.SelectedItem.ToString());

            if (_isMonthView)
            {
                if (cbMonth.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn tháng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedMonth = cbMonth.SelectedIndex + 1;
                LoadStatisticsByMonth(selectedYear, selectedMonth);
            }
            else
            {
                LoadStatisticsByYear(selectedYear);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentOrders == null || !_currentOrders.Any())
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Lưu báo cáo thống kê",
                    FileName = $"BaoCaoDoanhThu_{DateTime.Now:yyyyMMdd}.xlsx"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(saveDialog.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToExcel(string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Báo Cáo Doanh Thu");
                worksheet.Cell("A1").Value = "BÁO CÁO DOANH THU";
                worksheet.Range("A1:E1").Merge().Style
                    .Font.SetBold().Font.SetFontSize(16)
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                string period = _isMonthView
                    ? $"Tháng {cbMonth.SelectedIndex + 1}/{cbYear.SelectedItem}"
                    : $"Năm {cbYear.SelectedItem}";

                worksheet.Cell("A2").Value = $"Kỳ báo cáo: {period}";
                worksheet.Cell("A3").Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";

                worksheet.Cell("A5").Value = "THỐNG KÊ TỔNG QUAN";
                worksheet.Cell("A6").Value = "Tổng doanh thu:";
                worksheet.Cell("B6").Value = lblTotalRevenueValue.Text;
                worksheet.Cell("A7").Value = "Tổng đơn hàng:";
                worksheet.Cell("B7").Value = lblTotalOrdersValue.Text;
                worksheet.Cell("A8").Value = "Giá trị trung bình:";
                worksheet.Cell("B8").Value = lblAvgOrderValue.Text;

                worksheet.Cell("A10").Value = _isMonthView ? "CHI TIẾT THEO NGÀY" : "CHI TIẾT THEO THÁNG";
                worksheet.Cell("A11").Value = _isMonthView ? "Ngày" : "Tháng";
                worksheet.Cell("B11").Value = "Số đơn hàng";
                worksheet.Cell("C11").Value = "Doanh thu";
                worksheet.Cell("D11").Value = "Trung bình/đơn";

                IEnumerable<dynamic> timeData;

                if (_isMonthView)
                {
                    timeData = _currentOrders
                        .GroupBy(o => o.OrderDate.Day)
                        .Select(g => new
                        {
                            Period = g.Key,
                            Orders = g.Count(),
                            Revenue = g.Sum(o => o.TotalAmount),
                            Avg = g.Average(o => o.TotalAmount)
                        })
                        .OrderBy(x => x.Period);
                }
                else
                {
                    timeData = _currentOrders
                        .GroupBy(o => o.OrderDate.Month)
                        .Select(g => new
                        {
                            Period = g.Key,
                            Orders = g.Count(),
                            Revenue = g.Sum(o => o.TotalAmount),
                            Avg = g.Average(o => o.TotalAmount)
                        })
                        .OrderBy(x => x.Period);
                }

                int row = 12;
                foreach (var data in timeData)
                {
                    string periodLabel = _isMonthView ? $"Ngày {data.Period}" : $"Tháng {data.Period}";
                    worksheet.Cell($"A{row}").Value = periodLabel;
                    worksheet.Cell($"B{row}").Value = data.Orders;
                    worksheet.Cell($"C{row}").Value = data.Revenue;
                    worksheet.Cell($"D{row}").Value = data.Avg;
                    row++;
                }

                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(filePath);
            }
        }

        private string FormatCurrency(decimal amount)
        {
            if (amount >= 1000000000)
            {
                return $"{(amount / 1000000000):N1} tỷ";
            }
            else if (amount >= 1000000)
            {
                return $"{(amount / 1000000):N1} triệu";
            }
            else
            {
                return $"{amount:N0} VNĐ";
            }
        }
    }
}