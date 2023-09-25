using AutoMapper;
using DesignDemonstration.DTOs;
using DesignDemonstration.Entities;

namespace DesignDemonstration.Services
{
    public class AutoMapper : Profile
    {

        public AutoMapper() 
        {
            CreateMap<Bands, BandDTO>()
                .ForMember(m => m.AlbumIds, opt => opt.MapFrom(src => src.Albums.Select(e => e.Id)))
                .ForMember(m => m.MusicianIds, opt => opt.MapFrom(src => src.Musicians.Select(e => e.Id)));
        }
    }
}
