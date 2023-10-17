using DesignDemonstration.DTOs;
using DesignDemonstration.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesignDemonstration.Services
{
    public class BandsService : IBandsService
    {
        private DataContext _context;

        public BandsService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BandDTO>> GetAllBands()
        {
            return await _context.Bands
                .Include(b => b.Albums)
                .Include(b => b.Musicians)
                .Select(b => new BandDTO(
                    b.Id,
                    b.Name,
                    b.Albums.Select(a => a.Id).ToList(),
                    b.Musicians.Select(m => m.Id).ToList()
                )).ToListAsync();
        }

        public async Task<BandDTO> GetBand(int id)
        {
            var bands = await GetBands(new int[] { id });

            var dto = bands.First();

            return dto;
        }

        public async Task<List<BandDTO>> GetBands(IEnumerable<int> ids)
        {
            return await _context.Bands
                .Where(b => ids.Contains(b.Id))
                .Include(b => b.Albums)
                .Include(b => b.Musicians)
                .Select(b => new BandDTO(
                    b.Id,
                    b.Name,
                    b.Albums.Select(a => a.Id).ToList(),
                    b.Musicians.Select(m => m.Id).ToList()
                )).ToListAsync();
        }
    }
}
