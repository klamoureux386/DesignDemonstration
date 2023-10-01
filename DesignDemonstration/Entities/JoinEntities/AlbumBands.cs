using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDemonstration.Entities
{
    [Index(nameof(AlbumId), nameof(BandId), IsUnique = true)]
    public class AlbumBands
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int BandId { get; set; }

        public Album Album { get; set; } = null!;
        public Band Band { get; set; } = null!;
    }
}
