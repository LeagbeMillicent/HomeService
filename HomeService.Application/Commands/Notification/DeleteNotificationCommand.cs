using AutoMapper;
using HomeService.Application.Repository;
using HomeService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Notification
{
    public class DeleteNotificationCommand : IRequest<Unit>
    {
        public int NotId { get; set; }

    }

    public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand>
    {
        private readonly IGenericRepository<tblNotification> _repository;
        private readonly IMapper _mapper;

        public DeleteNotificationCommandHandler(IGenericRepository<tblNotification> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entityToUpdate = await _repository.GetAsync(request.NotId);


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
