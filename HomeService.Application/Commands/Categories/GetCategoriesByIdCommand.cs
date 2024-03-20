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
    public class GetCategoriesByIdCommand : IRequest<List<ReadCategoriesDto>>
    {
        public int CategoryId { get; set; }
    }


    public class GetCategoriesByIdCommandHandler : IRequestHandler<GetCategoriesByIdCommand, List<ReadCategoriesDto>>
    {
        private readonly IGenericRepository<ReadCategoriesDto> _repository;
        public GetCategoriesByIdCommandHandler(IGenericRepository<ReadCategoriesDto> repository)
        {
            _repository = repository;
        }

        public async Task<List<ReadCategoriesDto>> Handle(GetCategoriesByIdCommand request, CancellationToken cancellationToken)
        {
            FormattableString query = $"";
            var result = await _repository.GetAll(query);

            return result;
        }
    }
}
