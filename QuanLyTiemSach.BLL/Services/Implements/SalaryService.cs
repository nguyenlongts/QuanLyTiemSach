using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.DAL.Repositories;
using QuanLyTiemSach.Data.Repositories;
using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShiftManagement.Models;

namespace QuanLyTiemSach.BLL.Services.Implements
{
    public class SalaryService : ISalaryService
    {
        private const decimal SALARY_PER_SHIFT = 100000m;

        private readonly ISalaryRepository _salaryRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IShiftRepository _shiftRepository;

        public SalaryService(
            ISalaryRepository salaryRepository,
            IEmployeeRepository employeeRepository,
            IShiftRepository shiftRepository)
        {
            _salaryRepository = salaryRepository;
            _employeeRepository = employeeRepository;
            _shiftRepository = shiftRepository;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<int> GetShiftCountByMonthAsync(int employeeId, int month, int year)
        {
            ValidateEmployeeId(employeeId);
            ValidateMonth(month);

            DateTime start = new DateTime(year, month, 1);
            DateTime end = start.AddMonths(1).AddDays(-1);

            var shifts = await _shiftRepository.GetByDateRangeAsync(start, end);

            return shifts.Count(s => s.EmployeeId == employeeId);
        }


        public decimal CalculateSalary(int shifts)
        {
            if (shifts < 0)
                throw new ArgumentException("Số ca làm không hợp lệ");

            return shifts * SALARY_PER_SHIFT;
        }

        public async Task<List<Salary>> GetAllSalariesAsync()
        {
            return await _salaryRepository.GetAllAsync();
        }

        public async Task<Salary?> GetSalaryByIdAsync(int id)
        {
            return await _salaryRepository.GetByIdAsync(id);
        }

        public async Task<Salary?> GetSalaryByEmployeeAndMonthAsync(int employeeId, int month)
        {
            ValidateEmployeeId(employeeId);
            ValidateMonth(month);

            return await _salaryRepository.GetByEmployeeAndMonthAsync(employeeId, month);
        }

        public async Task<List<Salary>> GetSalariesByEmployeeAsync(int employeeId)
        {
            ValidateEmployeeId(employeeId);
            return await _salaryRepository.GetByEmployeeIdAsync(employeeId);
        }

        public async Task<List<Salary>> GetSalariesByMonthAsync(int month)
        {
            ValidateMonth(month);
            return await _salaryRepository.GetByMonthAsync(month);
        }

        public async Task<(bool success, string message)> CreateOrUpdateSalaryAsync(
            int employeeId, int month, int year)
        {
            try
            {
                ValidateEmployeeId(employeeId);
                ValidateMonth(month);

                if (!await _employeeRepository.ExistsAsync(employeeId))
                    return (false, "Nhân viên không tồn tại!");

                int shifts = await GetShiftCountByMonthAsync(employeeId, month, year);

                if (shifts == 0)
                    return (false, $"Nhân viên chưa có ca làm trong {month}/{year}");

                decimal amount = CalculateSalary(shifts);

                var salary = await _salaryRepository
                    .GetByEmployeeAndMonthAsync(employeeId, month);

                if (salary != null)
                {
                    salary.Amount = amount;
                    salary.Year = year;
                    await _salaryRepository.UpdateAsync(salary);
                }
                else
                {
                    await _salaryRepository.AddAsync(new Salary
                    {
                        EmployeeId = employeeId,
                        Month = month,
                        Year = year,
                        Amount = amount,
                        CreatedDate = DateTime.Now
                    });
                }

                await _salaryRepository.SaveChangesAsync();
                return (true, $"Tính lương thành công ({shifts} ca)");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool success, string message)> DeleteSalaryAsync(int id)
        {
            var salary = await _salaryRepository.GetByIdAsync(id);
            if (salary == null)
                return (false, "Không tìm thấy bản ghi lương!");

            await _salaryRepository.DeleteAsync(salary);
            await _salaryRepository.SaveChangesAsync();

            return (true, "Xóa lương thành công!");
        }

        public async Task<bool> IsSalaryExistsAsync(int employeeId, int month)
        {
            ValidateEmployeeId(employeeId);
            ValidateMonth(month);
            return await _salaryRepository.ExistsAsync(employeeId, month);
        }

        private void ValidateEmployeeId(int employeeId)
        {
            if (employeeId <= 0)
                throw new ArgumentException("Mã nhân viên không hợp lệ");
        }

        private void ValidateMonth(int month)
        {
            if (month < 1 || month > 12)
                throw new ArgumentException("Tháng phải từ 1 đến 12");
        }
    }
}
