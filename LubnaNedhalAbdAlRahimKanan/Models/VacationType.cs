using System.ComponentModel.DataAnnotations;

namespace LubnaNedhalAbdAlRahimKanan.Models
{
    public class VacationType
    {
        [Key, MaxLength(1)]
        public string VacationTypeCode { get; set; } = string.Empty; // Primary Key

        [Required, MaxLength(20)]
        public string Name { get; set; } = string.Empty; // Vacation Type Name
    }
}
