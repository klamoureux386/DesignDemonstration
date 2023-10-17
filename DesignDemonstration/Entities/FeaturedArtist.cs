using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDemonstration.Entities
{
    public class FeaturedArtist
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BandId { get; set; }
        public int? AlbumId { get; set; }
        public string Description { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ImgSrc { get; set; } //If null, default to Album img src if available, otherwise use Band img src

        public Album? Album { get; set; }
        public Band Band { get; set; }
    }
}
