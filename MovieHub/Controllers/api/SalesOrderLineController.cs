using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieHub.Services;

namespace MovieHub.Controllers.api
{
    public class SalesOrderLineController : ApiController
    {
        public ISalesOrderLineService _SalesOrderLineService { get; set; }

        public SalesOrderLineController(ISalesOrderLineService salesOrderLineService )
        {
            _SalesOrderLineService = salesOrderLineService;
        }

        public IHttpActionResult Getall()
        {
            return Ok(_SalesOrderLineService.GetList());
        }

    }
}
