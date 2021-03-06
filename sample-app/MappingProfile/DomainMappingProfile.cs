using AutoMapper;
using sample_app.Models;
using sample_app.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.MappingProfile
{
    public class DomainMappingProfile : Profile
    {
        // Automapper logic
        public DomainMappingProfile()
        {
            CreateMap<ProductEditViewModel, Product>().ReverseMap();
            CreateMap<ProductAddViewModel, Product>().ReverseMap();
            CreateMap<CustomerAddModel, Customer>().ReverseMap();
            CreateMap<RegisterViewModel, ApplicationUser>()
                .ForMember(dest => dest.UserName,
                opt => opt.MapFrom(src => src.Email));
        }
    }
}
