using BlazorProject.Server.Contracts.Repository;

namespace BlazorProject.Server.Repository
{
    public class RepositoryUnityOfWork : IRepositoryUnityOfWork
    {
        private RepositoryContext _repositoryContext;
        private IMangaRepository _manga;

        public IMangaRepository Manga
        {
            get {
                if(_manga == null)
                {
                    _manga = new MangaRepository(_repositoryContext);
                }
                return _manga; }
        }




        public RepositoryUnityOfWork(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
