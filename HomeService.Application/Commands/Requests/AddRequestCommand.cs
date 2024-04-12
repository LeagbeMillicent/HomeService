using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HomeService.Application.DTOs.Requests;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using HomeService.Domain;
using MediatR;

namespace HomeService.Application.Handlers.Requests
{

    public class AddRequestCommand : IRequest<BaseResponse>
    {
        public CreateRequestDto Cdto { get; set; }
    }
    public class AddRequestCommandHandler : IRequestHandler<AddRequestCommand, BaseResponse>
    {
        private readonly IGenericRepository<tblRequest> _repository;
        private readonly IMapper _mapper;

        public AddRequestCommandHandler(IGenericRepository<tblRequest> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(AddRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var newRequest = new tblRequest
                {
                    UserName = request.Cdto.UserName,
                    Location = request.Cdto.Location,
                    Contact = request.Cdto.Contact,
                    ServiceDescription = request.Cdto.ServiceDescription

                };

               
                //requestEntity.CreatedAt = DateTime.UtcNow;

               
                await _repository.Create(newRequest);

                return new BaseResponse { IsSuccess = true, Message = "Request added successfully" };
            }
            catch (Exception ex)
            {
                return new BaseResponse { IsSuccess = false, Message = $"Failed to add request: {ex.Message}" };
            }
        }
    }
}
