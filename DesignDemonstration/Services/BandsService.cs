using DesignDemonstration.Entities;
using DesignDemonstration.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesignDemonstration.Services
{
    public class BandsService : IBandsService
    {
        private DataContext _context;

        //To do: Add Band Repo
        public BandsService(DataContext context) 
        { 
            _context = context;
        }

        public async Task<Band> GetBand(int id) 
        {
            var bands = await GetBands(new int[] { id }).ToListAsync();

            return bands.First();
        }

        public IQueryable<Band> GetBands(IEnumerable<int> ids) 
        { 
            var bands = _context.Bands.Where(b => ids.Contains(b.Id))
                .Include(b => b.Albums)
                .Include(b => b.Musicians);

            return bands;
        }
    }
}
