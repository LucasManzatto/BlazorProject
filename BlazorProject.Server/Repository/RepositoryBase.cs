using BlazorProject.Server.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorProject.Server.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        #region Fields

        protected RepositoryContext Context;
        private readonly DbSet<T> _dbSet;

        #endregion

        public RepositoryBase(RepositoryContext context)
        {
            Context = context;
            _dbSet = Context.Set<T>();
        }

        #region Public Methods

        public Task<T> GetByIdAsync(int id) => _dbSet.FindAsync(id).AsTask();

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
            => _dbSet.FirstOrDefaultAsync(predicate);

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            // In case AsNoTracking is used
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }

        public Task Remove(T entity)
        {
            _dbSet.Remove(entity);
            return Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public Task<int> CountAll() => _dbSet.CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => _dbSet.CountAsync(predicate);

        public Task<bool> Exists(Expression<Func<T, bool>> predicate) => _dbSet.AnyAsync(predicate);
        #endregion
    }
}
