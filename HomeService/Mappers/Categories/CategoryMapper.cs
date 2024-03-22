using AutoMapper;
using HomeService.Application.DTOs.Categories;
using HomeService.Domain;

namespace HomeService.API.Mappers.Categories
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper() { 

            CreateMap<Services, AddCategoriesDto>().ReverseMap();
            CreateMap<Services, ReadServicesByIdCommand>().ReverseMap();
            CreateMap<Services, UpdateCategoriesDto>().ReverseMap();
            CreateMap<Services, DeleteCategoriesDto>().ReverseMap();
        }
    }
}
