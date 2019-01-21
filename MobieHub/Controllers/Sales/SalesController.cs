using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Domain.Entities;
using MovieHub.Services;
using MovieHub.ViewModels;
using Services.Interfaces;

namespace MovieHub.Controllers.Sales
{
    public class SalesController : Controller
    {
        private ISalesService _sales;
        // GET: Sales
        public SalesController(ISalesService sales)
        {
            _sales = sales;

        }
        [Authorize]
        public ActionResult Index()
        {
          
            return View(_sales.GenerateModel());
        }

        [Authorize]
        public ActionResult Create()
        {
         
            return View(_sales.GenerateModelForCreate());
          
        }

        [Authorize]
        public ActionResult New(SalesViewModel model)
        {
            Sale sale = new Sale();
            Mapper.Map(model, sale);
            if (ModelState.IsValid)
            {
                _sales.AddSales(sale);
               

            }

            return RedirectToAction("Index");
        }
    }

}