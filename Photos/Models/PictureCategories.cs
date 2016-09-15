using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Photo.Models
{
    public class PictureCategories
    {
        [Key]
        public int Id { get; set; }
        public int PictureId { get; set; }
        public int CatagoryId { get; set; }

        public virtual Pictures Pictures { get; set; }
        public virtual Categories Categories { get; set; }
    }
}
