using AutoMapper;
using HomeService.Application.DTOs.Customers;
using HomeService.Application.DTOs.Workers;
using HomeService.Domain;

namespace HomeService.API.Mappers.Workers
{
    public class WorkerMapper : Profile
    {
        public WorkerMapper()
        {
            CreateMap<Worker, AddWorkersDto>().ReverseMap();
            CreateMap<Worker, ReadWorkersDetailsDto>().ReverseMap();
            CreateMap<UpdateWorkersDto, Worker>()
            .ForMember(dest => dest.WorkerId, opt => opt.MapFrom(src => src.WorkerId))  // Assuming Worker has an Id property
            .ForMember(dest => dest.WorkerContact, opt => opt.MapFrom(src => src.WorkerContact))
            .ForMember(dest => dest.WorkerAddress, opt => opt.MapFrom(src => src.WorkerAddress))
            .ForMember(dest => dest.WorkerName, opt => opt.MapFrom(src => src.WorkerName))
            .ForMember(dest => dest.WorkerLocation, opt => opt.MapFrom(src => src.WorkerLocation));
        
        CreateMap<Worker, DeleteWorkersDto>().ReverseMap();

        }
    }
}
