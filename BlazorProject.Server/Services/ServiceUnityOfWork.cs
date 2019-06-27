using BlazorProject.Server.Contracts;
using BlazorProject.Server.Contracts.Repository;
using BlazorProject.Server.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
