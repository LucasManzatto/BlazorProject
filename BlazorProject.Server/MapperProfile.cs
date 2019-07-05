using BlazorProject.Server.Models;
using DTO = BlazorProject.Shared.DTO;

namespace BlazorProject.Server
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateMap<MainRegion, DTO.MainRegion>().ReverseMap();
            CreateMap<GrowthRate, DTO.GrowthRate>().ReverseMap();
            CreateMap<Generation, DTO.Generation>().ReverseMap();
            CreateMap<Species, DTO.Species>().ReverseMap();
            CreateMap<Pokemons, DTO.Pokemons>().ReverseMap();
        }
    }
}
