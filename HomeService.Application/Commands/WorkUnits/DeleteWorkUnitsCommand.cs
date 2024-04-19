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
    public  class DeleteWorkUnitsCommand : IRequest<Unit>
    {
        public int WorkUnitsId { get; set; }
    }

    public class DeleteWorkUnitsCommandHandler : IRequestHandler<DeleteWorkUnitsCommand>
    {
        private readonly IGenericRepository<DeleteWorkUnitsDto> _repository;
        private readonly IMapper _mapper;

        public DeleteWorkUnitsCommandHandler(IGenericRepository<DeleteWorkUnitsDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteWorkUnitsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entityToDelete = await _repository.GetAsync(request.WorkUnitsId);


                _mapper.Map(request, entityToDelete);
                await _repository.UpdateAsync(entityToDelete);
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
