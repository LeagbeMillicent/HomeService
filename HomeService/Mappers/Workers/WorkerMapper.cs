using AutoMapper;
using HomeService.Application.DTOs.Customers;
using HomeService.Application.DTOs.Requests;
using HomeService.Application.DTOs.Workers;
using HomeService.Domain;

namespace HomeService.API.Mappers.Workers
{
    public class WorkerMapper : Profile
    {
        public WorkerMapper()
        {
            CreateMap<tblWorker, AddWorkersDto>().ReverseMap();
            CreateMap<tblWorker, ReadWorkersDetailsDto>().ReverseMap();
            CreateMap<UpdateWorkersDto, tblWorker>()
            .ForMember(dest => dest.WorkerId, opt => opt.MapFrom(src => src.WorkerId))  // Assuming Worker has an Id property
            .ForMember(dest => dest.WorkerContact, opt => opt.MapFrom(src => src.WorkerContact))
            .ForMember(dest => dest.WorkerEmail, opt => opt.MapFrom(src => src.WorkerEmail))
            .ForMember(dest => dest.WorkerName, opt => opt.MapFrom(src => src.WorkerName))
            .ForMember(dest => dest.WorkerLocation, opt => opt.MapFrom(src => src.WorkerLocation));
        
        CreateMap<tblWorker, DeleteWorkersDto>().ReverseMap();
        

        }

       
    }
}
