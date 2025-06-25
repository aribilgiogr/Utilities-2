using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Generics
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task InsertOneAsync(TEntity entity);
        Task InsertManyAsync(IEnumerable<TEntity> entities);

        Task<TEntity?> FindByKeyAsync(object entityKey);
        Task<TEntity?> FindFirstAsync(Expression<Func<TEntity, bool>>? expression = null, params string[] includes);
        Task<IEnumerable<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>>? expression = null, params string[] includes);

        Task UpdateOneAsync(TEntity entity);
        Task UpdateManyAsync(IEnumerable<TEntity> entities);

        Task DeleteByIdAsync(object entityKey);
        Task DeleteAsync(TEntity entity);
        Task DeleteManyAsync(Expression<Func<TEntity, bool>>? expression = null);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expression = null);
        Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null);
    }
}
