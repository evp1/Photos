using System.Data.Entity;

namespace Photo.Models
{
    public class PlacesContext : DbContext
    {
        public PlacesContext() : base("name=PhotosContext")
        {
        }
        public DbSet<Places> Places { get; set; }
        public DbSet<Countries> Countries { get; set; }
    }
}
