using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDemonstration.Entities
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string Type { get; set; } = "";    //Staff, Critic, User, etc.
        public string? DisplayName { get; set; }

        public ICollection<SongRating> SongRatings { get; set; } = new List<SongRating>();
        public ICollection<AlbumRating> AlbumsRatings { get; set; } = new List<AlbumRating>();
    }
}
