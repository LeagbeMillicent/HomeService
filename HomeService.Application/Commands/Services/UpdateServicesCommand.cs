using AutoMapper;
using HomeService.Application.DTOs.Categories;
using HomeService.Application.DTOs.Customers;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using HomeService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Services
{
    public class UpdateServicesCommand : IRequest<BaseResponse>
    {
        public UpdateServicesDto update { get; set; }
    }

    public class UdateServiceCommandHandler : IRequestHandler<UpdateServicesCommand, BaseResponse>
    {
        private readonly IGenericRepository<tblServices> _serviceRepo;
        private readonly IMapper _mapper ;

       public UdateServiceCommandHandler(IGenericRepository<tblServices> repo, IMapper mapper)
        {
            _serviceRepo = repo;
            _mapper = mapper;
        }


        public async Task<BaseResponse> Handle(UpdateServicesCommand request, CancellationToken cancellationToken)
        {
            //var entityToUpdate = await _serviceRepo.GetAsync(request.CategoryId);
            //if (entityToUpdate == null)
            //{
            //    throw new EntryPointNotFoundException($"Entity with ID {request.CategoryId} not found."); 
            //}

            //_mapper.Map(request, entityToUpdate);

            //entityToUpdate.IsActive = false;
            //await _serviceRepo.UpdateAsync(entityToUpdate);
            //return Unit.Value;

            try
            {
                var services = await _serviceRepo.GetByIntId(request.update.CategoryId);

                if (services == null)
                {
                    return new BaseResponse
                    {
                        Message = "Worker not Found",
                        IsSuccess = false
                    };
                }

                services.CategoryType = request.update.CategoryType;
                services.CategoryName = request.update.CategoryName;
                services.IsActive = request.update.IsActive;

                await _serviceRepo.UpdateAsync(services);

                return new BaseResponse
                {
                    Message = "Record Updated Succesfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
