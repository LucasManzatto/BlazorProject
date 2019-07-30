using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlazorProject.Server.Contracts.Services;
using DTO = BlazorProject.Shared.DTO;
using Microsoft.Extensions.Caching.Memory;

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
        public async Task<DTO.FullPokemon> Get(int id, [FromServices]IPokemonsService service, [FromServices]IMemoryCache cache)
        {
            var pokemon = cache.Get<DTO.FullPokemon>($"GetPokemon{id}");
            if (pokemon == null)
            {
                pokemon = await service.Get(id);
                cache.Set($"GetPokemon{id}", pokemon);
            }
            return pokemon;
        }
        // GET: api/Pokemons/5/evolutionChain
        [HttpGet("{id}/evolutionChain")]
        public async Task<List<DTO.EvolutionChainPokemon>> GetEvolutionChain(int id, [FromServices]IPokemonsService service,[FromServices]IMemoryCache cache)
        {
            var evolutionChain = cache.Get<List<DTO.EvolutionChainPokemon>>($"EvolutionChain{id}");
            if(evolutionChain == null)
            {
                evolutionChain = await service.GetEvolutionChain(id);
                cache.Set($"EvolutionChain{id}", evolutionChain);
            }
            return evolutionChain;
           
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
