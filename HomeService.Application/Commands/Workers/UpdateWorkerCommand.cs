using AutoMapper;
using HomeService.Application.DTOs.Workers;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Workers
{
    public class UpdateWorkerCommand : IRequest<BaseResponse>
    {
        public UpdateWorkersDto Dto { get; set; }
    }

    public class UpdateWorkerCommandHandler : IRequestHandler<UpdateWorkerCommand, BaseResponse>
    {
        private readonly IGenericRepository<UpdateWorkersDto> _repository;
        private readonly IMapper _mapper;

        public UpdateWorkerCommandHandler(IGenericRepository<UpdateWorkersDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BaseResponse> Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
