using AutoMapper;
using HomeService.Application.DTOs.Customers;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using MediatR;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Customers
{
    public class GetAllCustomersCommand : IRequest<IReadOnlyList<ReadCustomersDto>>
    {

    }

    public class GetAllCustomersCommandHandler : IRequestHandler<GetAllCustomersCommand, IReadOnlyList<ReadCustomersDto>>
    {
        private readonly IGenericRepository<ReadCustomersDto> _repository;
        private readonly IMapper _mapper;

        public GetAllCustomersCommandHandler(IGenericRepository<ReadCustomersDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ReadCustomersDto>> Handle(GetAllCustomersCommand request, CancellationToken cancellationToken)
        {

            var sqlQuery = "SELECT CustomerId, CustomerName, CustomerLocation, CustomerContact, CustomerAddress FROM Customers";
            var results = await _repository.GetAllAsync(sqlQuery);

            var customers = results.Select(r => new ReadCustomersDto
            {
                CustomerId = r.CustomerId,
                CustomerName = r.CustomerName,
                CustomerLocation = r.CustomerLocation,
                CustomerContact = r.CustomerContact,
                CustomerAddress = r.CustomerAddress
            }).ToList();

            return customers;
        }



    }
    
}
