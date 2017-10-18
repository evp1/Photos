using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Photo.Models
{
    public class Places
    {
        public Places()
        {
            this.Pictures = new HashSet<Pictures>();
        }

        [Key]
        public int PlaceId { get; set; }
        [Required]
        [MaxLength (25)]
        [DisplayName("Place name")]
        public string Placename { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int CountryId { get; set; }

        [DisplayName("Country")]
        public virtual Countries Countries { get; set; }
        public virtual ICollection<Pictures> Pictures { get; set; }

    }
}
