using System.Data.Entity;

namespace Photo.Models
{
    public class CategoriesContext : DbContext
    {
        public CategoriesContext() : base("name=PhotosContext")
        {
        }

        public DbSet<Categories> Categories { get; set; }
    }
}
