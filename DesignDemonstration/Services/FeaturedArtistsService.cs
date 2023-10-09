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

        public async Task<FeaturedArtistDTO> GetFeaturedArtist(int id) 
        {
            var artist = await _context.FeaturedArtists.Include(e => e.Band).Where(e => e.Id == id).Select(e => new FeaturedArtistDTO(e)).FirstAsync();

            return artist;
        }

        public async Task<List<FeaturedArtistDTO>> GetFeaturedArtists(IEnumerable<int> ids) 
        {
            var artists = await _context.FeaturedArtists.Include(e => e.Band).Where(e => ids.Contains(e.Id)).Select(e => new FeaturedArtistDTO(e)).ToListAsync();

            return artists;
        }

        public async Task<List<FeaturedArtistDTO>> GetAllFeaturedArtists()
        {
            var artists = await _context.FeaturedArtists.Include(e => e.Band).Select(e => new FeaturedArtistDTO(e)).ToListAsync();

            return artists;
        }
    }
}
