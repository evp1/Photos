using System.ComponentModel.DataAnnotations;

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
