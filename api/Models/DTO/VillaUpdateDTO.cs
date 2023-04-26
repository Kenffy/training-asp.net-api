using System.ComponentModel.DataAnnotations;

namespace api.Models.DTO
{
    public class VillaUpdateDTO
    {
        [Required]
        public int id { get; set; }
        [Required]
        [MaxLength(30)]
        public string name { get; set; }
        public string details { get; set; }
        [Required]
        public double rate { get; set; }
        [Required]
        public int sqft { get; set; }
        [Required]
        public int occupancy { get; set; }
        public string imageUrl { get; set; }
        public string amenity { get; set; }
    }
}
