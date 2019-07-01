using BlazorProject.Server.Contracts.Repository;
using BlazorProject.Server.Contracts.Services;

namespace BlazorProject.Server.Services
{
    public class ServiceUnityOfWork : IServiceUnityOfWork
    {
        private readonly IRepositoryUnityOfWork _repositoryUnityOfWork;
        private IMangaService _mangaService;

        public IMangaService MangaService
        {
            get {
                if(_mangaService == null)
                {
                    _mangaService = new MangaService(_repositoryUnityOfWork.Manga);
                }
                return _mangaService; }
        }

        public ServiceUnityOfWork(IRepositoryUnityOfWork repositoryUnityOfWork)
        {
            _repositoryUnityOfWork = repositoryUnityOfWork;
        }
    }
}
