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
    public class AddWorkerCommand : IRequest<BaseResponse>
    {
        public AddWorkersDto dto {  get; set; }
    }

    public class AddWorkerCommandHandler : IRequestHandler<AddWorkerCommand, BaseResponse>
    {
        private readonly IGenericRepository<AddWorkersDto> _repository;
        private readonly IMapper _mapper;

        public AddWorkerCommandHandler(IGenericRepository<AddWorkersDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BaseResponse> Handle(AddWorkerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
