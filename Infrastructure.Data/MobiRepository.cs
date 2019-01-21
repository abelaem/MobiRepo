using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Data
{
    public class MobiRepository<T> : IMobiRepository<T> where T : class
    {
        private readonly MobiERPDbContext context;
       
        public MobiRepository()
        {
            context = new MobiERPDbContext();
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
           return context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {

            return context.Set<T>().AsEnumerable();
        }

        public T GetSingle(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
             
            }
          
        }
    }

    
}
