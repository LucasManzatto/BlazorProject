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
    public class PokemonsController : Controller
    {
        private readonly IPokemonsService service;
        private readonly IMapper mapper;

        public PokemonsController(IServiceUnityOfWork unityOfWork)
        {
            service = unityOfWork.PokemonsService;
            mapper = AutoMapperConfig.CreateMapping<Models.Pokemons, DTO.Pokemons>();
        }

        // GET: api/Pokemons
        [HttpGet]
        public async Task<DTO.Pokemons[]> GetAll()
        {
            var pokemons = await service.GetAll();
            var pokemonsDTO = mapper.Map<DTO.Pokemons[]>(pokemons);
            return pokemonsDTO;
        }

        // GET: api/Pokemons/5
        [HttpGet("{id}")]
        public async Task<DTO.Pokemons> Get(int id)
        {
            var pokemons = await service.Get(id);
            var pokemonsDTO = mapper.Map<DTO.Pokemons>(pokemons);
            return pokemonsDTO;
        }

        // PUT: api/Pokemons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DTO.Pokemons pokemonsDTO)
        {
            var pokemons = mapper.Map<Models.Pokemons>(pokemonsDTO);
            return await service.PutAsync(id, pokemons);
        }

        // POST: api/Pokemons
        [HttpPost]
        public async Task<IActionResult> Post(DTO.Pokemons pokemonsDTO)
        {
            var pokemons = mapper.Map<Models.Pokemons>(pokemonsDTO);
            return await service.Post(pokemons);
        }

        // DELETE: api/Pokemons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await service.Delete(id);
        }
    }
}
