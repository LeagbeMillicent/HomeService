using HomeService.Application.Commands.Requests;
using HomeService.Application.Commands.Workers;
using HomeService.Application.DTOs.Requests;
using HomeService.Application.DTOs.Workers;
using HomeService.Application.Handlers.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HomeService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddRequest(CreateRequestDto dto)
        {
            var command = new AddRequestCommand { Cdto = dto };
            var response = await _mediator.Send(command);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }


        [HttpPut]
        public async Task<IActionResult> updateRequest([FromBody] UpdateRequestsDto dt)
        {
            var respond = await _mediator.Send(new UpdateRequestCommand { dto = dt });
            return Ok(respond);
        }


        [HttpGet]
        public async Task<IReadOnlyList<ReadRequestsDto>> getAllRequests()
        {
            var DataResponse = await _mediator.Send(new GetAllRequestCommand { });
            return DataResponse;
        }
    }
}
