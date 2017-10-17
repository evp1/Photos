using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Photo.Models
{
    public class Categories
    {
        public Categories()
        {
            this.Pictures = new HashSet<Pictures>();
        }

        [Key]
        public int CatagoryId { get; set; }
        [Required]
        [MaxLength(25)]
        public string Category { get; set; }
        public virtual ICollection<Pictures> Pictures { get; set; }
    }
}
