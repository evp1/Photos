using System.ComponentModel.DataAnnotations;

namespace Photo.Models
{
    public class Countries
    {
        [Key]
        public int CountryId { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
