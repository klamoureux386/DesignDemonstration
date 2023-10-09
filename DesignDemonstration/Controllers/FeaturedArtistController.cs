using DesignDemonstration.DTOs;
using DesignDemonstration.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignDemonstration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeaturedArtistController : ControllerBase
    {
        private readonly ILogger<MusicDirectoryController> _logger;
        private readonly IFeaturedArtistsService _featuredArtistsService;

        public FeaturedArtistController(ILogger<MusicDirectoryController> logger,
            IFeaturedArtistsService featuredArtistsService)
        {
            _logger = logger;
            _featuredArtistsService = featuredArtistsService;
        }

        [HttpGet("{id}")]
        public async Task<FeaturedArtistDTO> GetFeaturedArtist(int id)
        {
            var artist = await _featuredArtistsService.GetFeaturedArtist(id);

            return artist;
        }

        [HttpGet("All")]
        public async Task<List<FeaturedArtistDTO>> GetAllFeaturedArtists()
        {
            var dtos = await _featuredArtistsService.GetAllFeaturedArtists();

            return dtos;
        }
    }
}
