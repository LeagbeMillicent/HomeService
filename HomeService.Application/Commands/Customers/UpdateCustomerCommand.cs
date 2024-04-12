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
    public class UpdateCustomerCommand : IRequest<BaseResponse>
    {
        public UpdateCustomersDto Dto { get; set; }
    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, BaseResponse>
    {
        private readonly IGenericRepository<UpdateCustomersDto> _repository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IGenericRepository<UpdateCustomersDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<BaseResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
