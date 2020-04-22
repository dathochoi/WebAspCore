using AutoMapper;
using WebAspCore.Data.Entities;
using WebAspCore.ViewModel.ViewModels;
using WebAspCore.ViewModel.ViewModels.Systems;

namespace WebAspCore.Services.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<Function, FunctionViewModel>();
        }
    }
}
