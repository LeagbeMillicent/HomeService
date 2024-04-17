using AutoMapper;
using HomeService.Application.DTOs.Categories;
using HomeService.Application.DTOs.WorkSchedule;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using HomeService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.WorkSchedule
{
    public class AddWorkScheduleCommand : IRequest<BaseResponse>
    {
        public AddScheduleDto scheduleDto { get; set; } 
    }

    public class AddworkScheduleHandler : IRequestHandler<AddWorkScheduleCommand, BaseResponse>
    {
        private readonly IGenericRepository<AddScheduleDto> _repository;
        private readonly IMapper _mapper;

        public AddworkScheduleHandler(IGenericRepository<AddScheduleDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(AddWorkScheduleCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<AddScheduleDto>(request);

            var result = await _repository.Create(map);
            return new BaseResponse
            {
                Id = result,
                Message = " Created Succesfully"
            };
        }
    }
}
