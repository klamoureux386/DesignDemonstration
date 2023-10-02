namespace DesignDemonstration.Entities
{
    public class FeaturedArtist
    {
        public int Id { get; set; }
        public int BandId { get; set; }
        public int? AlbumId { get; set; }
        public string Description { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Album? Album { get; set; }
        public Band Band { get; set; }
    }
}
