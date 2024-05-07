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
        private readonly IGenericRepository<tblServices> _repo;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(IGenericRepository<tblServices> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(CreateServicesCommand request, CancellationToken cancellationToken)
        {

            var source = new tblServices
            {
                CategoryName = request.Category.CategoryName,
                CategoryType = request.Category.CategoryType,
                IsActive = request.Category.IsActive,
            };

            var result = await _repo.Create(source);
            return new BaseResponse
            {
                Id = result,
                Message = result.CategoryId > 0 ? "Created Succesfully" : "Creation failed",
                IsSuccess = result.CategoryId > 0 ? true : false
            };
        }
    }
}
