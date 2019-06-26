using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorProject.Server;
using BlazorProject.Shared.Models;

namespace BlazorProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangasController : Controller
    {
        private readonly RepositoryContext _context;

        public MangasController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/Mangas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manga>>> GetManga()
        {
            return await _context.Manga.ToListAsync();
        }

        // GET: api/Mangas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manga>> GetManga(int id)
        {
            var manga = await _context.Manga.FindAsync(id);

            if (manga == null)
            {
                return NotFound();
            }

            return manga;
        }

        // PUT: api/Mangas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManga(int id, Manga manga)
        {
            if (id != manga.Id)
            {
                return BadRequest();
            }

            _context.Entry(manga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MangaExists(id))
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
            _context.Manga.Add(manga);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MangaExists(manga.Id))
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
            var manga = await _context.Manga.FindAsync(id);
            if (manga == null)
            {
                return NotFound();
            }

            _context.Manga.Remove(manga);
            await _context.SaveChangesAsync();

            return manga;
        }

        private bool MangaExists(int id)
        {
            return _context.Manga.Any(e => e.Id == id);
        }
    }
}
