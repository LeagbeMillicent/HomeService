using AutoMapper;
using HomeService.Application.DTOs.Categories;
using HomeService.Domain;

namespace HomeService.API.Mappers.Service
{
    public class ServicesMapper : Profile
    {
        public ServicesMapper() {
            CreateMap<tblServices, AddServicesDto>().ReverseMap();
            CreateMap<UpdateServicesDto, tblServices>()
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.CategoryType, opt => opt.MapFrom(src => src.CategoryType))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName));
        }
    }
}
