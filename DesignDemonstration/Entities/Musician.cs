using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDemonstration.Entities
{
    public class Musician
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = "";
        public string Instruments { get; set; } = "";

        //Many-to-Many Join Tables
        public ICollection<AlbumMusicians> AlbumMusicians { get; set; } = new List<AlbumMusicians>();
        public ICollection<MusicianBands> BandMusicians { get; set; } = new List<MusicianBands>();
        public ICollection<MusicianSongs> MusicanSongs { get; set; } = new List<MusicianSongs>();

        //Many-to-Many Skip Navigation
        public ICollection<Album> Albums { get; set; } = new List<Album>();
        public ICollection<Band> Bands { get; set; } = new List<Band>();
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
