using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorProject.Server.Contracts.Services;
using Microsoft.EntityFrameworkCore;
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
            return mapper.Map<DTO.FullPokemon>(pokemon);
        }

        public Task<List<DTO.Pokemons>> GetAll()
        {
            return context.Pokemons
                .ProjectTo<DTO.Pokemons>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
