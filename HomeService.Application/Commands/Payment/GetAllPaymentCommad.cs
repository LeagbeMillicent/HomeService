using AutoMapper;
using HomeService.Application.DTOs.PayMent;
using HomeService.Application.DTOs.WorkSchedule;
using HomeService.Application.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Payment
{
    public class GetAllPaymentCommad : IRequest<List<GetAllPaymentDto>>
    {

    }
    public class GetAllPaymentCommadHandler : IRequestHandler<GetAllPaymentCommad, List<GetAllPaymentDto>>
    {
        private readonly IGenericRepository<GetAllPaymentDto> _repository;
        private readonly IMapper _mapper;

        public GetAllPaymentCommadHandler(IGenericRepository<GetAllPaymentDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllPaymentDto>> Handle(GetAllPaymentCommad request, CancellationToken cancellationToken)
        {
            var sqlQuery = $"Select * From tblPayment";
            var response = await _repository.GetAllAsync(sqlQuery);

            if (response != null)
            {
                return _mapper.Map<List<GetAllPaymentDto>>(response);
            }
            return null;
        }
    }
}
