using DesignDemonstration.DTOs;
using DesignDemonstration.Interfaces;
using DesignDemonstration.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesignDemonstration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ILogger<ArticleController> _logger;
        private readonly IArticleService _articleService;

        public ArticleController(ILogger<ArticleController> logger,
            IArticleService articleService)
        {
            _logger = logger;
            _articleService = articleService;
        }

        [HttpGet("{id}")]
        public async Task<ArticleDTO> Get(int id)
        {
            var article = await _articleService.Get(id);

            return article;
        }

    }
}
