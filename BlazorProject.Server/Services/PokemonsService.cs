using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorProject.Server.Contracts.Services;
using BlazorProject.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DTO.Pokemons> Get(int id)
        {
            return context.Pokemons.ProjectTo<DTO.Pokemons>(mapper).SingleAsync(p => p.Id == id);
        }

        public Task<List<Pokemons>> GetAll()
        {
            return context.Pokemons.Include(p => p.Species).ToListAsync();
        }

        public Task<IActionResult> Post(Pokemons entity)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Put(int id, Pokemons entity)
        {
            throw new NotImplementedException();
        }
    }
}
