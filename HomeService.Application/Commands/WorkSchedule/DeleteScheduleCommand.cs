using AutoMapper;
using HomeService.Application.Repository;
using HomeService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.WorkSchedule
{
    public class DeleteScheduleCommand : IRequest<Unit>
    {
        public int ScheduleId { get; set; }
    }

    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand>
    {
        private readonly IGenericRepository<tblWorkSchedule> _repository;
        private readonly IMapper _mapper;

        public DeleteScheduleCommandHandler(IGenericRepository<tblWorkSchedule> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entityToUpdate = await _repository.GetAsync(request.ScheduleId);
                

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
