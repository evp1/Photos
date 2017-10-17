using System.Data.Entity;

namespace Photo.Models
{
    public class PicturesContext : DbContext
    {
        public PicturesContext() : base("name=PhotosContext")
        {
        }

        public System.Data.Entity.DbSet<Photo.Models.Pictures> Pictures { get; set; }

        public DbSet<Places> Places { get; set; }
        public DbSet<PictureCategories> PictureCategaories { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Folders> Folders { get; set; }
    }
}
