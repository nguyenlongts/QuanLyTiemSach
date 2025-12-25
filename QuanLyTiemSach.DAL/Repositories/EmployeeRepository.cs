using Microsoft.EntityFrameworkCore;
using QuanLyTiemSach.DAL;
using QuanLyTiemSach.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
//using WorkShiftManagement.Data;
using WorkShiftManagement.Models;

namespace WorkShiftManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly BookStoreDbContext _context;

        public EmployeeRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }

        public int Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee.EmployeeId;
        }

        public bool Update(Employee employee)
        {
            _context.Employees.Update(employee);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var employee = GetById(id);
            if (employee == null) return false;

            _context.Employees.Remove(employee);
            return _context.SaveChanges() > 0;
        }

        public bool Exists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}