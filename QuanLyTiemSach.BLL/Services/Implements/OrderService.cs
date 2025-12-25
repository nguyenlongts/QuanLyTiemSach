using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.DAL.Repositories;
using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemSach.BLL.Services.Implements
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBookRepository _bookRepository;

        public OrderService(IOrderRepository orderRepository, IBookRepository bookRepository)
        {
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
                throw new Exception($"Không tìm thấy hóa đơn với ID: {id}");

            return order;
        }

        public async Task<Order> CreateOrderAsync(Order order, List<OrderDetail> orderDetails)
        {
            if (orderDetails == null || !orderDetails.Any())
                throw new Exception("Hóa đơn phải có ít nhất một sản phẩm");

            order.TotalAmount = await CalculateTotalAmountAsync(orderDetails);

            foreach (var detail in orderDetails)
            {
                var book = await _bookRepository.GetByIdAsync(detail.BookID);
                if (book == null)
                    throw new Exception($"Không tìm thấy sách với ID: {detail.BookID}");

                if (book.Quantity < detail.Quantity)
                    throw new Exception($"Sách '{book.Title}' không đủ số lượng trong kho. Còn lại: {book.Quantity}");
            }

            order.OrderDetails = orderDetails;

            var createdOrder = await _orderRepository.CreateOrderAsync(order);

            foreach (var detail in orderDetails)
            {
                var book = await _bookRepository.GetByIdAsync(detail.BookID);
                book.Quantity -= detail.Quantity;
                await _bookRepository.UpdateAsync(book);
            }

            return createdOrder;
        }

        public async Task<Order> UpdateOrderAsync(Order order)
        {
            var existingOrder = await _orderRepository.GetOrderByIdAsync(order.Id);
            if (existingOrder == null)
                throw new Exception($"Không tìm thấy hóa đơn với ID: {order.Id}");


            return await _orderRepository.UpdateOrderAsync(order);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
                throw new Exception($"Không tìm thấy hóa đơn với ID: {id}");

            foreach (var detail in order.OrderDetails)
            {
                var book = await _bookRepository.GetByIdAsync(detail.BookID);
                if (book != null)
                {
                    book.Quantity += detail.Quantity;
                    await _bookRepository.UpdateAsync(book);
                }
            }

            return await _orderRepository.DeleteOrderAsync(id);
        }

        public async Task<List<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new Exception("Ngày bắt đầu không thể lớn hơn ngày kết thúc");

            return await _orderRepository.GetOrdersByDateRangeAsync(startDate, endDate);
        }

        public async Task<List<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _orderRepository.GetOrdersByCustomerIdAsync(customerId);
        }

        public async Task<decimal> CalculateTotalAmountAsync(List<OrderDetail> orderDetails)
        {
            decimal total = 0;

            foreach (var detail in orderDetails)
            {
                var book = await _bookRepository.GetByIdAsync(detail.BookID);
                if (book != null)
                {
                    detail.UnitPrice = book.Price;
                    total += book.Price * detail.Quantity;
                }
            }

            return total;
        }
        public async Task<List<Order>> GetLatestOrdersAsync(int count = 5)
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return orders
                .Take(count)
                .ToList();
        }

        public async Task<List<(Book book, int totalSold)>> GetTopSellingBooksAsync(int count = 5)
        {
            var allOrders = await _orderRepository.GetAllOrdersAsync();
            var allDetails = allOrders.SelectMany(o => o.OrderDetails);

            var topBooks = allDetails
                .GroupBy(od => od.Book)
                .Select(g => (book: g.Key, totalSold: g.Sum(od => od.Quantity)))
                .OrderByDescending(x => x.totalSold)
                .Take(count)
                .ToList();

            return topBooks;
        }
    }
}
