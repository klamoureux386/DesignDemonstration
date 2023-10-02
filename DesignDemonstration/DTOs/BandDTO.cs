using DesignDemonstration.Entities;

namespace DesignDemonstration.DTOs
{
    public class BandDTO
    {
        public BandDTO() { }

        public BandDTO(Band band) 
        {
            Id = band.Id;
            Name = band.Name;
            AlbumIds = band.Albums.Select(a => a.Id).ToList();
            MusicianIds = band.Musicians.Select(a => a.Id).ToList();
        }

        public int Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<int> AlbumIds { get; set; } = new HashSet<int>();
        public ICollection<int> MusicianIds { get; set; } = new HashSet<int>();
    }
}
