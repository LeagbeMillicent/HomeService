using AutoMapper;
using HomeService.Application.DTOs.Workers;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using HomeService.Domain;
using MediatR;


namespace HomeService.Application.Commands.Workers
{
    public class AddWorkerCommand : IRequest<tblWorker>
    {
        public AddWorkersDto dto {  get; set; }
    }

    public class AddWorkerCommandHandler : IRequestHandler<AddWorkerCommand, tblWorker>
    {
        private readonly IGenericRepository<tblWorker> _repository;
        private readonly IMapper _mapper;

        public AddWorkerCommandHandler(IGenericRepository<tblWorker> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<tblWorker> Handle(AddWorkerCommand request, CancellationToken cancellationToken)
        {
            var newWorker = new tblWorker
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
