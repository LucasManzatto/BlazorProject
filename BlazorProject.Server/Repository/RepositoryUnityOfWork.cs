using BlazorProject.Server.Contracts.Repository;

namespace BlazorProject.Server.Repository
{
    public class RepositoryUnityOfWork : IRepositoryUnityOfWork
    {
        private readonly RepositoryContext context;
        private IMangaRepository _manga;
        private IPokemonsRepository pokemons;

        public IMangaRepository Manga
        {
            get {
                if(_manga == null)
                {
                    _manga = new MangaRepository(context);
                }
                return _manga; }
        }

        public IPokemonsRepository Pokemons
        {
            get
            {
                if (pokemons == null)
                {
                    pokemons = new PokemonsRepository(context);
                }
                return pokemons;
            }
        }





        public RepositoryUnityOfWork(RepositoryContext repositoryContext)
        {
            context = repositoryContext;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
