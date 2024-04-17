using AutoMapper;
using HomeService.Application.DTOs.Categories;
using HomeService.Application.DTOs.Customers;
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
    public class UpdateServicesCommand : IRequest<Unit>
    {
        public int CategoryId { get; set; }
    }

    public class UdateServiceCommandHandler : IRequest<UpdateServicesCommand>
    {
        private readonly IGenericRepository<tblServices> _serviceRepo;
        private readonly IMapper _mapper ;

       public UdateServiceCommandHandler(IGenericRepository<tblServices> repo, IMapper mapper)
        {
            _serviceRepo = repo;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(UpdateServicesCommand request, CancellationToken cancellationToken)
        {
            var entityToUpdate = await _serviceRepo.GetAsync(request.CategoryId);
            if (entityToUpdate == null)
            {
                throw new EntryPointNotFoundException($"Entity with ID {request.CategoryId} not found."); 
            }

            _mapper.Map(request, entityToUpdate);

            entityToUpdate.IsActive = false;
            await _serviceRepo.UpdateAsync(entityToUpdate);
            return Unit.Value;
        }
    }
}
