using BlazorProject.Server.Models;
using DTO = BlazorProject.Shared.DTO;
using System.Linq;
using BlazorProject.Shared;

namespace BlazorProject.Server
{
    public class MapperProfile : AutoMapper.Profile
    {
        public MapperProfile()
        {
            CreateMap<Pokemons, DTO.DropdownPokemon>()
                .ForMember(m => m.Id, opt => opt.MapFrom(p => p.Id.ToString().PadLeft(3,'0')))
                .ForMember(m => m.Name, opt => opt.MapFrom(p => p.Name.FirstCharToUpper()))
                .ReverseMap();
            CreateMap<PokemonStats, DTO.PokemonStats>().ReverseMap();
            CreateMap<Pokemons, DTO.EvolutionChainPokemon>()
                .ForMember(m => m.Generation, opt => opt.MapFrom(p => p.Species.Generation.Name))
                .ReverseMap();
            CreateMap<Pokemons, DTO.PokemonList>()
                .ForMember(m => m.Generation, opt => opt.MapFrom(p => p.Species.Generation.Name))
                .ReverseMap();
            CreateMap<Pokemons, DTO.FullPokemon>()
                .ForMember(m => m.BaseHappiness, opt => opt.MapFrom(p => p.Species.BaseHappiness))
                .ForMember(m => m.CaptureRate, opt => opt.MapFrom(p => p.Species.CaptureRate))
                .ForMember(m => m.GenderRate, opt => opt.MapFrom(p => p.Species.GenderRate))
                .ForMember(m => m.HatchCounter, opt => opt.MapFrom(p => p.Species.HatchCounter))
                .ReverseMap();
            CreateMap<PokemonAbilities, DTO.PokemonAbilities>()
                .ForMember(m => m.Effect , opt => opt.MapFrom(p => p.Ability.AbilitiesProse.Effect))
                .ForMember(m => m.Name, opt => opt.MapFrom(p => p.Ability.Name))
                .ForMember(m => m.ShortEffect, opt => opt.MapFrom(p => p.Ability.AbilitiesProse.ShortEffect))
                .ReverseMap();
            CreateMap<PokemonMoves, DTO.PokemonMoves>()
                .ForMember(m => m.LearnMethods , opt => opt.MapFrom(p => p.MoveLearnMethods.Name))
                .ForMember(m => m.Accuracy, opt => opt.MapFrom(p => p.Move.Accuracy))
                .ForMember(m => m.DamageClass, opt => opt.MapFrom(p => p.Move.DamageClass.Name))
                .ForMember(m => m.Name, opt => opt.MapFrom(p => p.Move.Name))
                .ForMember(m => m.Power, opt => opt.MapFrom(p => p.Move.Power))
                .ForMember(m => m.Type, opt => opt.MapFrom(p => p.Move.Type.Name))
                .ForMember(m => m.TmMachineNumber, opt => opt.MapFrom(p => p.Move.TmMachines.First(t => t.VersionGroupId == 18).MachineNumber))
                .ReverseMap();
        }
    }
}
