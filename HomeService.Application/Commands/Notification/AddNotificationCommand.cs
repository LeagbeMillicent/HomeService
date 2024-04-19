using AutoMapper;
using HomeService.Application.DTOs.NotificationDto;
using HomeService.Application.DTOs.PayMent;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Notification
{
    public class AddNotificationCommand: IRequest<BaseResponse>
    {
        public AddNotificationDto notDto { get; set; }
    }

    public class AddNotificationHandler : IRequestHandler<AddNotificationCommand, BaseResponse>
    {
        private readonly IGenericRepository<AddNotificationDto> _repository;
        private readonly IMapper _mapper;

        public AddNotificationHandler(IGenericRepository<AddNotificationDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(AddNotificationCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<AddNotificationDto>(request.notDto);

            var result = await _repository.Create(map);
            return new BaseResponse
            {
                Id = result,
                Message = " Created Succesfully"
            };
        }
    }
}
