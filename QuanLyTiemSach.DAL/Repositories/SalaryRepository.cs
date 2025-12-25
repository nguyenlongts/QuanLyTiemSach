using Microsoft.EntityFrameworkCore;
using QuanLyTiemSach.DAL;
using QuanLyTiemSach.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyTiemSach.Data.Repositories
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly BookStoreDbContext _context;

        public SalaryRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public List<Salary> GetAll()
        {
            return _context.Salaries
                .OrderByDescending(s => s.Id)
                .ToList();
        }

        public Salary GetById(int id)
        {
            return _context.Salaries.Find(id);
        }

        public Salary GetByEmployeeAndMonth(int employeeId, int month)
        {
            return _context.Salaries
                .FirstOrDefault(s => s.EmployeeId == employeeId && s.Month == month);
        }

        public List<Salary> GetByEmployeeId(int employeeId)
        {
            return _context.Salaries
                .Where(s => s.EmployeeId == employeeId)
                .OrderByDescending(s => s.Month)
                .ToList();
        }

        public List<Salary> GetByMonth(int month)
        {
            return _context.Salaries
                .Where(s => s.Month == month)
                .OrderBy(s => s.EmployeeId)
                .ToList();
        }

        public void Add(Salary salary)
        {
            _context.Salaries.Add(salary);
        }

        public void Update(Salary salary)
        {
            _context.Salaries.Update(salary);
        }

        public void Delete(int id)
        {
            var salary = GetById(id);
            if (salary != null)
            {
                _context.Salaries.Remove(salary);
            }
        }

        public bool Exists(int employeeId, int month)
        {
            return _context.Salaries
                .Any(s => s.EmployeeId == employeeId && s.Month == month);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}