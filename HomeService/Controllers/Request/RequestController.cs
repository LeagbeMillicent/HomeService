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
    public class RequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UpdateRequestsDto>>> GetRequests()
        {
            var requests = await _mediator.Send(new GetAllRequestCommand());
            return Ok(requests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadRequestsDto>> GetRequest(int id)
        {
            var request = await _mediator.Send(new GetRequestByIdCommand { RequestId = id });
            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateRequest(AddRequestCommand request)
        {
            var id = await _mediator.Send(request);
            return CreatedAtAction(nameof(GetRequest), new { id = id }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRequest(int id, UpdateRequestCommand request)
        {
            if (id != request.dto.ReqId)
            {
                return BadRequest();
            }

            await _mediator.Send(request);
            return NoContent();
        }

       
    }
}

