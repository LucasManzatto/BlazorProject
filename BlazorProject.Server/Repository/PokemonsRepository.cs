using BlazorProject.Server.Contracts.Repository;
using BlazorProject.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Repository
{
    public class PokemonsRepository : RepositoryBase<Pokemons>, IPokemonsRepository
    {
        public PokemonsRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
