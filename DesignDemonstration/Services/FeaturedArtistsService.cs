using DesignDemonstration.DTOs;
using DesignDemonstration.Entities;
using DesignDemonstration.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesignDemonstration.Services
{
    public class FeaturedArtistsService : IFeaturedArtistsService
    {
        private DataContext _context;

        public FeaturedArtistsService(DataContext context)
        {
            _context = context;
        }

        public async Task<FeaturedArtistDTO> Get(int id) 
        {
            var artists = await Get(new List<int> { id });

            return artists.First();
        }

        public async Task<List<FeaturedArtistDTO>> Get(IEnumerable<int> ids) 
        {
            var artists = await _context.FeaturedArtists.Include(e => e.Band).Where(e => ids.Contains(e.Id)).Select(e => new FeaturedArtistDTO(e)).ToListAsync();

            return artists;
        }

        public async Task<List<FeaturedArtistDTO>> GetAll()
        {
            var artists = await _context.FeaturedArtists.Include(e => e.Band).Select(e => new FeaturedArtistDTO(e)).ToListAsync();

            return artists;
        }
    }
}
