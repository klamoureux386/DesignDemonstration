using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDemonstration.Entities
{
    public class Song
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = "";

        //One-to-Many
        public ICollection<SongRating> Ratings { get; set; } = new List<SongRating>();

        //Many-to-Many Join Tables
        public ICollection<AlbumSongs> AlbumSongs { get; set; } = new List<AlbumSongs>(); //Songs can appear on multiple albums or have alternate versions e.g. Live, Peel Sessions, etc.
        public ICollection<SongBands> SongBands { get; set; } = new List<SongBands>(); //It's possible that multiple bands can contribute to one song.
        public ICollection<MusicianSongs> MusicianSongs { get; set; } = new List<MusicianSongs>();

        //Many-to-Many Skip Navigation
        public ICollection<Album> Albums { get; set; } = new List<Album>();
        public ICollection<Bands> Bands { get; set; } = new List<Bands>();
        public ICollection<Musician> Musicians { get; set; } = new List<Musician>();
    }
}
