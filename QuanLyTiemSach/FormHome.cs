using Microsoft.EntityFrameworkCore;
using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.Domain.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemSach
{
    public partial class FormHome : Form
    {
        private readonly IBookService _bookService;
        private readonly IOrderService _orderService;

        public FormHome()
        {
            InitializeComponent();

            _bookService = ServiceDI.GetBookService();
            _orderService = ServiceDI.GetOrderService();

            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            await GetRecentOrdersAsync();
            await GetTopBooksAsync();
            await GetLowStockBooksAsync();

            UpdateStatistics();
        }

        private async Task GetRecentOrdersAsync()
        {

            dgv5LatestOrders.Columns.Add("CustomerName", "Tên Khách");
            dgv5LatestOrders.Columns.Add("TotalAmount", "Tổng Tiền");

            dgv5LatestOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            var latestOrders = await _orderService.GetLatestOrdersAsync(5);
            dgv5LatestOrders.Rows.Clear();
            foreach (var order in latestOrders)
            {
                var customerName = order.Customer?.Name ?? "Khách vãng lai";
                dgv5LatestOrders.Rows.Add(order.Id, customerName, order.TotalAmount.ToString("N0"));
            }
        }

        private async Task GetTopBooksAsync()
        {

            var topBooks = await _orderService.GetTopSellingBooksAsync(5);


            dgv5BestSellBook.Rows.Clear();
            foreach (var tb in topBooks)
            {
                dgv5BestSellBook.Rows.Add(tb.book.Title, tb.totalSold);
            }
        }

        private async Task GetLowStockBooksAsync()
        {
            var allBooks = await _bookService.GetAllBooksAsync();

            var lowStockBooks = allBooks
                .Where(b => b.Quantity <= 5)
                .OrderBy(b => b.Quantity)
                .ToList();

            lowStockPanel.Controls.Clear();
            int y = 10;
            foreach (var book in lowStockBooks)
            {
                var lbl = new Label
                {
                    Text = $"{book.Title} ({book.Quantity})",
                    Location = new System.Drawing.Point(10, y),
                    AutoSize = true
                };
                lowStockPanel.Controls.Add(lbl);
                y += 25;
            }
        }

        private void UpdateStatistics()
        {
            int totalBooks = dgv5BestSellBook.Rows.Cast<DataGridViewRow>()
                .Where(r => r.Cells[1].Value != null)
                .Sum(r => Convert.ToInt32(r.Cells[1].Value));

            int totalEmployees = 10; 
            lblStats.Text = $"Thống kê: {totalBooks} sách | {totalEmployees} nhân viên";
        }
    }
}
