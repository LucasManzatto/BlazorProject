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

        public Task<Models.Generation> Get(int id)
        {
            return context.Generation.FindAsync(id).AsTask();
        }

        public Task<List<Shared.DTO.Generation>> GetAll()
        {
            return context.Generation.ProjectTo<Shared.DTO.Generation>(mapper.ConfigurationProvider).ToListAsync();
        }

        public Task<List<Shared.DTO.Pokemons>> GetPokemonsByGeneration(int generationId)
        {
            return context.Pokemons
                .Where(p => p.Species.GenerationId == generationId && p.IsDefault)
                .ProjectTo<Shared.DTO.Pokemons>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
