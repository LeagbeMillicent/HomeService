using AutoMapper;
using HomeService.Application.DTOs.Customers;
using HomeService.Domain;

namespace HomeService.API.Mappers.Customers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<tblCustomer, AddCustomersDto>().ReverseMap();
            CreateMap<tblCustomer, ReadCustomersDto>().ReverseMap();
            CreateMap<tblCustomer, UpdateCustomersDto>().ReverseMap();
            CreateMap<tblCustomer, DeleteCustomersDto>().ReverseMap();
        }

       
    }
}


