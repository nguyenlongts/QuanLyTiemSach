using System.Collections.Generic;
using QuanLyTiemSach.Domain.Model;

namespace QuanLyTiemSach.Data.Repositories
{
    public interface ISalaryRepository
    {
        /// <summary>
        /// Lấy tất cả bản ghi lương
        /// </summary>
        List<Salary> GetAll();

        /// <summary>
        /// Lấy lương theo ID
        /// </summary>
        Salary GetById(int id);

        /// <summary>
        /// Lấy lương theo nhân viên và tháng
        /// </summary>
        Salary GetByEmployeeAndMonth(int employeeId, int month);

        /// <summary>
        /// Lấy tất cả lương của một nhân viên
        /// </summary>
        List<Salary> GetByEmployeeId(int employeeId);

        /// <summary>
        /// Lấy tất cả lương trong một tháng
        /// </summary>
        List<Salary> GetByMonth(int month);

        /// <summary>
        /// Thêm bản ghi lương mới
        /// </summary>
        void Add(Salary salary);

        /// <summary>
        /// Cập nhật bản ghi lương
        /// </summary>
        void Update(Salary salary);

        /// <summary>
        /// Xóa bản ghi lương
        /// </summary>
        void Delete(int id);

        /// <summary>
        /// Kiểm tra xem lương đã tồn tại chưa
        /// </summary>
        bool Exists(int employeeId, int month);

        /// <summary>
        /// Lưu thay đổi vào database
        /// </summary>
        void SaveChanges();
    }
}