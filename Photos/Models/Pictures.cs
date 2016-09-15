using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Photo.Models
{
    public class Pictures
    {
        [Key]
        public int PictureId { get; set; }
        [Required]
        [DisplayName("Description")]
        public string PhotoDescription { get; set; }
        [DisplayName("Date Taken")]
        public DateTime DateTaken { get; set; }
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }
        public int PlaceId { get; set; }
        [DisplayName("Place")]
        public Places Places { get; set; }
        public virtual ICollection<PictureCategories> PictureCategories { get; set; }
    }
}
