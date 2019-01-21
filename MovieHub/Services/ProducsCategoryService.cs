using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace MovieHub.Services
{
    public interface IProducsCategoryService
    {
        IEnumerable<ProducsCategory> GetCategoryList();

    }
    public class ProducsCategoryService: IProducsCategoryService
    {

        private readonly IMobiRepository<ProducsCategory> _Repository;

        public ProducsCategoryService(IMobiRepository<ProducsCategory> mobiRepository)
        {
            _Repository = mobiRepository;
        }

        public IEnumerable<ProducsCategory> GetCategoryList()
        {
            return _Repository.GetAll();

        }

    }
}