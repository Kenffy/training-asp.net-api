using System.ComponentModel.DataAnnotations;

namespace api.Models.DTO
{
    public class VillaNumberDTO
    {
        [Required]
        public int villaNo { get; set; }
        [Required]
        public int villaId { get; set; }
        public string specialDetails { get; set; }
    }
}
