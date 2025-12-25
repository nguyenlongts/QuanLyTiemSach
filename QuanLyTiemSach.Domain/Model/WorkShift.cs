using QuanLyTiemSach.Domain.Model;
using System;

namespace WorkShiftManagement.Models
{
    public class WorkShift
    {
        public int WorkShiftId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime WorkDate { get; set; }
        public int ShiftType { get; set; } // 1: Sáng, 2: Trưa, 3: Chiều, 4: Tối
        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property
        public Employee Employee { get; set; }

        public string GetShiftName()
        {
            return ShiftType switch
            {
                1 => "Ca Sáng (6h-12h)",
                2 => "Ca Trưa (12h-18h)",
                3 => "Ca Chiều (18h-22h)",
                4 => "Ca Tối (22h-6h)",
                _ => "Không xác định"
            };
        }
    }
}