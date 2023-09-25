using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DesignDemonstration.Entities
{
    //Ensure only 1 review exists per Song per Album per User.
    [Index(nameof(SongId), nameof(AlbumId), nameof(UserId), IsUnique = true)]
    public class SongRating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SongId { get; set; }
        public int AlbumId { get; set; }
        public int UserId { get; set; }
        [Range(0, 100)]
        public int Rating { get; set; }
        public string? Review { get; set; }

        public Album Album = null!;
        public Song Song = null!;
        public User User = null!;
    }
}
