using Domain.Interfaces;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Data
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
       
        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new MobiERPDbContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();
 
                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);
                 
                list = dbQuery
                    .AsNoTracking()
                    .ToList<T>();
            }
            return list;
        }
 
        public virtual IList<T> GetList(Func<T, bool> where, 
             params Expression<Func<T,object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new MobiERPDbContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();
                 
                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);
 
                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();
            }
            return list;
        }
 
        public virtual T GetSingle(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            using (var context = new MobiERPDbContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();
                 
                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);
 
                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause
            }
            return item;
        }

        void IGenericDataRepository<T>.Add(params T[] items)
        {
            throw new NotImplementedException();
        }

        
        void IGenericDataRepository<T>.Remove(params T[] items)
        {
            throw new NotImplementedException();
        }

        void IGenericDataRepository<T>.Update(params T[] items)
        {
            throw new NotImplementedException();
        }
    }
}
