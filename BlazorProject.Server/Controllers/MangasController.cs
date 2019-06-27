using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorProject.Server;
using BlazorProject.Shared.Models;
using BlazorProject.Server.Contracts;
using BlazorProject.Server.Services;

namespace BlazorProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangasController : Controller
    {
        private readonly MangaService _mangaService;
        private readonly IUnityOfWork _repository;
        private LoggerManager _loggerManager;

        public MangasController(IUnityOfWork unityOfWork)
        {
            _loggerManager = new LoggerManager();
            _repository = unityOfWork;
            _mangaService = new MangaService(_repository.Manga);
        }

        // GET: api/Mangas
        [HttpGet]
        public async Task<IEnumerable<Manga>> GetManga()
        {
            return await _mangaService.GetAll();
        }

        // GET: api/Mangas/5
        [HttpGet("{id}")]
        public async Task<Manga> GetManga(int id)
        {
            return await _mangaService.Get(id);
        }

        // PUT: api/Mangas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManga(int id, Manga manga)
        {
            if (id != manga.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repository.Manga.Update(manga);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _loggerManager.LogError(ex.Message);
                if (!await _repository.Manga.Exists(p => p.Id == manga.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
           return NoContent();
        }

        // POST: api/Mangas
        [HttpPost]
        public async Task<ActionResult<Manga>> PostManga(Manga manga)
        {
            try
            {
                await _repository.Manga.Add(manga);
            }
            catch (DbUpdateException ex)
            {
                _loggerManager.LogError(ex.Message);
                if (!await _repository.Manga.Exists(p => p.Id == manga.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetManga", new { id = manga.Id }, manga);
        }

        // DELETE: api/Mangas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Manga>> DeleteManga(int id)
        {
            var manga = await _repository.Manga.GetByIdAsync(id);
            if (manga == null)
            {
                return NotFound();
            }

            await _repository.Manga.Remove(manga);

            return manga;
        }
    }
}
