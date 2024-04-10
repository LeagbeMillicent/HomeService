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
    public class UpdateWorkUnitsCommand : IRequest<BaseResponse>
    {
        public UpdateWorkUnitsDto dto {  get; set; }
    }

    public class UpdateWorkUnitsCommandHandler : IRequestHandler<UpdateWorkUnitsCommand, BaseResponse>
    {
        private readonly IGenericRepository<UpdateWorkUnitsDto> _repository;
        private readonly IMapper _mapper;

        public UpdateWorkUnitsCommandHandler(IGenericRepository<UpdateWorkUnitsDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BaseResponse> Handle(UpdateWorkUnitsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
