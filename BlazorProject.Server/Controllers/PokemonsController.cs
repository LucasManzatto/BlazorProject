using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Models = BlazorProject.Server.Models;
using BlazorProject.Server.Contracts.Services;
using DTO = BlazorProject.Shared.DTO;
using AutoMapper;
using BlazorProject.Server.Models;
//using BlazorProject.Server.Models;

namespace BlazorProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : Controller
    {

        public PokemonsController()
        {
        }

        // GET: api/Pokemons
        [HttpGet]
        public async Task<List<Pokemons>> GetAll([FromServices]IPokemonsService service)
        {
            return await service.GetAll();
        }

        // GET: api/Pokemons/5
        [HttpGet("{id}")]
        public async Task<DTO.Pokemons> Get(int id, [FromServices]IPokemonsService service)
        {
            var pokemons = await service.Get(id);
            return pokemons;
        }

        //PUT: api/Pokemons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pokemons pokemonsDTO, [FromServices]IPokemonsService service)
        {
            return await service.Put(id, pokemonsDTO);
        }

        // POST: api/Pokemons
        [HttpPost]
        public async Task<IActionResult> Post(Pokemons pokemonsDTO, [FromServices]IPokemonsService service)
        {
            return await service.Post(pokemonsDTO);
        }

        // DELETE: api/Pokemons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromServices]IPokemonsService service)
        {
            return await service.Delete(id);
        }
    }
}
