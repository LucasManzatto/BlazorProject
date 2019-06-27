using BlazorProject.Server.Contracts;
using BlazorProject.Server.Repository;
using BlazorProject.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Services
{
    public class MangaService : ServiceBase<Manga>
    {
        public MangaService(IMangaRepository mangaRepository) : base(mangaRepository)
        {

        }
    }
}
