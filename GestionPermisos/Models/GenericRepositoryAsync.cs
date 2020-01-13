using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestionPermisos.Models
{
    public class GenericRepositoryAsync<TEntity> : IGenericRepositoryAsync<TEntity> where TEntity : class, IBaseModel
    {
        protected readonly AppDbContext Dbcontext;

        public GenericRepositoryAsync(AppDbContext context)
        {
            this.Dbcontext = context;
        }

        public async Task Add(TEntity entity)
        {
            await Dbcontext.Set<TEntity>().AddAsync(entity);
        }

        public async Task<TEntity> ById(object key)
        {
            return await Dbcontext.Set<TEntity>().FindAsync(key);
        }

        public Task Delete(TEntity entity)
        {
            Dbcontext.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<List<TEntity>> FindBy(Expression<Func<TEntity, bool>> expression)
        {
            return await Dbcontext.Set<TEntity>().Where(expression).ToListAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await Dbcontext.Set<TEntity>().ToListAsync();
        }

        public Task Update(TEntity entity)
        {
            Dbcontext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}