using DesignDemonstration.DTOs;

namespace DesignDemonstration.Interfaces
{
    public interface IFeaturedArtistsService
    {
        public Task<FeaturedArtistDTO> GetFeaturedArtist(int id);
    }
}
