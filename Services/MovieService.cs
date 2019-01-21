using Infrastructure.Data;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services
{
    public class MobiService<T> : IMobiService<T> where T : class
    {
        private readonly MobiRepository<T> _repository;

        public MobiService()
        {
            _repository = new MobiRepository<T>();
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            Save();
        }

        public void Edit(T entity)
        {
            _repository.Edit(entity);
            Save();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetSingle(int id)
        {
            return _repository.GetSingle(id);
        }

        public void Save()
        {
            _repository.Save();
        }
    }
}
