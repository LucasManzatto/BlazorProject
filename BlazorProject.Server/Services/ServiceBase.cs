using BlazorProject.Server.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T: class
    {
        private readonly IRepositoryBase<T> _repository;
        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }
        public Task<ActionResult<T>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public Task<IEnumerable<T>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<ActionResult<T>> Post(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Put(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
