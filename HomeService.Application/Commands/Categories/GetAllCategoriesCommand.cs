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
    public class GetAllCategoriesCommand : IRequest<List<ReadCategoriesDto>>
    {

    }


    public class GetAllCategoriesCommandHandler : IRequestHandler<GetAllCategoriesCommand, List<ReadCategoriesDto>>
    {
        private readonly IGenericRepository<ReadCategoriesDto> _repository;
        public GetAllCategoriesCommandHandler(IGenericRepository<ReadCategoriesDto> repository)
        {
            _repository = repository;
        }

        public async Task<List<ReadCategoriesDto>> Handle(GetAllCategoriesCommand request, CancellationToken cancellationToken)
        {
            FormattableString query = $"";
            var result = await _repository.GetAll(query);

            return result;
        }
    }
}
