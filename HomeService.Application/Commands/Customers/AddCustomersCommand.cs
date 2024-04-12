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
    public class AddCustomersCommand : IRequest<BaseResponse>
    {
        public AddCustomersDto dto { get; set; }
    }

    public class AddCustomersCommandHandler : IRequestHandler<AddCustomersCommand, BaseResponse>
    {
        private readonly IGenericRepository<AddCustomersDto> _repository;
        private readonly IMapper _mapper;

        public AddCustomersCommandHandler(IGenericRepository<AddCustomersDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BaseResponse> Handle(AddCustomersCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
