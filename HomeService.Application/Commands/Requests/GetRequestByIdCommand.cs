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
    public class GetRequestByIdCommand : IRequest<BaseResponse>
    {
        public int RequestId { get; set; }
    }

    public class GetRequestByIdCommandHandler : IRequestHandler<GetAllRequestCommand, BaseResponse>
    {
        private readonly IGenericRepository<ReadRequestsDto> _repository;
        private readonly IMapper _mapper;

        public GetRequestByIdCommandHandler(IGenericRepository<ReadRequestsDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BaseResponse> Handle(GetAllRequestCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
