using QuanLyTiemSach.Data.Repositories;
using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using WorkShiftManagement.Models;
using WorkShiftManagement.Repositories;

namespace QuanLyTiemSach.Business.Services
{
    public class SalaryService : ISalaryService
    {
        private const decimal SALARY_PER_SHIFT = 100000m; // 100k per shift
        private readonly ISalaryRepository _salaryRepository;
        //private readonly EmployeeRepository _employeeRepo;
        public SalaryService(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }


        //public List<Employee> GetAllEmployees()
        //{
        //    return _employeeRepo.GetAll();
        //}
        public decimal CalculateSalary(int shifts)
        {
            if (shifts < 0)
            {
                throw new ArgumentException("Số ca làm không thể âm", nameof(shifts));
            }

            return shifts * SALARY_PER_SHIFT;
        }

        public List<Salary> GetAllSalaries()
        {
            try
            {
                return _salaryRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách lương: {ex.Message}", ex);
            }
        }

        public Salary GetSalaryById(int id)
        {
            try
            {
                return _salaryRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin lương: {ex.Message}", ex);
            }
        }

        public Salary GetSalaryByEmployeeAndMonth(int employeeId, int month)
        {
            try
            {
                ValidateEmployeeId(employeeId);
                ValidateMonth(month);

                return _salaryRepository.GetByEmployeeAndMonth(employeeId, month);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin lương: {ex.Message}", ex);
            }
        }

        public List<Salary> GetSalariesByEmployee(int employeeId)
        {
            try
            {
                ValidateEmployeeId(employeeId);
                return _salaryRepository.GetByEmployeeId(employeeId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách lương: {ex.Message}", ex);
            }
        }

        public List<Salary> GetSalariesByMonth(int month)
        {
            try
            {
                ValidateMonth(month);
                return _salaryRepository.GetByMonth(month);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách lương: {ex.Message}", ex);
            }
        }

        public bool CreateOrUpdateSalary(int employeeId, int month, int shifts, out string message)
        {
            try
            {
                // Validation
                ValidateEmployeeId(employeeId);
                ValidateMonth(month);

                if (shifts < 0)
                {
                    message = "Số ca làm không thể âm!";
                    return false;
                }

                // Calculate salary
                decimal amount = CalculateSalary(shifts);

                // Check if exists
                var existingSalary = _salaryRepository.GetByEmployeeAndMonth(employeeId, month);

                if (existingSalary != null)
                {
                    // Update
                    existingSalary.Amount = amount;
                    _salaryRepository.Update(existingSalary);
                    _salaryRepository.SaveChanges();
                    message = "Cập nhật lương thành công!";
                }
                else
                {
                    // Create new
                    var newSalary = new Salary
                    {
                        EmployeeId = employeeId,
                        Month = month,
                        Amount = amount
                    };

                    _salaryRepository.Add(newSalary);
                    _salaryRepository.SaveChanges();
                    message = "Tạo lương thành công!";
                }

                return true;
            }
            catch (Exception ex)
            {
                message = $"Lỗi: {ex.Message}";
                return false;
            }
        }

        public bool DeleteSalary(int id, out string message)
        {
            try
            {
                var salary = _salaryRepository.GetById(id);

                if (salary == null)
                {
                    message = "Không tìm thấy bản ghi lương!";
                    return false;
                }

                _salaryRepository.Delete(id);
                _salaryRepository.SaveChanges();
                message = "Xóa lương thành công!";
                return true;
            }
            catch (Exception ex)
            {
                message = $"Lỗi khi xóa: {ex.Message}";
                return false;
            }
        }

        public bool IsSalaryExists(int employeeId, int month)
        {
            try
            {
                ValidateEmployeeId(employeeId);
                ValidateMonth(month);
                return _salaryRepository.Exists(employeeId, month);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra: {ex.Message}", ex);
            }
        }

        #region Private Methods

        private void ValidateEmployeeId(int employeeId)
        {
            if (employeeId <= 0)
            {
                throw new ArgumentException("Mã nhân viên không hợp lệ", nameof(employeeId));
            }
        }

        private void ValidateMonth(int month)
        {
            if (month < 1 || month > 12)
            {
                throw new ArgumentException("Tháng phải từ 1 đến 12", nameof(month));
            }
        }

        #endregion
    }
}