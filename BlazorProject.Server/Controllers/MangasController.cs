using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models = BlazorProject.Server.Models;
using BlazorProject.Server.Contracts.Services;
using DTO = BlazorProject.Shared.DTO;
using AutoMapper;

namespace BlazorProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangasController : Controller
    {
        private readonly IMangaService service;
        private readonly IMapper mapper;

        public MangasController(IServiceUnityOfWork unityOfWork)
        {
            service = unityOfWork.MangaService;
            mapper = AutoMapperConfig.CreateMapping<Models.Manga, DTO.Manga>();
        }

        // GET: api/Mangas
        [HttpGet]
        public async Task<DTO.Manga[]> GetAll()
        {
            var mangas = await service.GetAll();
            var mangasDTO = mapper.Map<DTO.Manga[]>(mangas);
            return mangasDTO;
        }

        // GET: api/Mangas/5
        [HttpGet("{id}")]
        public async Task<DTO.Manga> Get(int id)
        {
            var manga = await service.Get(id);
            var mangaDTO = mapper.Map<DTO.Manga>(manga);
            return mangaDTO;
        }

        // PUT: api/Mangas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DTO.Manga mangaDTO)
        {
            var manga = mapper.Map<Models.Manga>(mangaDTO);
            return await service.PutAsync(id, manga);
        }

        // POST: api/Mangas
        [HttpPost]
        public async Task<IActionResult> Post(DTO.Manga mangaDTO)
        {
            var manga = mapper.Map<Models.Manga>(mangaDTO);
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
