using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDemonstration.Entities
{
    public class Musician
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }

        public ICollection<Album> Albums { get; set; } = new List<Album>();
        public ICollection<Band> Bands { get; set; } = new List<Band>();
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
