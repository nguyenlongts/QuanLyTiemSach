using Microsoft.EntityFrameworkCore;
using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemSach.DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BookStoreDbContext _context;

        public CustomerRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context.Set<Customer>().ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Set<Customer>().FindAsync(id);
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            _context.Set<Customer>().Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            _context.Set<Customer>().Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await GetByIdAsync(id);
            if (customer == null)
                return false;

            _context.Set<Customer>().Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Customer> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.Set<Customer>()
                .FirstOrDefaultAsync(c => c.PhoneNumber == phoneNumber);
        }
    }
}
