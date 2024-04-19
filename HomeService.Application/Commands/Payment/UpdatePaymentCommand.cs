using AutoMapper;
using HomeService.Application.Repository;
using HomeService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Payment
{
    public class UpdatePaymentCommand : IRequest<Unit>
    {
        public int PaymentId { get; set; }

    }

    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand>
    {
        private readonly IGenericRepository<tblPayment> _PaymentRepository;
        private readonly IMapper _mapper;

        public UpdatePaymentCommandHandler(IGenericRepository<tblPayment> paymentRepository, IMapper mapper)
        {
            _PaymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
        {
            var entityToUpdate = await _PaymentRepository.GetAsync(request.PaymentId);
            if (entityToUpdate == null)
            {
                throw new EntryPointNotFoundException($"Entity with ID {request.PaymentId} not found.");
            }

            _mapper.Map(request, entityToUpdate);

            await _PaymentRepository.UpdateAsync(entityToUpdate);
            return Unit.Value;
        }
    }
}
