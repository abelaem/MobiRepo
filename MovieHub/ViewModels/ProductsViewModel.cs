using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace MovieHub.ViewModels
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProducsCategory> ProducsCategories { get; set; }
        public IEnumerable<UOM> UOMs { get; set; }
    }
}