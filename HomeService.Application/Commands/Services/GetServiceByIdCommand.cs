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
    public class GetServiceByIdCommand : IRequest<List<ReadServicesByIdCommand>>
    {
        public int CategoryId { get; set; }
    }


    public class GetCategoriesByIdCommandHandler : IRequestHandler<GetServiceByIdCommand, List<ReadServicesByIdCommand>>
    {
        private readonly IGenericRepository<ReadServicesByIdCommand> _repository;
        public GetCategoriesByIdCommandHandler(IGenericRepository<ReadServicesByIdCommand> repository)
        {
            _repository = repository;
        }

        public async Task<List<ReadServicesByIdCommand>> Handle(GetServiceByIdCommand request, CancellationToken cancellationToken)
        {
            FormattableString query = $"";
            var result = await _repository.GetAll(query);

            return result;
        }
    }
}
