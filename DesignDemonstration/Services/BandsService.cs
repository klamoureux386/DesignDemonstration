using DesignDemonstration.DTOs;
using DesignDemonstration.Entities;
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
            var bands = await _context.Bands
                .Include(b => b.Albums)
                .Include(b => b.Musicians)
                .ToListAsync();

            var dtos = bands.Select(b => new BandDTO(b)).ToList();

            return dtos;
        }

        public async Task<BandDTO> GetBand(int id)
        {
            var bands = await GetBands(new int[] { id });

            var dto = bands.First();

            return dto;
        }

        public async Task<List<BandDTO>> GetBands(IEnumerable<int> ids)
        {
            var bands = await _context.Bands.Where(b => ids.Contains(b.Id))
                .Include(b => b.Albums)
                .Include(b => b.Musicians)
                .ToListAsync();

            var dtos = bands.Select(b => new BandDTO(b)).ToList();

            return dtos;
        }
    }
}
