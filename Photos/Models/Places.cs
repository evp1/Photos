using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Photo.Models
{
    public class Places
    {
        public Places()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        public int PlaceId { get; set; }
        [Required]
        [MaxLength (25)]
        [DisplayName("Place name")]
        public string Placename { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }
        public int CountryId { get; set; }
        [DisplayName("Country")]
        public  Countries Countries { get; set; }

    }
}
