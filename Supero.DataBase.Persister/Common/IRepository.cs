using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supero.DataBase.Persister.Common
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Add a new entity.
        /// </summary>
        /// <param name="entity">The entity argument.</param>
        void Add(T entity);

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="entity">The entity argument.</param>
        void Delete(T entity);

        /// <summary>
        /// Set repository's context as master.
        /// </summary>
        void SetContextAsMaster();

        /// <summary>
        /// Set repository's context as slave.
        /// </summary>
        void SetContextAsSlave();

        /// <summary>
        /// Get all rows for an entity.
        /// </summary>
        /// <returns>The IQueryable generic object.</returns>
        IQueryable<T> GetAll();
        /// <summary>
        /// Save the context.
        /// </summary>
        void Save();

        /// <summary>
        /// Update an existing entity.
        /// </summary>
        /// <param name="entity">The entity argument.</param>
        void Update(T entity);
    }
}
