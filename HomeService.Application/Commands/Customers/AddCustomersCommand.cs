using AutoMapper;
using HomeService.Application.DTOs.Customers;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using HomeService.Domain;
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
                // Map DTO to entity
                var customerEntity = new tblCustomer();


                await _repository.Create(customerEntity);
                customerEntity.CustomerName = request.dto.CustomerName;
                customerEntity.CustomerLocation = request.dto.CustomerLocation;
                customerEntity.CustomerContact = request.dto.CustomerContact;
                customerEntity.CustomerAddress = request.dto.CustomerAddress;


                return new BaseResponse { Id = customerEntity.CustomerId, IsSuccess = true, Message = "Customer added successfully" };
            }
            catch (Exception ex)
            {
                return new BaseResponse { IsSuccess = false, Message = $"Failed to add customer: {ex.Message}" };
            }
        }
    }
}
