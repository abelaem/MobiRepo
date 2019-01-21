using Domain.Entities;
using MovieHub.Services;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MovieHub.Controllers.api
{
    [EnableCors("*", "*", "*")]
    public class PartnersController : ApiController
    {
        private IPartnerService _partnerService;

        public PartnersController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetPartners()
        {
            return Ok(_partnerService.GetList());
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult SearchPartners(string searchText)
        {
            return Ok(_partnerService.GetListBy(searchText));
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult AddPartner([FromBody] Partner partner)
        {
            try
            {
                _partnerService.AddPartner(partner);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return Ok();
        }
    }
}
