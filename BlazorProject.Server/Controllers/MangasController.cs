using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorProject.Shared.Models;
using BlazorProject.Server.Contracts;
using BlazorProject.Server.Services;
using BlazorProject.Server.Contracts.Repository;
using BlazorProject.Server.Contracts.Services;
using System.Net;

namespace BlazorProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangasController : Controller
    {
        private readonly IMangaService service;

        public MangasController(IServiceUnityOfWork unityOfWork)
        {
            service = unityOfWork.MangaService;
        }

        // GET: api/Mangas
        [HttpGet]
        public async Task<IEnumerable<Manga>> GetAll()
        {
            return await service.GetAll();
        }

        // GET: api/Mangas/5
        [HttpGet("{id}")]
        public async Task<Manga> Get(int id)
        {
            return await service.Get(id);
        }

        // PUT: api/Mangas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Manga manga)
        {
            return await service.PutAsync(id, manga);
        }

        // POST: api/Mangas
        [HttpPost]
        public async Task<IActionResult> Post(Manga manga)
        {
            return await service.Post(manga);
        }

        // DELETE: api/Mangas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await service.Delete(id);
        }
    }
}
