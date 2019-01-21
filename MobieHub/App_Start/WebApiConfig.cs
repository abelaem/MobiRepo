using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Domain.Interfaces;
using Infrastructure.Data;
using MovieHub.Controllers.api;
using MovieHub.Services;
using Unity;

namespace MovieHub.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {

            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            configuration.EnableCors(corsAttr);

            var container = new UnityContainer();
            container.RegisterType(typeof(IMobiRepository<>), typeof(MobiRepository<>));

            container.RegisterType<IPartnerService, PartnerService>();
            container.RegisterType<IUOMService, UOMService>();
            container.RegisterType<IProducsCategoryService, ProducsCategoryService>();
            container.RegisterType<IProductServices, ProducService>();
            container.RegisterType<ISalesOrderLineService, SalesOrderLineService>();
            container.RegisterType<ISalesService, SaleService>();


            configuration.DependencyResolver = new WebApiDepInject.UnityResolver(container);
            configuration.MapHttpAttributeRoutes();

            configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

        }
    }
}