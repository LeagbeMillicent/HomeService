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
    public  class DeleteWorkUnitsCommand : IRequest<BaseResponse>
    {
        public DeleteWorkUnitsDto unitsDto {  get; set; }
    }

    public class DeleteWorkUnitsCommandHandler : IRequestHandler<DeleteWorkUnitsCommand, BaseResponse>
    {
        private readonly IGenericRepository<DeleteWorkUnitsDto> _repository;
        private readonly IMapper _mapper;

        public DeleteWorkUnitsCommandHandler(IGenericRepository<DeleteWorkUnitsDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BaseResponse> Handle(DeleteWorkUnitsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
