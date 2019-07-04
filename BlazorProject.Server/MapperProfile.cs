using BlazorProject.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO = BlazorProject.Shared.DTO;

namespace BlazorProject.Server
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateMap<MainRegion, DTO.MainRegion>();
            CreateMap<DTO.MainRegion, MainRegion>();
            CreateMap<GrowthRate, DTO.GrowthRate>();
            CreateMap<DTO.GrowthRate, GrowthRate>();
            CreateMap<Generation, DTO.Generation>();
            CreateMap<DTO.Generation, Generation>();
            CreateMap<Species, DTO.Species>();
            CreateMap<DTO.Species, Species>();
            CreateMap<Pokemons, DTO.Pokemons>().ForMember(dest => dest.Species, opts => opts.MapFrom(src => src.Species));
            CreateMap<DTO.Pokemons, Pokemons>().ForMember(dest => dest.Species, opts => opts.MapFrom(src => src.Species));
        }
    }
}
