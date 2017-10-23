using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace LinkShortener.Data.Repositories
{
    using Common.Interfaces.Repositories;

    public class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            Context = context;
        }

        #region IRepository

        public virtual async Task<T> CreateAsync(T entity)
        {
            Context.Set<T>().Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> FindByIdAsync(TKey id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> where)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(where);
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> where)
        {
            return await Context.Set<T>().Where(where).ToListAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
        }

        #endregion

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!mDisposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            mDisposed = true;
        }
        private bool mDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

