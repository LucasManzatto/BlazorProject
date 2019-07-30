using BlazorProject.Server.Models;
using DTO = BlazorProject.Shared.DTO;
using System.Linq;

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
            CreateMap<Pokemons, DTO.DropdownPokemon>().ReverseMap();
            CreateMap<Pokemons, DTO.EvolutionChainPokemon>().ReverseMap();
            CreateMap<Pokemons, DTO.FullPokemon>()
                .ForMember(m => m.BaseHappiness, opt => opt.MapFrom(p => p.Species.BaseHappiness))
                .ForMember(m => m.CaptureRate, opt => opt.MapFrom(p => p.Species.CaptureRate))
                .ForMember(m => m.GenderRate, opt => opt.MapFrom(p => p.Species.GenderRate))
                .ForMember(m => m.HatchCounter, opt => opt.MapFrom(p => p.Species.HatchCounter))
                .ReverseMap();
            CreateMap<DamageClass, DTO.DamageClass>().ReverseMap();
            CreateMap<Types, DTO.Types>().ReverseMap();
            CreateMap<PokemonTypes, DTO.PokemonTypes>().ReverseMap();
            CreateMap<PokemonStats, DTO.PokemonStats>().ReverseMap();
            CreateMap<TypeEfficacy, DTO.TypeEfficacy>().ReverseMap();
            CreateMap<Abilities, DTO.Abilities>().ReverseMap();
            CreateMap<AbilitiesProse, DTO.AbilitiesProse>().ReverseMap();
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
            CreateMap<Moves, DTO.Moves>().ReverseMap();
            CreateMap<MoveEffects, DTO.MoveEffects>().ReverseMap();
            CreateMap<MoveTargets, DTO.MoveTargets>().ReverseMap();
            CreateMap<VersionGroups, DTO.VersionGroups>().ReverseMap();
            CreateMap<MoveLearnMethods, DTO.MoveLearnMethods>().ReverseMap();
        }
    }
}
