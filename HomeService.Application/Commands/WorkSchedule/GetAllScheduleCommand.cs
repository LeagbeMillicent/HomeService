

using AutoMapper;
using HomeService.Application.DTOs.WorkSchedule;
using HomeService.Application.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.WorkSchedule
{
    public class GetAllScheduleCommand :IRequest<List<GetAllScheduleDto>>
    {

    }

    public class GetAllScheduleCommandHandler : IRequestHandler<GetAllScheduleCommand, List<GetAllScheduleDto>>
    {
        private readonly IGenericRepository<GetAllScheduleDto> _repository;
        private readonly IMapper _mapper;

        public GetAllScheduleCommandHandler(IGenericRepository<GetAllScheduleDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllScheduleDto>> Handle(GetAllScheduleCommand request, CancellationToken cancellationToken)
        {
            var sqlQuery = $"Select * From tblWorkSchedule";
            var response = await _repository.GetAllAsync(sqlQuery);

            if(response != null) 
            {
                return _mapper.Map<List<GetAllScheduleDto>>(response);
            }
            return null;
        }
    }
}
