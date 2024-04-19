using AutoMapper;
using HomeService.Application.DTOs.Workers;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using HomeService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Workers
{
    public class UpdateWorkerCommand : IRequest<BaseResponse>
    {
        public UpdateWorkersDto Dto { get; set; }
    }

    public class UpdateWorkerCommandHandler : IRequestHandler<UpdateWorkerCommand, BaseResponse>
    {
        private readonly IGenericRepository<tblWorker> _repository;
        private readonly IMapper _mapper;

        public UpdateWorkerCommandHandler(IGenericRepository<tblWorker> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var worker = await _repository.GetByIntId(request.Dto.WorkerId);

                if(worker == null)
                {
                    return new BaseResponse
                    {
                        Message = "Worker not Found",
                        IsSuccess = false
                    };
                }

                worker.WorkerContact = request.Dto.WorkerContact;
                worker.WorkerLocation = request.Dto.WorkerLocation;
                worker.WorkerName = request.Dto.WorkerName;
                worker.WorkerEmail = request.Dto.WorkerEmail;

                await _repository.UpdateAsync(worker);

                return new BaseResponse
                {
                    Message = "Record Updated Succesfully",
                    IsSuccess = true
                };
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }
    }
}
