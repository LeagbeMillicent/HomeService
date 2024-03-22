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
    public class GetAllServicesCommand : IRequest<List<ReadServicesByIdCommand>>
    {

    }


    public class GetAllCategoriesCommandHandler : IRequestHandler<GetAllServicesCommand, List<ReadServicesByIdCommand>>
    {
        private readonly IGenericRepository<ReadServicesByIdCommand> _repository;
        public GetAllCategoriesCommandHandler(IGenericRepository<ReadServicesByIdCommand> repository)
        {
            _repository = repository;
        }

        public async Task<List<ReadServicesByIdCommand>> Handle(GetAllServicesCommand request, CancellationToken cancellationToken)
        {
            FormattableString query = $"";
            var result = await _repository.GetAll(query);

            return result;
        }
    }
}
