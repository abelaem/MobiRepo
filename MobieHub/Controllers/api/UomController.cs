using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieHub.Services;

namespace MovieHub.Controllers.api
{
    public class UomController : ApiController
    {
       public IUOMService _UomService { get; set; }

       public UomController(IUOMService uomService)
       {
           _UomService = uomService;
       }
      // [Route("/api/uom")]
       public IHttpActionResult GetList()
       {
           var uoms = _UomService.GetList();

           return Ok(uoms);
       }
    }
}
