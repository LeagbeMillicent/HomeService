using AutoMapper;
using HomeService.Application.DTOs.Customers;
using HomeService.Application.DTOs.Requests;
using HomeService.Domain;

namespace HomeService.API.Mappers.Request
{
    public class RequestProfile : Profile
    {
      

        public RequestProfile()
        {
            CreateMap<CreateRequestDto, tblRequest>();
            CreateMap<UpdateRequestsDto, tblRequest>();
        }


    }
}
