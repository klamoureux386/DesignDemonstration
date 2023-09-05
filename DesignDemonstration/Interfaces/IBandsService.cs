using DesignDemonstration.Entities;

namespace DesignDemonstration.Interfaces
{
    public interface IBandsService
    {
        public Task<Band> GetBand(int id);
        public IQueryable<Band> GetBands(IEnumerable<int> ids);
    }
}
