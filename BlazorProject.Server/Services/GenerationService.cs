using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorProject.Server.Contracts.Services;
using BlazorProject.Server.Models;
using BlazorProject.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Services
{
    public class GenerationService : IGenerationService
    {
        private readonly RepositoryContext context;
        private readonly IMapper mapper;
        public GenerationService(RepositoryContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Models.Generation> Get(int id)
        {
            return await context.Generation.FindAsync(id);
        }

        public async Task<List<Shared.DTO.Generation>> GetAll()
        {
            return await context.Generation
                .ProjectTo<Shared.DTO.Generation>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<DropdownPokemon>> GetPokemonsByGeneration(int generationId)
        {
            return await context.Pokemons
                .Where(p => p.Species.GenerationId == generationId && p.IsDefault)
                .ProjectTo<DropdownPokemon>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
