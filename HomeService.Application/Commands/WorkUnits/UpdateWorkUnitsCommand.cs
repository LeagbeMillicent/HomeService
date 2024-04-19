using AutoMapper;
using HomeService.Application.DTOs.WorkUnits;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.WorkUnits
{
    public class UpdateWorkUnitsCommand : IRequest<Unit>
    {
        public int WorkUnitsId { get; set; }
    }

    public class UpdateWorkUnitsCommandHandler : IRequestHandler<UpdateWorkUnitsCommand>
    {
        private readonly IGenericRepository<UpdateWorkUnitsDto> _repository;
        private readonly IMapper _mapper;

        public UpdateWorkUnitsCommandHandler(IGenericRepository<UpdateWorkUnitsDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWorkUnitsCommand request, CancellationToken cancellationToken)
        {
            var entityToUpdate = await _repository.GetAsync(request.WorkUnitsId);
            if (entityToUpdate == null)
            {
                throw new EntryPointNotFoundException($"Entity with ID {request.WorkUnitsId} not found.");
            }

            _mapper.Map(request, entityToUpdate);

           
            await _repository.UpdateAsync(entityToUpdate);
            return Unit.Value;
        }

      
    }
}
