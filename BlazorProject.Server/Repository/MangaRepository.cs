using BlazorProject.Server.Contracts;
using BlazorProject.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Repository
{
    public class MangaRepository : RepositoryBase<Manga>, IMangaRepository
    {
        public MangaRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
