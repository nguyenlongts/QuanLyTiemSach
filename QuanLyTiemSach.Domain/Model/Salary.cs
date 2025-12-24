using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTiemSach.Domain.Model
{
    [Table("Salary")]
    public class Salary
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public int Month { get; set; }

        // Optionally: relationship với Employee
        // public Employee Employee { get; set; }
    }
}
