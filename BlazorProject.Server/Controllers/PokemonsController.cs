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
        // GET: api/Pokemons
        [HttpGet]
        public async Task<List<DTO.Pokemons>> GetAll([FromServices]IPokemonsService service)
        {
            return await service.GetAll();
        }

        // GET: api/Pokemons/5
        [HttpGet("{id}")]
        public async Task<DTO.FullPokemon> Get(int id, [FromServices]IPokemonsService service)
        {
            return await service.Get(id);
        }
    }
}
