using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MovieHub.ViewModels;

namespace MovieHub.Services
{

    public interface ISalesService
    {
        IEnumerable<Sale> GetList();
        IEnumerable<Sale> GetListBySales(int salesId);
        void AddSales(Sale sales);
        void RemoveSales(Sale sales);
        void EditSales(Sale sales);
        SalesOrdersViewModel GenerateModel();
        SalesViewModel GenerateModelForCreate();
    }
    public class SaleService : ISalesService
    {
        
       
        private IUOMService _uomService;
        private IProductServices _productServices;
        private ISalesOrderLineService _salesOrderLineService;
        private IPartnerService _partnerService;

        private readonly IMobiRepository<Sale> _Repository;

        public SaleService(IMobiRepository<Sale> mobiRepository, IUOMService uomService,IProductServices productServices,ISalesOrderLineService salesOrderLine,IPartnerService partnerService)
        {
            _Repository = mobiRepository;
            _uomService = uomService;
            _partnerService = partnerService;
            _productServices = productServices;
            _salesOrderLineService = salesOrderLine;

        }
        public IEnumerable<Sale> GetList()
        {
            return _Repository.GetAll();

        }

        public IEnumerable<Sale> GetListBySales(int salesId)
        {
            return _Repository.FindBy(s => s.Id == salesId);

        }

        public void AddSales(Sale salesOrderLine)
        {
            _Repository.Add(salesOrderLine);
            _Repository.Save();


        }

        public void RemoveSales(Sale sales)
        {
            _Repository.Delete(sales);
            _Repository.Save();
        }

        public void EditSales(Sale sales)
        {
            _Repository.Edit(sales);
            _Repository.Save();
        }

        public SalesOrdersViewModel GenerateModel()
        {
            SalesOrdersViewModel salesListViewModel = new SalesOrdersViewModel
            {
                Sales = this.GetList()
            };
          
            return salesListViewModel;
        }

        public SalesViewModel GenerateModelForCreate()
        {
            var salesViewModel = new SalesViewModel();
            return salesViewModel;
        }
    }
}