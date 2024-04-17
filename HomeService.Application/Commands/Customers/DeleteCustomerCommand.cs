using AutoMapper;
using HomeService.Application.DTOs.Customers;
using HomeService.Application.Repository;
using HomeService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Customers
{
    public class DeleteCustomerCommand : IRequest<Unit>
    {
        public int CustomerId { get; set; }
    }

    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IGenericRepository<tblCustomer> _repository;
        private readonly IMapper _mapper;

        public DeleteCustomerHandler(IGenericRepository<tblCustomer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var entityToDelete = await _repository.GetAsync(request.CustomerId);
            if (entityToDelete == null)
            {
                throw new EntryPointNotFoundException($"Entity with ID {request.CustomerId} not found.");
            }

            _mapper.Map(request.CustomerId, entityToDelete);

            await _repository.UpdateAsync(entityToDelete);
            return Unit.Value;
        }
    }
}
