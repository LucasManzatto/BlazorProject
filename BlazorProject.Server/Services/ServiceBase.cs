using BlazorProject.Server.Contracts;
using BlazorProject.Server.Contracts.Repository;
using BlazorProject.Server.Controllers;
using BlazorProject.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProject.Server.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T: BaseEntity
    {
        private readonly ILoggerManager loggerManager;
        private readonly IRepositoryBase<T> repository;
        public ServiceBase(IRepositoryBase<T> repository)
        {
            this.repository = repository;
            this.loggerManager = new LoggerManager();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var manga = await repository.GetByIdAsync(id);
            if (manga == null)
            {
                return new NotFoundResult();
            }
            await repository.Remove(manga);

            return new OkResult();
        }

        public async Task<T> Get(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public Task<IEnumerable<T>> GetAll()
        {
            return repository.GetAll();
        }

        public async Task<IActionResult> Post(T entity)
        {
            try
            {
                await repository.Add(entity);
            }
            catch (DbUpdateException ex)
            {
                loggerManager.LogError(ex.Message);
                if (!await repository.Exists(p => p.Id == entity.Id))
                {
                    return new ConflictResult();
                }
                else
                {
                    throw;
                }
            }
            return new CreatedResult("PostManga", entity);
        }

        public async Task<IActionResult> PutAsync(int id, T entity)
        {
            if (id != entity.Id)
            {
                return new BadRequestResult();
            }
            try
            {
                await repository.Update(entity);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                loggerManager.LogError(ex.Message);
                if (!await repository.Exists(p => p.Id == entity.Id))
                {
                    return new NotFoundResult();
                }
                else
                {
                    throw;
                }
            }
            return new NoContentResult();
        }
    }
}
