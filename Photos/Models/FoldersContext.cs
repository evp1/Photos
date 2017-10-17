using System.Data.Entity;

namespace Photo.Models
{
    public class FoldersContext : DbContext
    {
        public FoldersContext() : base( "name=PhotosContext" )
        {
        }

        public DbSet<Folders> Folders { get; set; }
    }
}
