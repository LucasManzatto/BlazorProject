using BlazorProject.Server.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Repository
{
    public class UnityOfWork : IUnityOfWork
    {
        private RepositoryContext _repositoryContext;
        public IMangaRepository Manga => new MangaRepository(_repositoryContext);


        public UnityOfWork(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
