using AutoMapper;
using HomeService.Application.DTOs.Categories;
using HomeService.Application.Repository;
using HomeService.Domain;
using MediatR;

namespace HomeService.Application.Commands.Categories
{
    public class CreateServicesCommand : IRequest<Services>
    {
        public AddCategoriesDto Category { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateServicesCommand, Services>
    {
        private readonly IGenericRepository<Services> _repo;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(IGenericRepository<Services> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Services> Handle(CreateServicesCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Services>(request.Category);

            var result = await _repo.Create(map);
            return result;
        }
    }
}
