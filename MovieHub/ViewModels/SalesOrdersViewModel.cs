using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace MovieHub.ViewModels
{
    public class SalesOrdersViewModel
    {
        public IEnumerable<Sale> Sales { get; set; }
        public IEnumerable<SalesOrderLine> SalesOrderLine { get; set; }
        public IEnumerable<Partner> Partners { get; set; }
        

    }
}