using AutoMapper;
using HomeService.Application.DTOs.Categories;
using HomeService.Application.DTOs.PayMent;
using HomeService.Application.Repository;
using HomeService.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Application.Commands.Payment
{
    public class AddPaymentcommand : IRequest<BaseResponse>
    {
        public AddPaymentDto paymentDto {  get; set; }
    }

    public class AddPaymentCommandHandler : IRequestHandler<AddPaymentcommand, BaseResponse>
    {
        private readonly IGenericRepository<AddPaymentDto> _repository;
        private readonly IMapper _mapper;

        public AddPaymentCommandHandler(IGenericRepository<AddPaymentDto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(AddPaymentcommand request, CancellationToken cancellationToken)
        {
            var map = _mapper.Map<AddPaymentDto>(request.paymentDto);

            var result = await _repository.Create(map);
            return new BaseResponse
            {
                Id = result,
                Message = " Created Succesfully"
            };
        }
    }
}
