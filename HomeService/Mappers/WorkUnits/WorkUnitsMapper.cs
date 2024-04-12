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
            CreateMap<tblWorkUnit, AddWorkUnitsDto>().ReverseMap();
            CreateMap<tblWorkUnit, ReadWorkUnitsDto>().ReverseMap();
            CreateMap<tblWorkUnit, UpdateWorkUnitsDto>().ReverseMap();
            CreateMap<tblWorkUnit, DeleteWorkUnitsDto>().ReverseMap();

        }
    }
}
