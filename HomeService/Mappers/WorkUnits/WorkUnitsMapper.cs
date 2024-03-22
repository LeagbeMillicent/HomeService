using AutoMapper;
using HomeService.Application.DTOs.Workers;
using HomeService.Application.DTOs.WorkUnits;
using HomeService.Domain;

namespace HomeService.API.Mappers.WorkUnits
{
    public class WorkUnitsMapper : Profile
    {
        public WorkUnitsMapper()
        {
            CreateMap<WorkUnit, AddWorkUnitsDto>().ReverseMap();
            CreateMap<WorkUnit, ReadWorkUnitsDto>().ReverseMap();
            CreateMap<WorkUnit, UpdateWorkUnitsDto>().ReverseMap();
            CreateMap<WorkUnit, DeleteWorkUnitsDto>().ReverseMap();

        }
    }
}
