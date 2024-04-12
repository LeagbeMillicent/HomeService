using AutoMapper;
using HomeService.Application.DTOs.Requests;
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
    public class UpdateRequestCommand : IRequest<BaseResponse>
    {
        public UpdateRequestsDto dto { get; set; }
    }

    public class UpdateRequestCommandHandler : IRequestHandler<UpdateRequestCommand, BaseResponse>
    {
        private readonly IGenericRepository<UpdateRequestsDto> _genericRepo;
        private readonly IMapper _mapper;

        public UpdateRequestCommandHandler(IGenericRepository<UpdateRequestsDto> genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userRequest = await _genericRepo.GetByIntId(request.dto.ReqId);

                if (userRequest == null)
                {
                    return new BaseResponse
                    {
                        Message = "Request not Found",
                        IsSuccess = false
                    };
                }
                    userRequest.ReqId = request.dto.ReqId;
                    userRequest.UserName = request.dto.UserName;
                    userRequest.Location = request.dto.Location;
                    userRequest.Contact = request.dto.Contact;
                    userRequest.ServiceDescription = request.dto.ServiceDescription;



                await _genericRepo.UpdateAsync(userRequest);

                return new BaseResponse
                {
                    Message = "Record Updated Succesfully",
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
