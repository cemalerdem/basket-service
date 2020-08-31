using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Service
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly BasketDbContext _context;

        public Repository(BasketDbContext context)
        {
            _context = context;
        }
        
        public IQueryable<TEntity> Table => _context.Set<TEntity>();

        public EntityEntry<TEntity> Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity);
        }

        public bool Any(Expression<Func<TEntity, bool>> filterBy = null)
        {
            return GetQueryable(filterBy).Any();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filterBy = null)
        {
            return await GetQueryable(filterBy).AnyAsync();
        }

        public int Count(Expression<Func<TEntity, bool>> filterBy = null)
        {
            return GetQueryable(filterBy).Count();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filterBy = null)
        {
            return await GetQueryable(filterBy).CountAsync();
        }

        public void Delete(TEntity deletedEntity)
        {
            if (_context.Entry(deletedEntity).State == EntityState.Detached)
            {
                _context.Set<TEntity>().Attach(deletedEntity);
            }

            _context.Set<TEntity>().Remove(deletedEntity);
        }

        public void Delete(object id)
        {
            TEntity deletedEntity = _context.Set<TEntity>().Find(id);

            Delete(deletedEntity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filterBy)
        {
            return GetQueryable().FirstOrDefault(filterBy);
        }


        public TEntity Get(object id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filterBy)
        {
            return await GetQueryable().FirstOrDefaultAsync(filterBy);
        }
        public async Task<TEntity> GetAsyncAsNoTracking(Expression<Func<TEntity, bool>> filterBy)
        {
            return await GetQueryable().AsNoTracking().FirstOrDefaultAsync(filterBy);
        }
        public async Task<TEntity> GetAsync(object id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public List<TEntity> GetMany(Expression<Func<TEntity, bool>> filterBy = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return GetQueryable(filterBy, orderBy).ToList();
        }


        public List<TEntity> GetManyAsNoTracking(Expression<Func<TEntity, bool>> filterBy = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return GetQueryable(filterBy, orderBy).AsNoTracking().ToList();
        }

        public async Task<List<TEntity>> GetManyAsNoTrackingAsync(Expression<Func<TEntity, bool>> filterBy = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return await GetQueryable(filterBy, orderBy).AsNoTracking().ToListAsync();
        }

        public async Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> filterBy = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            return await GetQueryable(filterBy, orderBy).ToListAsync();
        }
        public List<TEntity> GetManyAsNoTrackingIncluded(Expression<Func<TEntity, bool>> filterBy = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                           string[] path = null)
        {
            var query = GetQueryable(filterBy, orderBy).AsNoTracking();
            foreach (var item in path)
            {
                query = query.Include(item);
            }

            return query.ToList();
        }
        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filterBy = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = Table;

            if (filterBy != null)
            {
                query = query.Where(filterBy);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }
        public static IQueryable<TEntity> WhereIf<TSource>(IQueryable<TEntity> source, bool condition, Expression<Func<TEntity, bool>> predicate)
        {
            if (condition)
                return source.Where(predicate);

            return source;
        }

        public TEntity Update(TEntity updatedEntity)
        {
            if (_context.Entry(updatedEntity).State == EntityState.Detached)
            {
                _context.Set<TEntity>().Attach(updatedEntity);
            }

            _context.Entry(updatedEntity).State = EntityState.Modified;

            return updatedEntity;
        }
    }
}
