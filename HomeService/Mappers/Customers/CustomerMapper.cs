using AutoMapper;
using HomeService.Application.Commands.Customers;
using HomeService.Application.DTOs.Customers;
using HomeService.Domain;

namespace HomeService.API.Mappers.Customers
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<tblCustomer, AddCustomersCommand>().ReverseMap();
            //CreateMap<tblCustomer, ReadCustomersDto>().ReverseMap();
            CreateMap<tblCustomer, UpdateCustomersDto>().ReverseMap();
            CreateMap<tblCustomer, DeleteCustomersDto>().ReverseMap();
        }

       
    }
}


