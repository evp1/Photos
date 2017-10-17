using System.Data.Entity;

namespace Photo.Models
{
    public class CountriesContext : DbContext
    {
        public CountriesContext() : base("name=PhotosContext")
        {
        }
        public DbSet<Countries> Countries { get; set; }
    }
}
