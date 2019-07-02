using BlazorProject.Server.Contracts.Repository;
using BlazorProject.Server.Contracts.Services;
using BlazorProject.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Services
{
    public class PokemonsService : ServiceBase<Pokemons>, IPokemonsService
    {
        public PokemonsService(IRepositoryBase<Pokemons> repository) : base(repository)
        {
        }
    }
}
