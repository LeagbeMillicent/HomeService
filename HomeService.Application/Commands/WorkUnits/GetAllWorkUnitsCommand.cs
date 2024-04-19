using AutoMapper;
using HomeService.Application.DTOs.WorkSchedule;
using HomeService.Application.DTOs.WorkUnits;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.WorkUnits
{
    public class GetAllWorkUnitsCommand : IRequest<List<ReadWorkUnitsDto>>
    {
        public ReadWorkUnitsDto dto {  get; set; }
    }

    public class GetAllWorkUnitsCommandHandler : IRequestHandler<GetAllWorkUnitsCommand, List<ReadWorkUnitsDto>>
    {
        private readonly IGenericRepository<ReadWorkUnitsDto> _repository;
        private readonly IMapper _mapper;

        public GetAllWorkUnitsCommandHandler(IGenericRepository<ReadWorkUnitsDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ReadWorkUnitsDto>> Handle(GetAllWorkUnitsCommand request, CancellationToken cancellationToken)
        {
            var sqlQuery = $"Select * From tblWorkUnit";
            var response = await _repository.GetAllAsync(sqlQuery);

            if (response != null)
            {
                return _mapper.Map<List<ReadWorkUnitsDto>>(response);
            }
            return null;
        }
    }
}
