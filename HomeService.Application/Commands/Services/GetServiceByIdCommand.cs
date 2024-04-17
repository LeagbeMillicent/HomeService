using AutoMapper;
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
    public class GetServiceByIdCommand : IRequest<List<ReadServicesByIdDto>>
    {
        public int CategoryId { get; set; }
    }


    public class GetCategoriesByIdCommandHandler : IRequestHandler<GetServiceByIdCommand, List<ReadServicesByIdDto>>
    {
        private readonly IGenericRepository<ReadServicesByIdDto> _repository;
        private readonly IMapper _mapper; 
        public GetCategoriesByIdCommandHandler(IGenericRepository<ReadServicesByIdDto> repository, IMapper mapper)
        {
            _repository = repository;
            
           
        }

        public async Task<List<ReadServicesByIdDto>> Handle(GetServiceByIdCommand request, CancellationToken cancellationToken)
        {
            FormattableString query = $"";
            var result = await _repository.GetAll(query);

            return result;
        }
    }
}
