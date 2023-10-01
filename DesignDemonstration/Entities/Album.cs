using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDemonstration.Entities
{
    public class Album
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = "";

        //One-to-Many
        public ICollection<AlbumRating> Ratings { get; set; } = new List<AlbumRating>();
        public ICollection<SongRating> SongRatings { get; set; } = new List<SongRating>();

        //Many-to-Many Join Tables
        public ICollection<AlbumBands> AlbumBands { get; set; } = new List<AlbumBands>();
        public ICollection<AlbumMusicians> AlbumMusicians { get; set; } = new List<AlbumMusicians>();
        public ICollection<AlbumSongs> AlbumSongs { get; set; } = new List<AlbumSongs>();

        //Many-to-Many Skip Navigations
        public ICollection<Band> Bands { get; set; } = new List<Band>();
        public ICollection<Musician> Musicians { get; set; } = new List<Musician>();
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
