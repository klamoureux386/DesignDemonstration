using DesignDemonstration.DTOs;
using DesignDemonstration.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesignDemonstration.Services
{
    public class ArticleService : IArticleService
    {

        private DataContext _context;

        public ArticleService(DataContext context)
        {
            _context = context;
        }
        public async Task<ArticleDTO> Get(int id) 
        { 
            var article = await _context.ArticleTemplate.FirstAsync(e => e.Id == id);

            return new ArticleDTO(article.Text, article.ImgSrcs);
        }
    }
}
