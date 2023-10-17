using System.ComponentModel.DataAnnotations.Schema;

namespace DesignDemonstration.Entities
{
    public class Article
    {
        public Article() { }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //Reserved keywords, will be translated similar to markdown:
        //<Image[0]>
        public string Text { get; set; } = "";
        //Serialized on database insertion
        public List<string> ImgSrcs { get; set; } = new List<string>();


    }
}
