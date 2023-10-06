using DesignDemonstration.Entities;

namespace DesignDemonstration.DTOs
{
    public class FeaturedArtistDTO
    {
        public FeaturedArtistDTO() 
        { 
        
        }

        public FeaturedArtistDTO(FeaturedArtist artist) 
        {
            BandId = artist.BandId;
            BandName = artist.Band.Name;
            AlbumId = artist.AlbumId;
            Description = artist.Description;
            //ImgSrc = artist.ImgSrc ? artist.ImgSrc : artist.AlbumId ? artist.Album.ImgSrc : artist.Band.ImgSrc;
            ImgSrc = artist.ImgSrc ?? "";
        }

        public int BandId { get; set; }
        public string BandName { get; set; } = "";
        public int? AlbumId { get; set; }
        public string Description { get; set; } = "";
        public string ImgSrc { get; set; }
        //public BandDTO Band { get; set; }
        //public AlbumDTO? Album { get; set; }
    }
}
