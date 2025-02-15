using System.ComponentModel.DataAnnotations;

namespace LubnaNedhalAbdAlRahimKanan.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; } // Primary Key

        [Required, MaxLength(30)]
        public string Name { get; set; } = string.Empty; // Position Name
    }
}
