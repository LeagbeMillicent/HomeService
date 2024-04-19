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
            //if (request.IsActive == null)
            //{
            //    var sqlCommand = $"Select * From tblServices ";
            //    var result = await _repository.GetAllAsync(sqlCommand);
            //    return result.ToList();
            //}
            //else
            //{
            //    var sqlCommand = $"Select * From tblServices Where @IsActive = {request.IsActive} ";
            //    var result = await _repository.GetAllAsync(sqlCommand);
            //    return result.ToList();
            //}
            FormattableString cond = $"Select * from tblServices";
            if (request.IsActive == null)
            {
                cond = $"Select * from tblServices where IsActive = {request.IsActive}";
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
