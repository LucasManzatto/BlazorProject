using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorProject.Server.Contracts.Services;
using BlazorProject.Server.Models;
using BlazorProject.Shared;
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
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public PokemonsService(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _mapper = mapper;
        }

        public async Task<DTO.FullPokemon> Get(int id)
        {
            return await GetPokemon(id);
        }

        private async Task<IDictionary<string, float>> GetTypeEfficacies(ICollection<string> types)
        {
            var typeEfficacies = await _context.TypeEfficacy
                .Include(p => p.TargetType)
                .Include(p => p.DamageType)
                .Where(p => types.Any(s => s == p.TargetType.Name))
                .ToListAsync();

            var efficaciesMultiplier = new Dictionary<string, float>();
            typeEfficacies
                .GroupBy(p => p.DamageTypeId)
                .ToList()
                .ForEach(typeGroup =>
                {
                    var key = typeGroup.ElementAt(0).DamageType.Name;
                    efficaciesMultiplier[key] = typeGroup.Aggregate(1,
                        (float acc, TypeEfficacy p) => acc * (((float) p.DamageFactor) / 100));
                });

            return efficaciesMultiplier;
        }

        public async Task<List<DTO.PokemonList>> GetAll()
        {
            var pokemons = await _context.Pokemons
                .Where(p => p.IsDefault)
                .ProjectTo<DTO.PokemonList>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var pokemonTypes = await _context.PokemonTypes
                .Include(p => p.Type)
                .ToListAsync();

            pokemons.ForEach(pokemon => pokemon.Types = pokemonTypes
                .Where(p => p.PokemonId == pokemon.Id)
                .Select(s => s.Type.Name)
                .ToList()
            );
            return pokemons;
        }

        public async Task<DTO.PokemonStats> GetMaxStats()
        {
            var pokeStats = new DTO.PokemonStats
            {
                Hp = await _context.PokemonStats.MaxAsync(p => p.Hp),
                Attack = await _context.PokemonStats.MaxAsync(p => p.Attack),
                Defense = await _context.PokemonStats.MaxAsync(p => p.Defense),
                SpAttack = await _context.PokemonStats.MaxAsync(p => p.SpAttack),
                SpDefense = await _context.PokemonStats.MaxAsync(p => p.SpDefense),
                Speed = await _context.PokemonStats.MaxAsync(p => p.Speed),
            };
            return pokeStats;
        }

        //TODO: Ordenar a evolution chain corretamente e pegar a evolution condition corretas
        public async Task<List<DTO.EvolutionChainPokemon>> GetEvolutionChain(int id)
        {
            var pokemonChain =
                await _context.Species.Where(p => p.Id == id).Select(x => x.EvolutionChain).SingleAsync();

            var evolutionChain = await _context.Pokemons
                .Where(p => p.Species.EvolutionChain == pokemonChain && p.IsDefault)
                .OrderByDescending(p => p.Species.IsBaby)
                .ProjectTo<DTO.EvolutionChainPokemon>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var evolutionChainExcludingFirst = evolutionChain.Skip(1).Select(s => s.Id);
            var pokemonEvolutionList = await _context.PokemonEvolution
                .Include(p => p.TriggerItem)
                .Include(p => p.EvolutionTrigger)
                .Include(p => p.KnownMove)
                .Include(p => p.KnownMoveType)
                .Include(p => p.Location)
                .Include(p => p.HeldItem)
                .Include(p => p.PartySpecies.Pokemon)
                .Where(p => evolutionChainExcludingFirst.Contains(p.EvolvedSpeciesId))
                .ToListAsync();

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

        private static string CreateEvolutionConditionString(PokemonEvolution pokemonEvolution)
        {
            var minimumHappiness = pokemonEvolution.MinimumHappiness != null ? "with High Happiness " : "";
            var dayTime = pokemonEvolution.TimeOfDay != null ? $"during {pokemonEvolution.TimeOfDay}time " : "";
            var minimumLevel = pokemonEvolution.MinimumLevel != null
                ? $"at level {pokemonEvolution.MinimumLevel} "
                : "";
            var minimumBeauty = pokemonEvolution.MinimumBeauty != null ? "with max beauty " : "";
            var minimumAffection = pokemonEvolution.MinimumAffection != null
                ? $"with minimum affection of {pokemonEvolution.MinimumAffection} "
                : "";
            var triggerItem = pokemonEvolution.TriggerItemId != null ? $"{pokemonEvolution.TriggerItem.Name} " : "";
            var knowMove = pokemonEvolution.KnownMoveId != null ? $"knowing {pokemonEvolution.KnownMove.Name} " : "";
            var knowMoveType = pokemonEvolution.KnownMoveTypeId != null
                ? $"knowing a {pokemonEvolution.KnownMoveType.Name} type "
                : "";
            var location = pokemonEvolution.LocationId != null ? $"in {pokemonEvolution.Location.Name} " : "";
            var heldItem = pokemonEvolution.HeldItemId != null ? $"holding {pokemonEvolution.HeldItem.Name} " : "";
            var gender = pokemonEvolution.Gender == 1 ? "(Female) " : pokemonEvolution.Gender == 2 ? "(Male) " : "";
            var physicalStats = pokemonEvolution.RelativePhysicalStats == 1 ? "(Attack > Defense)"
                : pokemonEvolution.RelativePhysicalStats == -1 ? "(Attack < Defense)"
                : pokemonEvolution.RelativePhysicalStats == 0 ? "(Attack = Defense)"
                : "";
            var speciesInParty = pokemonEvolution.PartySpeciesId != null
                ? $"with {pokemonEvolution.PartySpecies.Pokemon.Name} on party "
                : "";

            var evolutionCondition =
                $"({pokemonEvolution.EvolutionTrigger.Name.FirstCharToUpper().Replace("-", " ")} " +
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
            return evolutionCondition.Remove(evolutionCondition.LastIndexOf(" ", StringComparison.Ordinal)) + ")";
        }

        private async Task<DTO.FullPokemon> GetPokemon(int id)
        {
            var pokemon = await _context.Pokemons
                .ProjectTo<DTO.FullPokemon>(_mapper.ConfigurationProvider)
                .Where(p => p.Id == id)
                .SingleAsync();

            pokemon.Types = await GetPokemonTypes(id);
            pokemon.Efficacies = await GetTypeEfficacies(pokemon.Types);
            pokemon.Abilities = await GetPokemonAbilities(id);
            pokemon.Moves = await GetPokemonMoves(id);
            pokemon.Stats = await GetPokemonStats(id);

            return pokemon;
        }

        private async Task<ICollection<DTO.PokemonMoves>> GetPokemonMoves(int id)
        {
            return await _context.PokemonMoves
                .Where(p => p.PokemonId == id && p.VersionGroupId == 18)
                .ProjectTo<DTO.PokemonMoves>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.Level)
                .ToListAsync();
        }

        private async Task<DTO.PokemonStats> GetPokemonStats(int id)
        {
            return await _context.PokemonStats
                .Where(p => p.Id == id)
                .ProjectTo<DTO.PokemonStats>(_mapper.ConfigurationProvider)
                .SingleAsync();
        }

        private async Task<List<string>> GetPokemonTypes(int id)
        {
            return await _context.PokemonTypes
                .Where(p => p.PokemonId == id)
                .Select(t => t.Type.Name)
                .ToListAsync();
        }

        private async Task<List<DTO.PokemonAbilities>> GetPokemonAbilities(int id)
        {
            return await _context.PokemonAbilities
                .Where(p => p.PokemonId == id)
                .ProjectTo<DTO.PokemonAbilities>(_mapper.ConfigurationProvider)
                .OrderBy(p => p.Slot)
                .ToListAsync();
        }
    }
}