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
            _mapper = mapper;
        }

        public async Task<FeaturedArtistDTO> GetFeaturedArtist(int id) 
        {
            var artist = await _context.FeaturedArtists.FindAsync(id);

            var dto = new FeaturedArtistDTO(artist);

            return dto;
        }
    }
}
