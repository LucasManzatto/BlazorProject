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
            CreateMap<Pokemons, DTO.FullPokemon>().ReverseMap();
            CreateMap<DamageClass, DTO.DamageClass>().ReverseMap();
            CreateMap<Types, DTO.Types>().ReverseMap();
            CreateMap<PokemonTypes, DTO.PokemonTypes>().ReverseMap();
        }
    }
}
