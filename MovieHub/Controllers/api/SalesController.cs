using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Domain.Entities;
using MovieHub.Services;

namespace MovieHub.Controllers.api
{
    public class SalesController : ApiController
    {
        public ISalesService _SalesService { get; set; }

        public SalesController(ISalesService salesService)
        {
            _SalesService = salesService;

        }

        [HttpGet]
        public IHttpActionResult GetList()
        {

            var sales = _SalesService.GetList();
            return Ok(sales);
        }
        [HttpPost]
        public IHttpActionResult PostSales([FromBody]Sale sales)
        {
            this._SalesService.AddSales(sales);
            return Ok(HttpStatusCode.OK);
        }
        [HttpPut]
        public IHttpActionResult AddSale([FromBody] Sale sales)
        {
            _SalesService.AddSales(sales);
            return Ok();
        }
    }
}
