using DesignDemonstration.Entities;

namespace DesignDemonstration.DTOs
{
    //https://stackoverflow.com/questions/60261273/how-to-map-a-dto-with-a-many-to-many-relationship-to-a-ef-core-entity-with-a-rel
    public class BandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public ICollection<int> AlbumIds { get; set; } = new HashSet<int>();
        public ICollection<int> MusicianIds { get; set; } = new HashSet<int>();
    }
}
