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
    public class AddWorkScheduleCommand : IRequest<tblWorkSchedule>
    {
        public AddScheduleDto scheduleDto { get; set; } 
    }

    public class AddworkScheduleHandler : IRequestHandler<AddWorkScheduleCommand, tblWorkSchedule>
    {
        private readonly IGenericRepository<tblWorkSchedule> _repository;


        private readonly IMapper _mapper;

        public AddworkScheduleHandler(IGenericRepository<tblWorkSchedule> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<tblWorkSchedule> Handle(AddWorkScheduleCommand request, CancellationToken cancellationToken)
        {
          
            var newSchedule = new tblWorkSchedule
            {
                WorkerId = request.scheduleDto.WorkerId,
                Date = request.scheduleDto.Date,
                StartTime = request.scheduleDto.StartTime,
                EndTime = request.scheduleDto.EndTime

            };

            return await _repository.Create(newSchedule);

        }
    }
}
