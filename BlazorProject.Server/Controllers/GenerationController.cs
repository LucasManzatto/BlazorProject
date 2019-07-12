using BlazorProject.Server.Contracts.Services;
using BlazorProject.Server.Models;
using BlazorProject.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO = BlazorProject.Shared.DTO;

namespace BlazorProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerationController : Controller
    {

        [HttpGet]
        public async Task<List<DTO.Generation>> GetAll([FromServices] IGenerationService service)
        {
            return await service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Generation> Get(int id, [FromServices] IGenerationService service)
        {
            return await service.Get(id);
        }
        [Route("{id}/pokemons")]
        [HttpGet]
        public async Task<List<DTO.DropdownPokemon>> GetPokemonsByGenerationId(int id, [FromServices] IGenerationService service)
        {
            return await service.GetPokemonsByGeneration(id);
        }
    }
}
