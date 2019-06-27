using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Contracts
{
    interface IServiceBase<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<IActionResult> Put(int id, T entity);

        Task<ActionResult<T>> Post(T entity);

        Task<ActionResult<T>> Delete(int id);
    
    }
}
