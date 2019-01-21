using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Interfaces
{
    public interface IMobiService<T>
    {
        IEnumerable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        T GetSingle(int id);
        void Save();

        //IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        //IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        //T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        //void Add(params T[] items);
        //void Update(params T[] items);
        //void Remove(params T[] items);
    }
}
