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
    public class UpdateCustomerCommand : IRequest<BaseResponse>
    {
        public int CustomerId { get; set; }
        public UpdateCustomersDto Customer { get; set; }
    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, BaseResponse>
    {
        private readonly IGenericRepository<tblCustomer> _repository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IGenericRepository<tblCustomer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entityToUpdate = await _repository.GetAsync(request.CustomerId);

            if (entityToUpdate == null)
            {
                throw new EntryPointNotFoundException($"Entity with ID {request.CustomerId} not found.");
            }

            entityToUpdate.CustomerAddress = request.Customer.CustomerAddress ?? entityToUpdate.CustomerAddress;
            entityToUpdate.CustomerContact = request.Customer.CustomerContact ?? entityToUpdate.CustomerContact;
            entityToUpdate.CustomerLocation = request.Customer.CustomerLocation ?? entityToUpdate.CustomerLocation;
           

            await _repository.UpdateAsync(entityToUpdate);
            return new BaseResponse
            {
                Id = request.CustomerId,
                IsSuccess = true,
                Message = $"Record Updated successfully"
            };

        }
    }
}
