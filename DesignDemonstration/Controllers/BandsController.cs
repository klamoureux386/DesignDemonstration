using AutoMapper;
using DesignDemonstration.DTOs;
using DesignDemonstration.Entities;
using DesignDemonstration.Interfaces;
using DesignDemonstration.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignDemonstration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BandsController : ControllerBase
    {
        private readonly ILogger<BandsController> _logger;
        private readonly IBandsService _bandsService;

        public BandsController(ILogger<BandsController> logger,
                IBandsService bandsService
            )
        {
            _logger = logger;
            _bandsService = bandsService;
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
