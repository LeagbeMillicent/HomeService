using AutoMapper;
using HomeService.Application.DTOs.Workers;
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
    public class AddWorkUnitCommand : IRequest<BaseResponse>
    {
        public AddWorkUnitsDto dto { get; set; }

    }

    public class AddWorkUnitCommandHandler : IRequestHandler<AddWorkUnitCommand, BaseResponse>
    {
        private readonly IGenericRepository<AddWorkUnitsDto> _repository;
        private readonly IMapper _mapper;

        public AddWorkUnitCommandHandler(IGenericRepository<AddWorkUnitsDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(AddWorkUnitCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<AddWorkUnitsDto>(request);

            var result = await _repository.Create(map);
            return new BaseResponse
            {
                Id = result,
                Message = " Created Succesfully"
            };
        }
    }
}
