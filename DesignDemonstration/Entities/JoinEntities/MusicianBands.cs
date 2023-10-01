using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDemonstration.Entities
{
    [Index(nameof(BandId), nameof(MusicianId), IsUnique = true)]
    public class MusicianBands
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BandId { get; set; }
        public int MusicianId { get; set; }
        public string YearsActive { get; set; } = "";
        public string Instruments { get; set; } = "";

        public Band Band { get; set; } = null!;
        public Musician Musician { get; set; } = null!;
    }
}
