using AutoMapper;
using HomeService.Application.DTOs.Customers;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using HomeService.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        private readonly IGenericRepository<tblCustomer> _repository;
        private readonly IMapper _mapper;

        public AddCustomersCommandHandler(IGenericRepository<tblCustomer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(AddCustomersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                


                var newCustomer = new tblCustomer
                {
                    CustomerName = request.dto.CustomerName,
                    CustomerLocation = request.dto.CustomerLocation,
                    CustomerContact = request.dto.CustomerContact,
                    CustomerAddress = request.dto.CustomerAddress
                };


                var result = await _repository.Create(newCustomer);

                return new BaseResponse { Id = result.CustomerId, IsSuccess = true, Message = "Customer added successfully" };
            }
            catch (Exception ex)
            {
                return new BaseResponse { IsSuccess = false, Message = $"Failed to add customer: {ex.Message}" };
            }
        }
    }
}
