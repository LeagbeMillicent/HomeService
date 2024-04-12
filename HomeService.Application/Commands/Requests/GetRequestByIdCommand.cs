using AutoMapper;
using HomeService.Application.DTOs.Requests;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Requests
{
    public class GetRequestByIdCommand : IRequest<IReadOnlyList<ReadRequestsDto>>
    {
        public int RequestId { get; set; }
    }

    public class GetRequestByIdCommandHandler : IRequestHandler<GetAllRequestCommand, IReadOnlyList<ReadRequestsDto>>
    {
        private readonly IGenericRepository<ReadRequestsDto> _repository;
        private readonly IMapper _mapper;

        public GetRequestByIdCommandHandler(IGenericRepository<ReadRequestsDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<IReadOnlyList<ReadRequestsDto>> Handle(GetAllRequestCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
