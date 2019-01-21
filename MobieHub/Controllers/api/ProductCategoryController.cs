using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieHub.Services;

namespace MovieHub.Controllers.api
{
    public class ProductCategoryController : ApiController
    {
        public IProducsCategoryService _ProducsCategoryService { get; set; }
        
        public ProductCategoryController(IProducsCategoryService producsCategory)
        {
            _ProducsCategoryService = producsCategory;
        }
        // [Route("/api/uom")]
        public IHttpActionResult GetList()
        {
            var category = _ProducsCategoryService.GetCategoryList();

            return Ok(category);
        }
    }
}
