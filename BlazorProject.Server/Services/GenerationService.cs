using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorProject.Server.Contracts.Services;
using BlazorProject.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorProject.Server.Models;
using Generation = BlazorProject.Shared.DTO.Generation;

namespace BlazorProject.Server.Services
{
    public class GenerationService : IGenerationService
    {
        private readonly RepositoryContext _context;
        private readonly IMapper _mapper;

        public GenerationService(RepositoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Models.Generation> Get(int id)
        {
            return await _context.Generation.FindAsync(id);
        }

        public async Task<List<Generation>> GetAll()
        {
            return await _context.Generation
                .ProjectTo<Generation>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<DropdownPokemon>> GetPokemonsByGeneration(int generationId)
        {
            return await _context.Pokemons
                .Where(p => p.Species.GenerationId == generationId && p.IsDefault)
                .ProjectTo<DropdownPokemon>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}