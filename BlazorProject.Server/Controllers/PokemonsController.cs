using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlazorProject.Server.Contracts.Services;
using DTO = BlazorProject.Shared.DTO;

namespace BlazorProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : Controller
    {
        // GET: api/Pokemons
        [HttpGet]
        public async Task<List<DTO.DropdownPokemon>> GetAll([FromServices]IPokemonsService service)
        {
            return await service.GetAll();
        }

        // GET: api/Pokemons/5
        [HttpGet("{id}")]
        public async Task<DTO.FullPokemon> Get(int id, [FromServices]IPokemonsService service)
        {
            return await service.Get(id);
        }
        // GET: api/Pokemons/maxStats
        [HttpGet]
        [Route("maxStats")]
        public async Task<DTO.PokemonStats> GetMaxStats([FromServices]IPokemonsService service)
        {
            return await service.GetMaxStats();
        }
    }
}
