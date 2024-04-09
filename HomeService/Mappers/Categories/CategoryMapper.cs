using AutoMapper;
using HomeService.Application.DTOs.Categories;
using HomeService.Domain;

namespace HomeService.API.Mappers.Categories
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper() { 

            CreateMap<Services, AddServicesDto>().ReverseMap();
            CreateMap<Services, ReadServicesByIdCommand>().ReverseMap();
            CreateMap<Services, UpdateServicesDto>().ReverseMap();
            CreateMap<Services, DeleteServicesDto>().ReverseMap();
        }
    }
}
