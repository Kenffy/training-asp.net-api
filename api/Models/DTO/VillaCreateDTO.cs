using System.ComponentModel.DataAnnotations;

namespace api.Models.DTO
{
    public class VillaCreateDTO
    {
        [Required]
        [MaxLength(30)]
        public string name { get; set; }
        public string details { get; set; }
        public double rate { get; set; }
        public int sqft { get; set; }
        public int occupancy { get; set; }
        public string imageUrl { get; set; }
        public string amenity { get; set; }
    }
}
