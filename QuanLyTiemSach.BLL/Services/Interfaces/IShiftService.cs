using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkShiftManagement.Models;

public interface IShiftService
{
    Task<(bool success, string message)> AssignShiftAsync(
        int employeeId,
        DateTime workDate,
        int shiftType,
        string note
    );

    Task<List<WorkShift>> GetWeeklyShiftsAsync(DateTime monday);

    Task<bool> DeleteWorkShiftAsync(int workShiftId);

    Task<List<Employee>> GetAllEmployeesAsync();
}
