using System.Data.Entity;

namespace Photo.Models
{
    public class PicturesContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PicturesContext() : base("name=PhotosContext")
        {
        }

        public System.Data.Entity.DbSet<Photo.Models.Pictures> Pictures { get; set; }

        public System.Data.Entity.DbSet<Photo.Models.Places> Places { get; set; }
        public System.Data.Entity.DbSet<Photo.Models.PictureCategories> PictureCategaories { get; set; }
        public System.Data.Entity.DbSet<Photo.Models.Categories> Categories { get; set; }
    }
}
