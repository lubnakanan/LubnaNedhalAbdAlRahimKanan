using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LubnaNedhalAbdAlRahimKanan.Models
{
    public class Employee
    {
        [Key, MaxLength(6)]
        public string EmployeeNumber { get; set; } = string.Empty; // Primary Key

        [Required, MaxLength(20)]
        public string Name { get; set; } = string.Empty; // Employee Name

        public int DepartmentId { get; set; } // Foreign Key
        public int PositionId { get; set; } // Foreign Key

        [Required, MaxLength(1)]
        public string Gender { get; set; } = "M"; // M: Male, F: Female

        [MaxLength(6)]
        public string? ReportsTo { get; set; } // Reports to another employee

        [Range(0, 24)]
        public int VacationDaysLeft { get; set; } = 24; // Vacation Balance

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; } // Salary with decimal precision
    }
}
