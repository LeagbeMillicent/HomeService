using AutoMapper;
using HomeService.Application.DTOs.NotificationDto;
using HomeService.Application.DTOs.PayMent;
using HomeService.Application.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Notification
{
    public class GetAllNotificationCommand : IRequest<List<GetAllNotificationsDto>>
    {
    }

    public class GetAllNotificationCommandHandler : IRequestHandler<GetAllNotificationCommand, List<GetAllNotificationsDto>>
    {
        private readonly IGenericRepository<GetAllNotificationsDto> _repository;
        private readonly IMapper _mapper;

        public GetAllNotificationCommandHandler(IGenericRepository<GetAllNotificationsDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllNotificationsDto>> Handle(GetAllNotificationCommand request, CancellationToken cancellationToken)
        {
            var sqlQuery = $"Select * From tblNotification";
            var response = await _repository.GetAllAsync(sqlQuery);

            if (response != null)
            {
                return _mapper.Map<List<GetAllNotificationsDto>>(response);
            }
            return null;
        }
    }
}
