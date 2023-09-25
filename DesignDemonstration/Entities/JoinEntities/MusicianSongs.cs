using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDemonstration.Entities
{
    [Index(nameof(MusicianId), nameof(SongId), IsUnique = true)]
    public class MusicianSongs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SongId { get; set; }
        public int MusicianId { get; set; }
        public string Instruments { get; set; } = "";
        public bool isFeatured { get; set; } = false;

        public Song Song { get; set; } = null!;
        public Musician Musician { get; set; } = null!;
    }
}
