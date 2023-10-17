using DesignDemonstration.Entities;

namespace DesignDemonstration.DTOs
{
    public class BandDTO
    {
        public BandDTO() { }

        public BandDTO(int id, string name, ICollection<int> albumIds, ICollection<int> musicianIds) 
        {
            Id = id;
            Name = name;
            AlbumIds = albumIds;
            MusicianIds = musicianIds;
        }

        public int Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<int> AlbumIds { get; set; } = new HashSet<int>();
        public ICollection<int> MusicianIds { get; set; } = new HashSet<int>();
    }
}
