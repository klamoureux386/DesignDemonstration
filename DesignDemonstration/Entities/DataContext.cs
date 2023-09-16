using Microsoft.EntityFrameworkCore;

namespace DesignDemonstration.Entities
{
    public class DataContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Song> Songs { get; set; }

        public string DbPath { get; }

        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) 
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "music.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

    }
}
