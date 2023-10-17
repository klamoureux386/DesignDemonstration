namespace DesignDemonstration.DTOs
{
    public class ArticleDTO
    {
        public ArticleDTO(string text, IEnumerable<string> imgSrcs) 
        { 
            Text = text;
            ImgSrcs = imgSrcs.ToList();
        }

        public string Text { get; set; } = "";
        public List<string> ImgSrcs { get; set; } = new List<string>();
    }
}
