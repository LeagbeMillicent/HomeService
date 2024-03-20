using AutoMapper;
using HomeService.Application.DTOs.Categories;
using HomeService.Application.Repository;
using HomeService.Domain;
using MediatR;

namespace HomeService.Application.Commands.Categories
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        public AddCategoriesDto Category { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        private readonly IGenericRepository<Category> _repo;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(IGenericRepository<Category> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Category>(request.Category);

            var result = await _repo.Create(map);
            return result;
        }
    }
}
