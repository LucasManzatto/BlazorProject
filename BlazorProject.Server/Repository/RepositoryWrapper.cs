using BlazorProject.Server.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IMangaRepository _manga;

        public IMangaRepository Manga
        {
            get
            {
                if(_manga == null)
                {
                    _manga = new MangaRepository(_repositoryContext);
                }
                return _manga;
            }
        }

        IMangaRepository IRepositoryWrapper.Manga => throw new NotImplementedException();

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
