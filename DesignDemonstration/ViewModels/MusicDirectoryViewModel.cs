using DesignDemonstration.DTOs;
using DesignDemonstration.Entities;

namespace DesignDemonstration.ViewModels
{
    public class MusicDirectoryViewModel
    {
        public List<FeaturedArtistDTO> FeaturedArtists { get; set; } = new List<FeaturedArtistDTO>();
        public List<BandDTO> Bands { get; set; } = new List<BandDTO>();
    }
}
