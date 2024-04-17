using HomeService.Application.DTOs.Categories;
using HomeService.Application.DTOs.Services;
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
            if (request.IsActive == null)
            {
                var sqlCommand = $"Select * From tblServices ";
                var result = await _repository.GetAllAsync(sqlCommand);
                return result.ToList();
            }
            else
            {
                var sqlCommand = $"Select * From tblServices Where @IsActive = {request.IsActive} ";
                var result = await _repository.GetAllAsync(sqlCommand);
                return result.ToList();
            }
            

            
        }
    }
}
