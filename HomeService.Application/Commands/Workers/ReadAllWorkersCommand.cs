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
    public class ReadAllWorkersCommand : IRequest<BaseResponse>
    {
        public ReadWorkersDetailsDto dto {  get; set; }
    }

    public class ReadAllWorkersCommandHandler : IRequestHandler<ReadAllWorkersCommand, BaseResponse>
    {
        private readonly IGenericRepository<ReadWorkersDetailsDto> _repository;
        private readonly IMapper _mapper;

        public ReadAllWorkersCommandHandler(IGenericRepository<ReadWorkersDetailsDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BaseResponse> Handle(ReadAllWorkersCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
