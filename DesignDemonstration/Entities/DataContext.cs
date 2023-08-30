using Microsoft.EntityFrameworkCore;

namespace DesignDemonstration.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) 
        { 
        
        }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Musician> Musicians { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>().ToTable("Band");
            modelBuilder.Entity<Musician>().ToTable("Musicians");
        }

    }
}
