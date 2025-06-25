using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Generics
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _context;
        protected DbSet<TEntity> _set;
        protected Repository(DbContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            return expression != null ? await _set.AnyAsync(expression) : await _set.AnyAsync();
        }

        public async virtual Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            return expression != null ? await _set.CountAsync(expression) : await _set.CountAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => _set.Remove(entity));
        }

        public virtual async Task DeleteByIdAsync(object entityKey)
        {
            var entity = await FindByKeyAsync(entityKey);
            if (entity != null)
            {
                await DeleteAsync(entity);
            }
        }

        public virtual async Task DeleteManyAsync(Expression<Func<TEntity, bool>>? expression = null)
        {
            var entities = await FindManyAsync(expression);
            await Task.Run(() => _set.RemoveRange(entities));
        }

        public virtual async Task<TEntity?> FindByKeyAsync(object entityKey)
        {
            return await _set.FindAsync(entityKey);
        }

        public virtual async Task<TEntity?> FindFirstAsync(Expression<Func<TEntity, bool>>? expression = null, params string[] includes)
        {
            IQueryable<TEntity> data = expression == null ? _set : _set.Where(expression);

            foreach (var include in includes)
            {
                data = data.Include(include);
            }

            return await data.FirstOrDefaultAsync();
        }

        public virtual Task<IEnumerable<TEntity>> FindManyAsync(Expression<Func<TEntity, bool>>? expression = null, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public virtual Task InsertManyAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual Task InsertOneAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task UpdateManyAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual Task UpdateOneAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
