using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDemonstration.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Band
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string YearsActive { get; set; } = "";

        //One-to-Many
        public ICollection<FeaturedArtist> FeaturedArtists { get; set; } = new List<FeaturedArtist>();

        //Many-to-Many Join Tables
        public ICollection<AlbumBands> AlbumBands { get; set; } = new List<AlbumBands>();
        public ICollection<MusicianBands> BandMusicians { get; set; } = new List<MusicianBands>();
        public ICollection<SongBands> SongBands { get; set; } = new List<SongBands>();

        //Many-to-Many Skip Navigation
        public ICollection<Album> Albums { get; set; } = new List<Album>();
        public ICollection<Musician> Musicians { get; set; } = new List<Musician>();
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
