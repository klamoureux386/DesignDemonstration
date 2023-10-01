using DesignDemonstration.Entities;

namespace DesignDemonstration.DTOs
{
    public class FeaturedArtistDTO
    {
        public int BandId { get; set; }
        public int? AlbumId { get; set; }
        public string Description { get; set; } = "";
        public Band Band { get; set; }
        public Album? Album { get; set; }
    }
}
