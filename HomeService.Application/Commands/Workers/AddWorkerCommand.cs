using AutoMapper;
using HomeService.Application.DTOs.Workers;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using HomeService.Domain;
using MediatR;


namespace HomeService.Application.Commands.Workers
{
    public class AddWorkerCommand : IRequest<Worker>
    {
        public AddWorkersDto dto {  get; set; }
    }

    public class AddWorkerCommandHandler : IRequestHandler<AddWorkerCommand, Worker>
    {
        private readonly IGenericRepository<Worker> _repository;
        private readonly IMapper _mapper;

        public AddWorkerCommandHandler(IGenericRepository<Worker> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Worker> Handle(AddWorkerCommand request, CancellationToken cancellationToken)
        {
            var newWorker = new Worker
            {
                WorkerAddress = request.dto.WorkerAddress,
                WorkerContact = request.dto.WorkerContact,
                WorkerLocation = request.dto.WorkerLocation,
                WorkerName = request.dto.WorkerName,
            };

            return await _repository.Create(newWorker);
        }
    }
}
