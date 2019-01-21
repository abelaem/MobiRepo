using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Domain.Entities;
using MovieHub.Services;
using MovieHub.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Services;
using Services.Interfaces;

namespace MovieHub.Controllers.api
{
    public class ProductsApiController : ApiController
    {
        // GET api/<controller>
        private readonly MobiService<Product> _ProductService;
        private IProductServices _productServices;


        public ProductsApiController(IProductServices productServices)
        {
            _productServices = productServices;
            _ProductService = new MobiService<Product>();
        }

        [Route("api/ProductsApi")]
        public IHttpActionResult Get()
        {
            var products= _ProductService.GetAll().ToList();
            return Ok(products) ;
           
        }

        [HttpGet]
        [Route("api/ProductsApi/serach/{searchText}")]
        public IHttpActionResult SearchProducts(string searchText)
        {
            var result = _productServices.GetListName(searchText).ToList();
            return Ok(result);
        }
        [Route("api/ProductsApi/GetModel")]
        [HttpGet]
        public IHttpActionResult GetModel()
        {
            var products = _productServices.GenerateModelForCreate();
            return Ok(products);

        }


        [HttpGet]
        [Route("api/ProductsApi/{id}")]
        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var product = _ProductService.GetSingle(id);
            if (product != null)
            {
                return  Ok(product);
            }
            return BadRequest();
        }

        // POST api/<controller>
        [Route("api/ProductsApi")]
        [HttpPost]
        [AcceptVerbs("Post")]
        public IHttpActionResult Post([FromBody]ProductViewModel jsonResult)
        {
            if (jsonResult != null)
            {
                     var product = new Product();
                
                    if(ModelState.IsValid)
                    {
                        Mapper.Map(jsonResult, product);
                    _ProductService.Add(product);

                    _ProductService.Save();

                    return Ok(HttpStatusCode.Created);
                    }
                
                else
                {

                   return BadRequest(); 

                }
            }

            return BadRequest();


        }
        [Route("api/ProductsApi/{id}")]
        [HttpPut]
      
        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]ProductViewModel model)
        {
            if (id != 0)
            {
                Product product = _ProductService.GetSingle(id);
                if(product!=null)
                { 
                Mapper.Map(model, product);
                _ProductService.Edit(product);
               
                return Ok(HttpStatusCode.Created);
                }
            }

            

            return BadRequest();
        }

        // DELETE api/<controller>/5
        [Route("api/ProductsApi/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            Product product = _ProductService.GetSingle(id);
            _ProductService.Delete(product);

        }
    }
}