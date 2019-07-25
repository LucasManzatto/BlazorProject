﻿using BlazorProject.Server.Models;
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
            CreateMap<Pokemons, DTO.DropdownPokemon>().ReverseMap();
            CreateMap<Pokemons, DTO.EvolutionChainPokemon>().ReverseMap();
            CreateMap<Pokemons, DTO.FullPokemon>().ReverseMap();
            CreateMap<DamageClass, DTO.DamageClass>().ReverseMap();
            CreateMap<Types, DTO.Types>().ReverseMap();
            CreateMap<PokemonTypes, DTO.PokemonTypes>().ReverseMap();
            CreateMap<PokemonStats, DTO.PokemonStats>().ReverseMap();
            CreateMap<TypeEfficacy, DTO.TypeEfficacy>().ReverseMap();
            CreateMap<Abilities, DTO.Abilities>().ReverseMap();
            CreateMap<AbilitiesProse, DTO.AbilitiesProse>().ReverseMap();
            CreateMap<PokemonAbilities, DTO.PokemonAbilities>().ReverseMap();
            CreateMap<PokemonMoves, DTO.PokemonMoves>().ReverseMap();
            CreateMap<Moves, DTO.Moves>().ReverseMap();
            CreateMap<MoveEffects, DTO.MoveEffects>().ReverseMap();
            CreateMap<MoveTargets, DTO.MoveTargets>().ReverseMap();
            CreateMap<VersionGroups, DTO.VersionGroups>().ReverseMap();
            CreateMap<MoveLearnMethods, DTO.MoveLearnMethods>().ReverseMap();
        }
    }
}
