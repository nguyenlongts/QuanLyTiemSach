using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemSach.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> CreateOrderAsync(Order order, List<OrderDetail> orderDetails);
        Task<Order> UpdateOrderAsync(Order order);
        Task<bool> DeleteOrderAsync(int id);
        Task<List<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<List<Order>> GetOrdersByCustomerIdAsync(int customerId);
        Task<decimal> CalculateTotalAmountAsync(List<OrderDetail> orderDetails);
        Task<List<Order>> GetLatestOrdersAsync(int count);

        Task<List<(Book book, int totalSold)>> GetTopSellingBooksAsync(int count);
    }
}
