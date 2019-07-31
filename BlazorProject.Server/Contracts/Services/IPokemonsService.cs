using BlazorProject.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DTO = BlazorProject.Shared.DTO;

namespace BlazorProject.Server.Contracts.Services
{
    public interface IPokemonsService
    {
        Task<List<DTO.PokemonList>> GetAll();

        Task<DTO.FullPokemon> Get(int id);

        Task<DTO.PokemonStats> GetMaxStats();

        Task<List<DTO.EvolutionChainPokemon>> GetEvolutionChain(int id);
    }
}
