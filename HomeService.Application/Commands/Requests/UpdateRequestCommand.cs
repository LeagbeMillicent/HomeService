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
    public class UpdateRequestCommand : IRequest<BaseResponse>
    {
        public UpdateRequestsDto dto { get; set; }
    }

    public class UpdateRequestCommandHandler : IRequestHandler<UpdateRequestCommand, BaseResponse>
    {
        private readonly IGenericRepository<UpdateRequestsDto> _genericRepo;
        private readonly IMapper _mapper;

        public UpdateRequestCommandHandler(IGenericRepository<UpdateRequestsDto> genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }

        public Task<BaseResponse> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
