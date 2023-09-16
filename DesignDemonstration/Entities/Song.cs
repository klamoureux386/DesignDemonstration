using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDemonstration.Entities
{
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Length { get; set; } //In seconds

        public ICollection<Album> Albums { get; set; } = new List<Album>();
        public ICollection<Band> Bands { get; set; } = new List<Band>();
        public ICollection<Musician> Musicians { get; set; } = new List<Musician>();
    }
}
