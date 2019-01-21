using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IMobiRepository<T>
    {
        IEnumerable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        T GetSingle(int id);
        void Save();
    }

    
    
}
