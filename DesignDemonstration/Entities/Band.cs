using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDemonstration.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Band
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Album> Albums { get; set; } = new List<Album>();
        public ICollection<Musician> Musicians { get; set; } = new List<Musician>();
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
