using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Photo.Models
{
    public class Countries
    {
        public Countries()
        {
            this.Places = new HashSet<Places>();
        }

        [Key]
        public int CountryId { get; set; }
        [Required]
        public string Country { get; set; }

        public virtual ICollection<Places> Places { get; set; }

    }
}
