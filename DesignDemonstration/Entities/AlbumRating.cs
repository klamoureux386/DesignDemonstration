using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DesignDemonstration.Entities
{
    //Ensure only 1 review exists per Album per user.
    [Index(nameof(AlbumId), nameof(UserId), IsUnique = true)]
    public class AlbumRating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int UserId { get; set; }
        [Range(0, 100)]
        public int Rating { get; set; }
        public string? Review { get; set; }

        public Album Album { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
