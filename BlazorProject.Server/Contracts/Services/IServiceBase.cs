using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Contracts.Repository
{
    public interface IServiceBase<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<IActionResult> PutAsync(int id, T entity);

        Task<IActionResult> Post(T entity);

        Task<IActionResult> Delete(int id);
    
    }
}
