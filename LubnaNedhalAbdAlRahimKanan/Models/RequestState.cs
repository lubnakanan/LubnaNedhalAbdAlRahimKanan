using System.ComponentModel.DataAnnotations;

namespace LubnaNedhalAbdAlRahimKanan.Models
{
    public class RequestState
    {
        [Key]
        public int StateId { get; set; } // Primary Key

        [Required, MaxLength(10)]
        public string Name { get; set; } = string.Empty; // Request State Name
    }
}
