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
    [Route("[controller]")]
    public class BandsController : ControllerBase
    {
        private readonly ILogger<BandsController> _logger;
        private readonly IBandsService _bandsService;
        private readonly IMapper _mapper;

        public BandsController(ILogger<BandsController> logger,
                IBandsService bandsService,
                IMapper mapper
            )
        {
            _logger = logger;
            _bandsService = bandsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<BandDTO> Get()
        {
            var band = await _bandsService.GetBand(1);

            var dto = _mapper.Map<BandDTO>(band);

            return dto;
        }

        [HttpGet("{id}")]
        public async Task<Band> Get(int id)
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
