using QuanLyTiemSach.DAL.Repositories;
using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemSach.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                throw new Exception($"Không tìm thấy khách hàng với ID: {id}");

            return customer;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Name))
                throw new Exception("Tên khách hàng không được để trống");

            if (string.IsNullOrWhiteSpace(customer.PhoneNumber))
                throw new Exception("Số điện thoại không được để trống");

            var existingCustomer = await _customerRepository.GetByPhoneNumberAsync(customer.PhoneNumber);
            if (existingCustomer != null)
                throw new Exception($"Số điện thoại {customer.PhoneNumber} đã được sử dụng");

            return await _customerRepository.CreateAsync(customer);
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var existingCustomer = await _customerRepository.GetByIdAsync(customer.Id);
            if (existingCustomer == null)
                throw new Exception($"Không tìm thấy khách hàng với ID: {customer.Id}");

 
            if (string.IsNullOrWhiteSpace(customer.Name))
                throw new Exception("Tên khách hàng không được để trống");

            if (string.IsNullOrWhiteSpace(customer.PhoneNumber))
                throw new Exception("Số điện thoại không được để trống");

            var phoneCheck = await _customerRepository.GetByPhoneNumberAsync(customer.PhoneNumber);
            if (phoneCheck != null && phoneCheck.Id != customer.Id)
                throw new Exception($"Số điện thoại {customer.PhoneNumber} đã được sử dụng");

            return await _customerRepository.UpdateAsync(customer);
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                throw new Exception($"Không tìm thấy khách hàng với ID: {id}");

            return await _customerRepository.DeleteAsync(id);
        }

        public async Task<Customer> GetCustomerByPhoneNumberAsync(string phoneNumber)
        {
            return await _customerRepository.GetByPhoneNumberAsync(phoneNumber);
        }
    }
}
