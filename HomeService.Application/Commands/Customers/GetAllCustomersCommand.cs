using AutoMapper;
using HomeService.Application.DTOs.Customers;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Customers
{
    public class GetAllCustomersCommand : IRequest<BaseResponse>
    {
        public ReadCustomersDto dto {  get; set; }
    }

    public class GetAllCustomersCommandHandler : IRequestHandler<GetAllCustomersCommand, BaseResponse>
    {
        private readonly IGenericRepository<ReadCustomersDto> _repository;
        private readonly IMapper _mapper;

        public GetAllCustomersCommandHandler(IGenericRepository<ReadCustomersDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BaseResponse> Handle(GetAllCustomersCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
