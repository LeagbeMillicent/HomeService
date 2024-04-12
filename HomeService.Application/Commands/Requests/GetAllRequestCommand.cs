using AutoMapper;
using HomeService.Application.DTOs.Requests;
using HomeService.Application.DTOs.Workers;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Requests
{
    public class GetAllRequestCommand : IRequest<IReadOnlyList<ReadRequestsDto>>
    {
        public ReadRequestsDto dto { get; set; }

    }

    public class GetAllRequestCommandHandler : IRequestHandler<GetAllRequestCommand, IReadOnlyList<ReadRequestsDto>>
    {
        private readonly IGenericRepository<ReadRequestsDto> _repository;
        private readonly IMapper _mapper;

        public GetAllRequestCommandHandler(IGenericRepository<ReadRequestsDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


       public async Task<IReadOnlyList<ReadRequestsDto>> Handle(GetAllRequestCommand request, CancellationToken cancellationToken)
       {
            var requests = await _repository.GetAll($"Select * from Requests");
            var requestsData = requests.Select(request => new ReadRequestsDto
            {
                //RequestId = request.RequestId,
                UserName = request.UserName,
                Location = request.Location,
                Contact = request.Contact,
                ServiceDescription = request.ServiceDescription,
                //CreatedAt = request.CreatedAt,
                //UpdatedAt = request.UpdatedAt,
                //IsCompleted = request.IsCompleted
            }).ToList();

            return requestsData;
       }
    };
        
    
}
