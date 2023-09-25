using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDemonstration.Entities
{
    [Index(nameof(AlbumId), nameof(SongId), IsUnique = true)]
    public class AlbumSongs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int SongId { get; set; }
        public int Length { get; set; } //In seconds

        public Album Album { get; set; } = null!;
        public Song Song { get; set; } = null!;
    }
}
