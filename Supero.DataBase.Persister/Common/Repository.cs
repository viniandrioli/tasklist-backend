using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Supero.DataBase.Persister;

namespace Supero.DataBase.Persister.Common
{
    public abstract class Repository<C, T> : IRepository<T>
        where T : class
        where C : SuperoDbContext, new()
    {
        /// <summary>
        /// The entity framework context.
        /// </summary>
        private C entities = new C();

        private SuperoDbContextMaster _contextMaster;

        private SuperoDbContextSlave _contextSlave;

        protected SuperoDbContext ContextMaster
        {
            get
            {
                if (_contextMaster == null)
                {
                    _contextMaster = new SuperoDbContextMaster();
                }

                return _contextMaster;
            }
        }

        protected SuperoDbContext ContextSlave
        {
            get
            {
                if (_contextSlave == null)
                {
                    _contextSlave = new SuperoDbContextSlave();
                }

                return _contextSlave;
            }
        }

        /// <summary>
        /// Gets or sets the Context.
        /// </summary>
        protected C Context
        {
            get
            {
                return entities;
            }

            set
            {
                entities = value;
            }
        }

        protected internal virtual IQueryable<T> GetTable<T>()
            where T : class
        {
            try
            {
                return entities.Set<T>();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        #region IRepository Interface

        /// <summary>
        /// Set repository's context as slave.
        /// </summary>
        public virtual void SetContextAsMaster()
        {
            entities = (C)ContextMaster;
        }

        /// <summary>
        /// Set repository's context as slave.
        /// </summary>
        public virtual void SetContextAsSlave()
        {
            entities = (C)ContextSlave;
        }

        /// <summary>
        /// Add a new entity.
        /// </summary>
        /// <param name="entity">The entity argument.</param>
        public virtual void Add(T entity)
        {
            entities.Set<T>().Add(entity);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="entity">The entity argument.</param>
        public virtual void Delete(T entity)
        {
            entities.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Get all rows for an entity.
        /// </summary>
        /// <returns>The IQueryable generic object.</returns>
        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> toReturn = entities.Set<T>();
            return toReturn;
        }

        /// <summary>
        /// Save the context.
        /// </summary>
        public virtual void Save()
        {
            entities.SaveChanges();
        }

        /// <summary>
        /// Update an existing entity.
        /// </summary>
        /// <param name="entity">The entity argument.</param>
        public virtual void Update(T entity)
        {
            entities.Entry(entity).State = EntityState.Modified;
        }

        #endregion IRepository Interface

        #region IDisposable Interface

        /// <summary>
        /// The dispose flag indicator.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Dispose the object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose the object.
        /// </summary>
        /// <param name="disposing">The flag indicator.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                entities.Dispose();
            }

            disposed = true;
        }

        #endregion IDisposable Interface
    }
}
