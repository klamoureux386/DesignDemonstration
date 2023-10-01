using DesignDemonstration.Entities;

namespace DesignDemonstration.DTOs
{
    public class BandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<int> AlbumIds { get; set; } = new HashSet<int>();
        public ICollection<int> MusicianIds { get; set; } = new HashSet<int>();
    }
}
