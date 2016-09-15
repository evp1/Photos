using System;
using System.Data.Entity;

namespace Photo.Models
{
    public class MapContext : DbContext
    {
        public MapContext() : base("name=PhotosContext")
        {
        }
        public DbSet<Places> Places { get; set; }

        public DbSet<Pictures> Pictures { get; set; }
    }
}