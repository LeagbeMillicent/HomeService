using AutoMapper;
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
    public class GetAllWorkUnitsCommand : IRequest<BaseResponse>
    {
        public ReadWorkUnitsDto dto {  get; set; }
    }

    public class GetAllWorkUnitsCommandHandler : IRequestHandler<GetAllWorkUnitsCommand, BaseResponse>
    {
        private readonly IGenericRepository<ReadWorkUnitsDto> _repository;
        private readonly IMapper _mapper;

        public GetAllWorkUnitsCommandHandler(IGenericRepository<ReadWorkUnitsDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BaseResponse> Handle(GetAllWorkUnitsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
