using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;
using Domain.Interfaces;


namespace MovieHub.Services
{
    public interface IUOMService
    {
        IEnumerable<UOM> GetList();

    }
    public class UOMService : IUOMService
    {

        private readonly IMobiRepository<UOM> _Repository;

        public UOMService(IMobiRepository<UOM> mobiRepository)
        {
            _Repository = mobiRepository;
        }

        public IEnumerable<UOM> GetList()
        {
            return _Repository.GetAll();

        }

    }
}