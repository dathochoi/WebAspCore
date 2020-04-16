using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebAspCore.Data.Entities;
using WebAspCore.ViewModel.ViewModels;

namespace WebAspCore.Services.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
        }
    }
}
