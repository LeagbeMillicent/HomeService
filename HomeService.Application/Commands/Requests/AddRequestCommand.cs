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

    public class AddRequestCommand : IRequest<int>
    {
        public CreateRequestDto Cdto { get; set; }
    }
    public class AddRequestCommandHandler : IRequestHandler<AddRequestCommand, int>
    {
        private readonly IGenericRepository<tblRequest> _repository;
        private readonly IMapper _mapper;

        public AddRequestCommandHandler(IGenericRepository<tblRequest> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddRequestCommand request, CancellationToken cancellationToken)
        {
            var requestEntity = new tblRequest
            {
                CustomerId = request.Cdto.CustomerId,
                Description = request.Cdto.Description,
                DateRequested = request.Cdto.DateRequested,
                WorkerId = request.Cdto.WorkerId
            };

            await _repository.Create(requestEntity);

            return requestEntity.ReqId;
        }
    }
}
