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
    public class DeleteWorkersCommand : IRequest<BaseResponse>
    {
        public DeleteWorkersDto dto {  get; set; }
    }
    public class DeleteWorkersCommandHandler : IRequestHandler<DeleteWorkersCommand, BaseResponse>
    {
        private readonly IGenericRepository<DeleteWorkersDto> repository;
        private readonly IMapper _mapper;

        public DeleteWorkersCommandHandler(IGenericRepository<DeleteWorkersDto> repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public Task<BaseResponse> Handle(DeleteWorkersCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
