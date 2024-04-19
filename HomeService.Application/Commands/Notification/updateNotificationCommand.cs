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
    public class updateNotificationCommand : IRequest<Unit>
    {
        public int NotId { get; set; }

    }

    public class updateNotificationCommandHandler : IRequestHandler<updateNotificationCommand>
    {
        private readonly IGenericRepository<tblNotification> _repository;
        private readonly IMapper _mapper;

        public updateNotificationCommandHandler(IGenericRepository<tblNotification> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(updateNotificationCommand request, CancellationToken cancellationToken)
        {
            var entityToUpdate = await _repository.GetAsync(request.NotId);
            if (entityToUpdate == null)
            {
                throw new EntryPointNotFoundException($"Entity with ID {request.NotId} not found.");
            }

            _mapper.Map(request, entityToUpdate);

            await _repository.UpdateAsync(entityToUpdate);
            return Unit.Value;
        }
    }
}
