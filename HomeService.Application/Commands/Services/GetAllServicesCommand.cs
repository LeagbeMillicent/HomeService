using HomeService.Application.DTOs.Categories;
using HomeService.Application.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Categories
{
    public class GetAllServicesCommand : IRequest<List<ReadServicesByIdDto>>
    {

    }


    public class GetAllCategoriesCommandHandler : IRequestHandler<GetAllServicesCommand, List<ReadServicesByIdDto>>
    {
        private readonly IGenericRepository<ReadServicesByIdDto> _repository;
        public GetAllCategoriesCommandHandler(IGenericRepository<ReadServicesByIdDto> repository)
        {
            _repository = repository;
        }

        public async Task<List<ReadServicesByIdDto>> Handle(GetAllServicesCommand request, CancellationToken cancellationToken)
        {
            FormattableString query = $"";
            var result = await _repository.GetAll(query);

            return result;
        }
    }
}
