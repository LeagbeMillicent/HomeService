using AutoMapper;
using HomeService.Application.DTOs.Categories;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using HomeService.Domain;
using MediatR;

namespace HomeService.Application.Commands.Categories
{
    public class CreateServicesCommand : IRequest<BaseResponse>
    {
        public AddServicesDto Category { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateServicesCommand, BaseResponse>
    {
        private readonly IGenericRepository<AddServicesDto> _repo;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(IGenericRepository<AddServicesDto> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(CreateServicesCommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<AddServicesDto>(request.Category);

            var result = await _repo.Create(map);
            return result;
        }
    }
}
