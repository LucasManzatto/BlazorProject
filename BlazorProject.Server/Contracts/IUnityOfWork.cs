using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Contracts
{
    public interface IUnityOfWork
    {
        IMangaRepository Manga { get; }
        void Save();
    }
}
