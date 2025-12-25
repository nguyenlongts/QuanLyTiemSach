using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuanLyTiemSach.DAL;
//using WorkShiftManagement.Data;
using WorkShiftManagement.Models;

namespace WorkShiftManagement.Repositories
{
    public class EmployeeRepository
    {
        private readonly BookStoreDbContext _context;

        public EmployeeRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAll()
        {
            return _context.Employees
                .Where(e => e.IsActive)
                .OrderBy(e => e.FullName)
                .ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees
                .FirstOrDefault(e => e.EmployeeId == id);
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                employee.IsActive = false;
                _context.SaveChanges();
            }
        }
    }
}