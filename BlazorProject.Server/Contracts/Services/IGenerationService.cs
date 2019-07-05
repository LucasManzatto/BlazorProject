using BlazorProject.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO = BlazorProject.Shared.DTO;

namespace BlazorProject.Server.Contracts.Services
{
    public interface IGenerationService
    {
        Task<List<DTO.Generation>> GetAll();

        Task<Generation> Get(int id);

        Task<List<DTO.Pokemons>> GetPokemonsByGeneration(int generationId);
    }
}
