using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GestionPermisos.Models
{
    public interface IGenericRepositoryAsync<TEntity> where TEntity : class, IBaseModel
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<List<TEntity>> GetAll();
        Task<TEntity> ById(object key);
        Task<List<TEntity>> FindBy(Expression<Func<TEntity, bool>> expression);

    }
}