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
    public class DeletePaymentCommand : IRequest<Unit>
    {
        public int PaymentId { get; set; }

    }

    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand>
    {
        private readonly IGenericRepository<tblPayment> _repository;
        private readonly IMapper _mapper;

        public DeletePaymentCommandHandler(IGenericRepository<tblPayment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entityToUpdate = await _repository.GetAsync(request.PaymentId);


                _mapper.Map(request, entityToUpdate);
                await _repository.UpdateAsync(entityToUpdate);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return default;
        }
    }
}
