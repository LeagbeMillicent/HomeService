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
            CreateMap<Worker, UpdateWorkersDto>().ReverseMap();
            CreateMap<Worker, DeleteWorkersDto>().ReverseMap();

        }
    }
}
