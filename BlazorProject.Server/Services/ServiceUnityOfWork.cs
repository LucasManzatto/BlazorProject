using BlazorProject.Server.Contracts.Repository;
using BlazorProject.Server.Contracts.Services;

namespace BlazorProject.Server.Services
{
    public class ServiceUnityOfWork : IServiceUnityOfWork
    {
        private readonly IRepositoryUnityOfWork unityOfWork;
        private IMangaService mangaService;

        public IMangaService MangaService
        {
            get {
                if(mangaService == null)
                {
                    mangaService = new MangaService(unityOfWork.Manga);
                }
                return mangaService;
            }
        }

        private IPokemonsService pokemonsService;

        public IPokemonsService PokemonsService
        {
            get
            {
                if (pokemonsService == null)
                {
                    pokemonsService = new PokemonsService(unityOfWork.Pokemons);
                }
                return pokemonsService;
            }
        }


        public ServiceUnityOfWork(IRepositoryUnityOfWork repositoryUnityOfWork)
        {
            unityOfWork = repositoryUnityOfWork;
        }
    }
}
