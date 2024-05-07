using AutoMapper;
using HomeService.Application.DTOs.Workers;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using HomeService.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Workers
{
    public class ReadAllWorkersCommand : IRequest<IReadOnlyList<ReadWorkersDetailsDto>>
    {
        public ReadWorkersDetailsDto dto {  get; set; }
    }

    public class ReadAllWorkersCommandHandler : IRequestHandler<ReadAllWorkersCommand, IReadOnlyList<ReadWorkersDetailsDto>>
    {
        private readonly IGenericRepository<ReadWorkersDetailsDto> _repository;
        private readonly IMapper _mapper;

        public ReadAllWorkersCommandHandler(IGenericRepository<ReadWorkersDetailsDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ReadWorkersDetailsDto>> Handle(ReadAllWorkersCommand request, CancellationToken cancellationToken)
        {
            var workers = await _repository.GetAll($"Select * from Workers");
            var workersData = workers.Select(worker => new ReadWorkersDetailsDto
            {
                WorkerId = worker.WorkerId,
                WorkerName = worker.WorkerName,
                WorkerEmail = worker.WorkerEmail,
                WorkerContact = worker.WorkerContact,
                WorkerLocation = worker.WorkerLocation,
                WorkerCategory = worker.WorkerCategory

            }).ToList();

            return workersData;
        }
    }
}
