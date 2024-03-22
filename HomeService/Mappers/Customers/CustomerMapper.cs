using AutoMapper;
using HomeService.Application.DTOs.Customers;
using HomeService.Domain;

namespace HomeService.API.Mappers.Customers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, AddCustomersDto>().ReverseMap();
            CreateMap<Customer, ReadCustomersDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomersDto>().ReverseMap();
            CreateMap<Customer, DeleteCustomersDto>().ReverseMap();
        }

       
    }
}


