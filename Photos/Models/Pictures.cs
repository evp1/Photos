using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Photo.Models
{
    public partial class Pictures
    {
        public Pictures()
        {
            this.Categories = new HashSet<Categories>();
        }

        [Key]
        public int PictureId { get; set; }
        [Required]
        [DisplayName("Description")]
        public string PhotoDescription { get; set; }
        [Required]
        [DisplayName( "File Name" )]
        public string FileName { get; set; }
        [DisplayName("Date Taken")]
        public DateTime DateTaken { get; set; }
        public int PlaceId { get; set; }
        [DisplayName("Place")]
        public Places Places { get; set; }
        public Nullable<int> FolderId { get; set; }

        public virtual Folders Folders { get; set; }
        public virtual Places Place { get; set; }
        public virtual ICollection<Categories> Categories { get; set; }
    }
}
