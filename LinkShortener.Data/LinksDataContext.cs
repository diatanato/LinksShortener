using System.Data.Entity;
using LinkShortener.Data.Models;

namespace LinkShortener.Data
{
    public class LinksDataContext : DbContext
    {
        public LinksDataContext() : base("LinksDB")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<LinksDataContext>());
        }

        public DbSet<Click>  Clicks  { get; set; }
        public DbSet<User> Clients { get; set; }
        public DbSet<Link>   Links   { get; set; }
    }
}
