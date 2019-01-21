using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using Unity;
using Unity.Mvc5;
using Domain.Entities;
using Services;
using Services.Interfaces;
using Infrastructure.Data;
using MovieHub;
using Microsoft.AspNet.Identity;
using Unity.Lifetime;
using MovieHub.Models;
using Unity.Injection;
using MovieHub.Controllers;
using Microsoft.AspNet.Identity.EntityFramework;
using MovieHub.Services;
using Domain.Interfaces;

namespace MovieHub.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            InjectionConstructor accountInjectionConstructor =
                new InjectionConstructor(new ApplicationDbContext());

            container.RegisterType<AccountController>();
            container.RegisterType<IController, Controller>();

            container.RegisterType
                <IUserStore<ApplicationUser>, UserStore<ApplicationUser>>
                (accountInjectionConstructor);

            container.RegisterType(typeof(IMobiService<>), typeof(MobiService<>));
            container.RegisterType<IProductServices, ProducService>();
            container.RegisterType<IProducsCategoryService, ProducsCategoryService>();
            container.RegisterType<IUOMService, UOMService>();
            container.RegisterType<IPartnerService, PartnerService>();
            container.RegisterType(typeof(IMobiRepository<>), typeof(MobiRepository<>));
            container.RegisterType<ISalesOrderLineService, SalesOrderLineService>();

            container.RegisterType<ISalesService, SaleService>();

            //   container.RegisterType<MobiERPDbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}