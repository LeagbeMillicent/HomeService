using AutoMapper;
using HomeService.Application.Repository;
using HomeService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Services
{
    public class DeleteServiceCommand : IRequest<Unit>
    {
        public int CategoryId { get; set; }
    }

    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
    {
        private readonly IGenericRepository<tblServices> _repo;
        private readonly IMapper _mapper;

        public DeleteServiceCommandHandler(IGenericRepository<tblServices> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var entityToUpdate = await _repo.GetAsync(request.CategoryId);
            if (entityToUpdate == null)
            {
                throw new EntryPointNotFoundException($"Entity with ID {request.CategoryId} not found.");
            }

            _mapper.Map(request, entityToUpdate);

            entityToUpdate.IsActive = false;
            await _repo.UpdateAsync(entityToUpdate);
            return Unit.Value;
        }
    }
}
