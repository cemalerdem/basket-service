using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
                
        /// <summary>
        /// Return a queryable data source
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// Inserts a single object to the database
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="entity">The object to insert</param>
        /// <returns>The resulting object including its primary key after the insert</returns>
        EntityEntry<TEntity> Add(TEntity entity);


        /// <summary>
        /// Gets contains any objects in the databse
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filterBy">A linq expression filter to find one or more results</param>
        /// <returns>Boolean</returns>
        bool Any(Expression<Func<TEntity, bool>> filterBy = null);

        /// <summary>
        /// Gets contains any objects in the databse
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="filterBy">A linq expression filter to find one or more results</param>
        /// <returns>Boolean</returns>
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filterBy = null);
        Task<TEntity> GetAsync(object id);

        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filterBy">A linq expression filter to find one or more results</param>
        /// <returns>The count of the number of objects</returns>
        int Count(Expression<Func<TEntity, bool>> filterBy = null);

        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="filterBy">A linq expression filter to find one or more results</param>
        /// <returns>The count of the number of objects</returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filterBy = null);

        /// <summary>
        /// Deletes a single object from the database
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="id">The primary key of the object to delete</param>
        void Delete(object id);

        /// <summary>
        /// Deletes a single object from the database
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="deletedEntity">The object to delete</param>
        void Delete(TEntity deletedEntity);

        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <param name="id">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        TEntity Get(object id);

        /// <summary>
        /// Returns a single object which matches the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filterBy">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter. 
        /// If more than one object is found or if zero are found, null is returned</returns>
        TEntity Get(Expression<Func<TEntity, bool>> filterBy);


        /// <summary>
        /// Returns a queryable object which matches the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filterBy">A linq expression filter to find one or more results</param>
        /// <param name="orderBy"> A linq func order by asc or desc</param>
        /// <returns>Returns a queryable object which matches the provided expression</returns>
        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filterBy = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        /// <summary>
        /// Returns a single object which matches the provided expression
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="filterBy">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter. 
        /// If more than one object is found or if zero are found, null is returned</returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filterBy);

        /// <summary>
        /// Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filterBy">A linq expression filter to find one or more results</param>
        /// <param name="orderBy"> A linq func order by asc or desc</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        List<TEntity> GetMany(Expression<Func<TEntity, bool>> filterBy = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        /// <summary>
        /// Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="filterBy">A linq expression filter to find one or more results</param>
        /// <param name="orderBy"> A linq func order by asc or desc</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> filterBy = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        /// <summary>
        /// Returns a collection as no tracking of objects which match the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="filterBy">A linq expression filter to find one or more results</param>
        /// <param name="orderBy"> A linq func order by asc or desc</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        List<TEntity> GetManyAsNoTracking(Expression<Func<TEntity, bool>> filterBy = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        /// <summary>
        /// Returns a collection as no tracking of objects which match the provided expression
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="filterBy">A linq expression filter to find one or more results</param>
        /// <param name="orderBy"> A linq func order by asc or desc</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        Task<List<TEntity>> GetManyAsNoTrackingAsync(Expression<Func<TEntity, bool>> filterBy = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        /// <summary>
        /// Returns many data include by related object option
        /// </summary>
        /// <param name="filterBy"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeBy"></param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        List<TEntity> GetManyAsNoTrackingIncluded(Expression<Func<TEntity, bool>> filterBy = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string[] path = null);

        /// <summary>
        /// Updates a single object to the database
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="updatedEntity"></param>
        /// <returns>The resulting updated object</returns>
        TEntity Update(TEntity updatedEntity);

        Task<TEntity> GetAsyncAsNoTracking(Expression<Func<TEntity, bool>> filterBy);
    }
}