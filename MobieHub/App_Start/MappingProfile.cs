using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  AutoMapper;
using Domain.Entities;
using MovieHub.ViewModels;

namespace MovieHub.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
            
        }
    }
}