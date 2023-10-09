using DesignDemonstration.DTOs;
using DesignDemonstration.Entities;
using DesignDemonstration.Interfaces;
using DesignDemonstration.Services;
using DesignDemonstration.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignDemonstration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicDirectoryController : ControllerBase
    {
        private readonly ILogger<MusicDirectoryController> _logger;
        private readonly IBandsService _bandsService;
        private readonly IFeaturedArtistsService _featuredArtistsService;

        public MusicDirectoryController(ILogger<MusicDirectoryController> logger,
                IBandsService bandsService,
                IFeaturedArtistsService featuredArtistsService
            )
        {
            _logger = logger;
            _bandsService = bandsService;
            _featuredArtistsService = featuredArtistsService;
        }

        [HttpGet("Home")]
        public async Task<MusicDirectoryViewModel> GetDirectoryHome() 
        {
            var model = new MusicDirectoryViewModel();

            model.FeaturedArtists = await _featuredArtistsService.GetAll();
            model.Bands = await _bandsService.GetAllBands();

            return model;
        }

        [HttpGet]
        public async Task<List<BandDTO>> GetAll()
        {
            var bands = await _bandsService.GetAllBands();

            return bands;
        }

        [HttpGet("{id}")]
        public async Task<BandDTO> Get(int id)
        {
            var band = await _bandsService.GetBand(id);

            return band;
        }

        //[HttpGet("{ids}")]
        //public async Task<IEnumerable<Band>> Get([FromBody]IEnumerable<int> ids)
        //{
        //    var bands = await _bandsService.GetBands(ids).ToListAsync();

        //    return bands;
        //}
    }
}
