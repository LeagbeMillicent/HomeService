using AutoMapper;
using HomeService.Application.DTOs.Workers;
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
        private readonly IGenericRepository<ReadWorkersDetailsDto> _repository;
        private readonly IMapper _mapper;

        public AddWorkUnitCommandHandler(IGenericRepository<ReadWorkersDetailsDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BaseResponse> Handle(AddWorkUnitCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
