using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDemonstration.Entities
{
    [Index(nameof(MusicianId), nameof(AlbumId), IsUnique = true)]
    public class AlbumMusicians
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int MusicianId { get; set; }

        public Album Album { get; set; } = null!;
        public Musician Musician { get; set; } = null!;
    }
}
