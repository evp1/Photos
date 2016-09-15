using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photo.Models
{
    public class Categories
    {
        public Categories()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        public int CatagoryId { get; set; }
        [Required]
        [MaxLength(25)]
        public string Category { get; set; }
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }
        public virtual ICollection<PictureCategories> PictureCategories { get; set; }
    }
}
