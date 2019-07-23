using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorProject.Server.Contracts.Services;
using BlazorProject.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO = BlazorProject.Shared.DTO;

namespace BlazorProject.Server.Services
{
    public class PokemonsService : IPokemonsService
    {
        private readonly RepositoryContext context;
        private readonly IMapper mapper;
        public PokemonsService(RepositoryContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper; 
        }

        public async Task<DTO.FullPokemon> Get(int id)
        {
            var pokemon = await context.Pokemons
                .Include(m => m.Species)
                .Include(p => p.PokemonStats)
                .Include("PokemonTypes.Type")
                .SingleAsync(p => p.Id == id);

            var pokemonAbilities = await context.PokemonAbilities
                .Include(p => p.Ability)
                .ThenInclude(p => p.AbilitiesProse)
                .Where(p => p.PokemonId == pokemon.Id)
                .ToListAsync();

            var typeEfficacies = await context.TypeEfficacy
                .Include(p => p.TargetType)
                .Include(p => p.DamageType)
                .Where(p => pokemon.PokemonTypes.Select(s => s.TypeId).Contains(p.TargetTypeId))
                .ToListAsync();

            pokemon.PokemonAbilities = pokemonAbilities;

            var fullPokemonDTO = mapper.Map<DTO.FullPokemon>(pokemon);

            fullPokemonDTO.PokemonTypeEfficacy = mapper.Map<List<DTO.TypeEfficacy>>(typeEfficacies);

            return fullPokemonDTO;
        }

        public Task<List<DTO.DropdownPokemon>> GetAll()
        {
            return context.Pokemons
                .ProjectTo<DTO.DropdownPokemon>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        //TODO: Ordenar a evolution chain corretamente e pegar a evolution condition corretas
        //ERRORS: Tyrogue fica 
        public async Task<List<DTO.EvolutionChainPokemon>> GetEvolutionChain(int id)
        {
            var pokemonSpecies = await context.Species.FindAsync(id);

            var evolutionChain = await context.Pokemons
                .Where(p => p.Species.EvolutionChain == pokemonSpecies.EvolutionChain && p.IsDefault)
                .ProjectTo<DTO.EvolutionChainPokemon>(mapper.ConfigurationProvider)
                .OrderByDescending(p => p.SpeciesIsBaby)
                .ToListAsync();

            var evolutionChainExcludingFirst = evolutionChain.Skip(1).Select(s => s.Id);
            var pokemonEvolutionList = await context.PokemonEvolution
                .Include(p => p.TriggerItem)
                .Include(p => p.EvolutionTrigger)
                .Include(p => p.KnownMove)
                .Include(p => p.KnownMoveType)
                .Include(p => p.Location)
                .Include(p => p.HeldItem)
                .Include(p => p.PartySpecies).ThenInclude(p => p.Pokemon)
                .Where(p => evolutionChainExcludingFirst.Contains(p.EvolvedSpeciesId))
                .ToListAsync();

            // O Primeiro da evolution chain nunca evolui, então não é necessário ter uma Evolution Condition
            foreach (var chain in evolutionChain.Skip(1))
            {
                chain.EvolutionCondition = "";
                pokemonEvolutionList
                    .Where(p => p.EvolvedSpeciesId == chain.Id)
                    .ToList()
                    .ForEach(pokemonEvolution => 
                                    chain.EvolutionCondition += CreateEvolutionConditionString(pokemonEvolution));
            }
            return evolutionChain;
        }

        private string CreateEvolutionConditionString(PokemonEvolution pokemonEvolution)
        {
            
            string minimumHappiness = pokemonEvolution.MinimumHappiness != null ? "with High Happiness " : "";
            string dayTime = pokemonEvolution.TimeOfDay != null ? $"during {pokemonEvolution.TimeOfDay}time " : "";
            string minimumLevel = pokemonEvolution.MinimumLevel != null ? $"at level {pokemonEvolution.MinimumLevel} " : "";
            string minimumBeauty = pokemonEvolution.MinimumBeauty != null ? $"with max beauty " : "";
            string minimumAffection = pokemonEvolution.MinimumAffection != null ? $"with minimum affection of {pokemonEvolution.MinimumAffection} " : "";
            string triggerItem = pokemonEvolution.TriggerItemId != null ? $"{pokemonEvolution.TriggerItem.Name} " : "";
            string knowMove = pokemonEvolution.KnownMoveId != null ? $"knowing {pokemonEvolution.KnownMove.Name} " : "";
            string knowMoveType = pokemonEvolution.KnownMoveTypeId != null ? $"knowing a {pokemonEvolution.KnownMoveType.Name} type " : "";
            string location = pokemonEvolution.LocationId != null ? $"in {pokemonEvolution.Location.Name} " : "";
            string heldItem = pokemonEvolution.HeldItemId != null ? $"holding {pokemonEvolution.HeldItem.Name} " :"";
            string gender = pokemonEvolution.Gender == 1 ? "(Female) " : pokemonEvolution.Gender == 2 ? "(Male) " : "";
            string physicalStats = pokemonEvolution.RelativePhysicalStats == 1 ? "(Attack > Defense)"
                                    : pokemonEvolution.RelativePhysicalStats == -1 ? "(Attack < Defense)"
                                    : pokemonEvolution.RelativePhysicalStats == 0 ? "(Attack = Defense)"
                                    : "";
            string speciesInParty = pokemonEvolution.PartySpeciesId != null ? $"with {pokemonEvolution.PartySpecies.Pokemon.Name} on party " : "";

            string evolutionCondition = $"({pokemonEvolution.EvolutionTrigger.Name} " +
                    minimumHappiness +
                    minimumLevel +
                    triggerItem +
                    knowMove +
                    location +
                    heldItem +
                    dayTime +
                    gender +
                    physicalStats +
                    speciesInParty +
                    minimumBeauty +
                    minimumAffection +
                    knowMoveType;
            return evolutionCondition.Remove(evolutionCondition.LastIndexOf(" ")) + ")";
        }

        public async Task<DTO.PokemonStats> GetMaxStats()
        {
            DTO.PokemonStats pokeStats = new DTO.PokemonStats
            {
                Id= 0,
                Hp = await context.PokemonStats.MaxAsync(p => p.Hp),
                Attack = await context.PokemonStats.MaxAsync(p => p.Attack),
                Defense = await context.PokemonStats.MaxAsync(p => p.Defense),
                SpAttack = await context.PokemonStats.MaxAsync(p => p.SpAttack),
                SpDefense = await context.PokemonStats.MaxAsync(p => p.SpDefense),
                Speed = await context.PokemonStats.MaxAsync(p => p.Speed),
            };
            return pokeStats;
        }
    }
}
