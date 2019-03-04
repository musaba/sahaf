using Entity.Models;
using Sahaf.Entity.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Sahaf.Entity.Contexts
{
    public class SahafContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Page> Pages { get; set; }

        public DbSet<PageContent> PageContents { get; set; }

        public SahafContext(DbContextOptions<SahafContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }



    }
}
