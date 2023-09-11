using DesignDemonstration.DTOs;

namespace DesignDemonstration.Interfaces
{
    public interface IBandsService
    {
        public Task<List<BandDTO>> GetAllBands();
        public Task<BandDTO> GetBand(int id);
        public Task<List<BandDTO>> GetBands(IEnumerable<int> ids);
    }
}
