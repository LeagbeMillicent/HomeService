using AutoMapper;
using HomeService.Application.DTOs.Categories;
using HomeService.Domain;

namespace HomeService.API.Mappers.Categories
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper() { 

            CreateMap<tblServices, AddServicesDto>().ReverseMap();
            CreateMap<tblServices, ReadServicesByIdDto>().ReverseMap();
            CreateMap<tblServices, UpdateServicesDto>().ReverseMap();
            CreateMap<tblServices, DeleteServicesDto>().ReverseMap();
        }
    }
}
