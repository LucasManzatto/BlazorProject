using BlazorProject.Server.Contracts;
using BlazorProject.Server.Contracts.Repository;
using BlazorProject.Server.Contracts.Services;
using BlazorProject.Server.Models;


namespace BlazorProject.Server.Services
{
    public class MangaService : ServiceBase<Manga>,IMangaService
    {
        public MangaService(IMangaRepository mangaRepository) : base(mangaRepository)
        {

        }
    }
}
