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
    public class AddRequestCommand : IRequest<BaseResponse>
    {
        public CreateRequestDto dto { get; set; }
    }

    public class AddRequestCommandHandler : IRequestHandler<AddRequestCommand, BaseResponse>
    {
        private readonly IGenericRepository<CreateRequestDto> _repository;
        private readonly IMapper _mapper;

        public AddRequestCommandHandler(IGenericRepository<CreateRequestDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BaseResponse> Handle(AddRequestCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
