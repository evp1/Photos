using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Photo.Models
{
    public class Folders
    {
        public Folders()
        {
            this.Pictures = new HashSet<Pictures>();
        }

        [Key]
        public int FolderId { get; set; }
        [Required]
        [MaxLength( 200 )]
        public string FolderName { get; set; }

        public virtual ICollection<Pictures> Pictures { get; set; }

    }
}
