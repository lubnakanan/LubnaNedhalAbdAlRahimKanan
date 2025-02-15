using System.ComponentModel.DataAnnotations;

namespace LubnaNedhalAbdAlRahimKanan.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; } // Primary Key

        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty; // Department Name
    }
}
