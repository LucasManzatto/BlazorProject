using BlazorProject.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Contracts.Repository
{
    public interface IPokemonsRepository : IRepositoryBase<Pokemons>
    {
    }
}
