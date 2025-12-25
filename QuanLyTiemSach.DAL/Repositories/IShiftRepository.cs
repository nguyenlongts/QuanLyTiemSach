using QuanLyTiemSach.Domain.Model;
using WorkShiftManagement.Models;

public interface IShiftRepository
{
    void Add(WorkShift shift);
    List<WorkShift> GetByWeek(DateTime monday);
}
