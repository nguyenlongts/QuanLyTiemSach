using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemSach.BLL.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
        Task<Customer> GetCustomerByPhoneNumberAsync(string phoneNumber);
    }
}
