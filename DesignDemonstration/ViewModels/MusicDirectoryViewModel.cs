using DesignDemonstration.DTOs;
using DesignDemonstration.Entities;

namespace DesignDemonstration.ViewModels
{
    public class MusicDirectoryViewModel
    {
        public MusicDirectoryViewModel() 
        { 
            FeaturedArtists = new List<FeaturedArtistDTO>();
            Bands = new List<BandDTO>();
        }

        public List<FeaturedArtistDTO> FeaturedArtists { get; set; }
        public List<BandDTO> Bands { get; set; }
    }
}
