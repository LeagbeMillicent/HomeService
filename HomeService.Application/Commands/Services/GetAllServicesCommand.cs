using HomeService.Application.DTOs.Categories;
using HomeService.Application.DTOs.Services;
using HomeService.Application.DTOs.Workers;
using HomeService.Application.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Categories
{
    public class GetAllServicesCommand : IRequest<List<ReadAllServicesDto>>
    {
        public bool IsActive { get; set; }

    }


    public class GetAllCategoriesCommandHandler : IRequestHandler<GetAllServicesCommand, List<ReadAllServicesDto>>
    {
        private readonly IGenericRepository<ReadAllServicesDto> _repository;
        public GetAllCategoriesCommandHandler(IGenericRepository<ReadAllServicesDto> repository)
        {
            _repository = repository;
        }

        public async Task<List<ReadAllServicesDto>> Handle(GetAllServicesCommand request, CancellationToken cancellationToken)
        {
            
           
            FormattableString cond = $"Select * from Services where IsActive = 1";
            if (request.IsActive == null)
            {
                cond = $"Select * from Services";
            }
                var serices = await _repository.GetAll(cond);
            var serviceData = serices.Select(services => new ReadAllServicesDto
            {
                CategoryName = services.CategoryName,
                CategoryType = services.CategoryType,
                CategoryId = services.CategoryId,
                IsActive = services.IsActive
            }).ToList();

            return serviceData;

        }
    }
}
