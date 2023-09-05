using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignDemonstration.Entities
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Band> Bands { get; set; } = new List<Band>();
        public ICollection<Musician> Musicians { get; set; } = new List<Musician>();
    }
}
