using CyberArena.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CyberArena.Repository
{
    public abstract class GenericRepository<C, T>: IGenericRepository<T> where T: class where C:DbContext, new()
    {
        public C context { get; set; }

        public virtual IQueryable<T> getAll()
        {
            IQueryable<T> query = context.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = context.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }
    }
}