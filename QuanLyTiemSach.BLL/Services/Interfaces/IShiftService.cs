using QuanLyTiemSach.Domain.Model;
using WorkShiftManagement.Models;

public interface IShiftService
{
    void AssignShift(
        int employeeId,
        DateTime workDate,
        TimeSpan start,
        TimeSpan end,
        decimal hourlyRate
    );

    List<WorkShift> GetWeeklyShifts(DateTime monday);
}
