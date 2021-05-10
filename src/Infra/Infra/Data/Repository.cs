using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infra.Data
{
    public class Repository<T> where T : class
    {
        private DbContext Context { get; set; }
        private DbSet<T> Set { get; set; }

        public Repository(DbContext context)
        {
            Context = context;
            Set = Context?.Set<T>();
        }

        public virtual T GetById(object id)
        {
            return Set.Find(id);
        }

        public virtual void Insert(T entity)
        {
            Set.Add(entity);
        }

        public virtual void Delete(object id)
        {
            var entityToDelete = Set.Find(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(T entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
                Set.Attach(entityToDelete);

            Set.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            Set.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = Set.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            if(includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty).DefaultIfEmpty();
                }
            }
            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public virtual void SetState(T item, EntityState state) => Context.Entry(item).State = state;
    }
}