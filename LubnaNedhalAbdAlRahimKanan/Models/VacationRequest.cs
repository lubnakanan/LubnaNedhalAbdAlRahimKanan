using System.ComponentModel.DataAnnotations;

namespace LubnaNedhalAbdAlRahimKanan.Models
{
    public class VacationRequest
    {
        [Key]
        public int RequestId { get; set; } // Primary Key

        [Required]
        public DateTime SubmissionDate { get; set; } // Request Submission Date

        [Required, MaxLength(100)]
        public string Description { get; set; } = string.Empty; // Request Description

        [Required, MaxLength(6)]
        public string EmployeeNumber { get; set; } = string.Empty; // Foreign Key

        [Required, MaxLength(1)]
        public string VacationTypeCode { get; set; } = string.Empty; // Foreign Key

        [Required]
        public DateTime StartDate { get; set; } // Vacation Start Date

        [Required]
        public DateTime EndDate { get; set; } // Vacation End Date

        [Required]
        public int TotalVacationDays { get; set; } // Total Days

        [Required]
        public int RequestStateId { get; set; } // Foreign Key for State

        [MaxLength(6)]
        public string? ApprovedBy { get; set; } // Approved By (Nullable)

        [MaxLength(6)]
        public string? DeclinedBy { get; set; } // Declined By (Nullable)
    }
}
