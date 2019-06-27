using BlazorProject.Server.Contracts.Repository;
using BlazorProject.Shared.Models;

namespace BlazorProject.Server.Repository
{
    public class MangaRepository : RepositoryBase<Manga>, IMangaRepository
    {
        public MangaRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
