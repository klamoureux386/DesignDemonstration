using DesignDemonstration.DTOs;

namespace DesignDemonstration.Interfaces
{
    public interface IFeaturedArtistsService
    {
        public Task<FeaturedArtistDTO> Get(int id);
        public Task<List<FeaturedArtistDTO>> Get(IEnumerable<int> ids);
        public Task<List<FeaturedArtistDTO>> GetAll();
    }
}
