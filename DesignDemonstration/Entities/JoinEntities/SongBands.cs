using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDemonstration.Entities
{
    [Index(nameof(SongId), nameof(BandId), IsUnique = true)]
    public class SongBands
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SongId { get; set; }
        public int BandId { get; set; }

        public Song Song { get; set; } = null!;
        public Band Band { get; set; } = null!;
    }
}
