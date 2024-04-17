using AutoMapper;
using HomeService.Application.DTOs.Requests;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using HomeService.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Requests
{
    public class UpdateRequestCommand : IRequest<BaseResponse>
    {
        public UpdateRequestsDto dto { get; set; }
    }

    public class UpdateRequestCommandHandler : IRequestHandler<UpdateRequestCommand, BaseResponse>
    {
        private readonly IGenericRepository<tblRequest> _genericRepo;
        private readonly IMapper _mapper;

        public UpdateRequestCommandHandler(IGenericRepository<tblRequest> genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = await _genericRepo.GetByIntId(request.dto.ReqId);
            if (entity != null)
            {
                entity.CustomerId = request.dto.CustomerId;
                entity.Description = request.dto.Description;
                entity.Status = request.dto.Status;
                entity.DateRequested = request.dto.DateRequested;
                entity.WorkerId = request.dto.WorkerId;

                await _genericRepo.UpdateAsync(entity);
            }

            return new BaseResponse
            {
                Id = request.dto.ReqId,
                IsSuccess = false,
                Message = $"Update Failed!"
            };


    }   }
}
