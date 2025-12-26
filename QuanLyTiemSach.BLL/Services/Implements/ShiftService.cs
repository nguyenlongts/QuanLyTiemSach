using QuanLyTiemSach.DAL.Repositories;
using WorkShiftManagement.Models;
namespace QuanLyTiemSach.BLL.Services.Implements;

public class WorkShiftService : IShiftService
{
    private readonly IShiftRepository _shiftRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public WorkShiftService(
        IShiftRepository shiftRepository,
        IEmployeeRepository employeeRepository)
    {
        _shiftRepository = shiftRepository;
        _employeeRepository = employeeRepository;
    }

    public async Task<List<Employee>> GetAllEmployeesAsync()
    {
        return await _employeeRepository.GetAllAsync();
    }

    public async Task<(bool success, string message)> AssignShiftAsync(
        int employeeId,
        DateTime workDate,
        int shiftType,
        string note)
    {
        var employee = await _employeeRepository.GetByIdAsync(employeeId);
        if (employee == null)
            return (false, "Nhân viên không tồn tại!");

        if (shiftType < 1 || shiftType > 4)
            return (false, "Ca làm việc không hợp lệ!");

        if (await _shiftRepository.CheckDuplicateAsync(employeeId, workDate, shiftType))
            return (false, "Nhân viên đã được phân ca này rồi!");

        var shift = new WorkShift
        {
            EmployeeId = employeeId,
            WorkDate = workDate.Date,
            ShiftType = shiftType,
            Note = note,
            CreatedAt = DateTime.Now
        };

        int id = await _shiftRepository.AddAsync(shift);
        return id > 0
            ? (true, "Phân ca thành công!")
            : (false, "Thêm ca làm thất bại!");
    }

    public async Task<List<WorkShift>> GetWeeklyShiftsAsync(DateTime monday)
    {
        DateTime start = monday.Date;
        DateTime end = start.AddDays(6);
        return await _shiftRepository.GetByDateRangeAsync(start, end);
    }

    public async Task<bool> DeleteWorkShiftAsync(int workShiftId)
    {
        return await _shiftRepository.DeleteAsync(workShiftId);
    }
}
