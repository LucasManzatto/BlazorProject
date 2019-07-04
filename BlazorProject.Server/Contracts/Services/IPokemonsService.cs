using BlazorProject.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DTO = BlazorProject.Shared.DTO;

namespace BlazorProject.Server.Contracts.Services
{
    public interface IPokemonsService
    {
        Task<List<Pokemons>> GetAll();

        Task<DTO.Pokemons> Get(int id);

        Task<IActionResult> Put(int id, Pokemons entity);

        Task<IActionResult> Post(Pokemons entity);

        Task<IActionResult> Delete(int id);
    }
}
