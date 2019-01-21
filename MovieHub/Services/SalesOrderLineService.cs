using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;
using Domain.Interfaces;

namespace MovieHub.Services
{

    public interface ISalesOrderLineService
    {
        IEnumerable<SalesOrderLine> GetList();
        IEnumerable<SalesOrderLine> GetListBySales(int salesId);
        void AddSalesOrderLine(SalesOrderLine salesOrderLine);
        void RemoveSalesOrderLine(SalesOrderLine salesOrderLine);
        void EditSalesOrderLine(SalesOrderLine salesOrderLine);
    }
    public class SalesOrderLineService: ISalesOrderLineService
    {
        private readonly IMobiRepository<SalesOrderLine> _Repository;

        public SalesOrderLineService(IMobiRepository<SalesOrderLine> mobiRepository)
        {
            _Repository = mobiRepository;
        }
        public IEnumerable<SalesOrderLine> GetList()
        {
            return _Repository.GetAll();

        }

        public IEnumerable<SalesOrderLine> GetListBySales(int salesId)
        {
            return _Repository.FindBy(s=>s.SaleId== salesId);

        }

        public void AddSalesOrderLine(SalesOrderLine salesOrderLine)
        {
            _Repository.Add(salesOrderLine);
            _Repository.Save();


        }

        public void RemoveSalesOrderLine(SalesOrderLine salesOrderLine)
        {
            _Repository.Delete(salesOrderLine);
            _Repository.Save();
        }

        public void EditSalesOrderLine(SalesOrderLine salesOrderLine)
        {
            _Repository.Edit(salesOrderLine);
            _Repository.Save();
        }
    }
}