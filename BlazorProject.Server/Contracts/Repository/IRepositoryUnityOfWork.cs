using BlazorProject.Server.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Contracts.Repository
{
    public interface IRepositoryUnityOfWork
    {
        IMangaRepository Manga { get; }
        IPokemonsRepository Pokemons { get; }
        void Save();
    }
}
