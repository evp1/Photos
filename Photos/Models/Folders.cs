using System.ComponentModel.DataAnnotations;

namespace Photo.Models
{
    public class Folders
    {
        [Key]
        public int FolderId { get; set; }
        [Required]
        [MaxLength( 200 )]
        public string FolderName { get; set; }
    }
}
