using DesignDemonstration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace DesignDemonstration
{
    public class DataContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumSongs> AlbumSongs { get; set; }
        public DbSet<AlbumRating> AlbumRatings { get; set; }
        public DbSet<Article> ArticleTemplate { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<FeaturedArtist> FeaturedArtists { get; set; }
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
            DbPath = Path.Join(path, "music.db");
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

            //ArticleTemplate serialization setup
            //https://learn.microsoft.com/en-us/ef/core/modeling/value-comparers?tabs=ef5#mutable-classes
            modelBuilder.Entity<Article>()
                .Property(e => e.ImgSrcs)
                .HasConversion(v => System.Text.Json.JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                               v => System.Text.Json.JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null),
                               new ValueComparer<List<string>>(
                                (c1, c2) => c1.SequenceEqual(c2),
                                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                                c => c.ToList()));
        }
    }
}
