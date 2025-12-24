using System;

namespace WorkShiftManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        //public string Position { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}