using Domain.Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MovieHub.ViewModels;
using MovieHub.Services;
namespace MovieHub.Controllers.Products
{
    public class ProductsController : Controller
    {
        private readonly IMobiService<Product> _ProductService;
        private readonly IMobiService<ProducsCategory> _ProducsCategoryService;
        private readonly IMobiService<UOM> _UOMService;
        private readonly IProductServices  _productServices;


        public ProductsController(IMobiService<Product> ProductService, IMobiService<UOM> UOMService,
            IMobiService<ProducsCategory> ProducsCategoryService,IProductServices productServices)
        {
            _ProductService = ProductService;
            _ProducsCategoryService = ProducsCategoryService;
            _UOMService = UOMService;
            _productServices = productServices;
        }

        // GET: Movie
        [Authorize]
        public ActionResult Index()
        {
            

            return View(_productServices.GenerateModel());
        }

        // GET: Movie

        [Authorize]
        public ActionResult Create()
        {
            
            return View(_productServices.GenerateModelForCreate());

        }


        [Authorize]
        public ActionResult New(ProductViewModel model)
        {
            Product product = new Product();
            Mapper.Map(model, product);
            if (ModelState.IsValid)
            {
                _ProductService.Add(product);
                _ProductService.Save();

            }
            else
            {
                var ProductViewModel = new ProductViewModel();
                
                ProductViewModel.ProducsCategories = _ProducsCategoryService.GetAll().ToList();
                ProductViewModel.UOMs = _UOMService.GetAll().ToList();

                return View("Create", ProductViewModel);
            }

            return RedirectToAction("Index");
        }
    }
}