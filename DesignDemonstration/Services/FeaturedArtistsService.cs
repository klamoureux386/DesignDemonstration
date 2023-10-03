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
            var artist = await _context.FeaturedArtists.Include(e => e.Band).FirstAsync(e => e.Id == id);

            var dto = new FeaturedArtistDTO(artist);

            return dto;
        }
    }
}
