using Microsoft.EntityFrameworkCore;

namespace DesignDemonstration.Entities
{
    public class DataContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumSongs> AlbumSongs { get; set; }
        public DbSet<AlbumRating> AlbumRatings { get; set; }
        public DbSet<Bands> Bands { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<MusicianSongs> MusicianSongs { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongRating> SongRatings { get; set; }
        public DbSet<User> Users { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //JoinEntities Many-to-Many Setup
            modelBuilder.Entity<Album>()
                .HasMany(e => e.Bands)
                .WithMany(e => e.Albums)
                .UsingEntity<AlbumBands>();

            modelBuilder.Entity<Album>()
                .HasMany(e => e.Musicians)
                .WithMany(e => e.Albums)
                .UsingEntity<AlbumMusicians>();

            modelBuilder.Entity<Album>()
                .HasMany(e => e.Songs)
                .WithMany(e => e.Albums)
                .UsingEntity<AlbumSongs>();

            modelBuilder.Entity<Musician>()
                .HasMany(e => e.Bands)
                .WithMany(e => e.Musicians)
                .UsingEntity<MusicianBands>();

            modelBuilder.Entity<Musician>()
                .HasMany(e => e.Songs)
                .WithMany(e => e.Musicians)
                .UsingEntity<MusicianSongs>();

            modelBuilder.Entity<Song>()
                .HasMany(e => e.Bands)
                .WithMany(e => e.Songs)
                .UsingEntity<SongBands>();
        }
    }
}
