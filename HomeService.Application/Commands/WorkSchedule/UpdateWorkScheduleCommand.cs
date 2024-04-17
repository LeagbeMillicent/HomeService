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
    public class UpdateWorkScheduleCommand : IRequest<Unit>
    {
        public int ScheduleId { get; set; }
    }

    public class UpdateWorkScheduleCommandHandler : IRequestHandler<UpdateWorkScheduleCommand>
    {
        private readonly IGenericRepository<tblWorkSchedule> _repo;
        private readonly IMapper _mapper;

        public UpdateWorkScheduleCommandHandler(IGenericRepository<tblWorkSchedule> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWorkScheduleCommand request, CancellationToken cancellationToken)
        {
            var entityToUpdate = await _repo.GetAsync(request.ScheduleId);
            if (entityToUpdate == null)
            {
                throw new EntryPointNotFoundException($"Entity with ID {request.ScheduleId} not found.");
            }

            _mapper.Map(request, entityToUpdate);

            
            await _repo.UpdateAsync(entityToUpdate);
            return Unit.Value;
        }
    }
}
