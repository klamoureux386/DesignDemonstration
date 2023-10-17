using DesignDemonstration.DTOs;

namespace DesignDemonstration.Interfaces
{
    public interface IArticleService
    {
        public Task<ArticleDTO> Get(int id);
    }
}
