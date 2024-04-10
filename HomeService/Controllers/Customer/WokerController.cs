using HomeService.Application.Commands.Workers;
using HomeService.Application.DTOs.Workers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.API.Controllers.Customer
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WokerController : ControllerBase
    {
        private IMediator _mediator;
        public WokerController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> createWorker([FromBody] AddWorkersDto dto)
        {
            var resp = await _mediator.Send(new AddWorkerCommand { dto = dto });
            return Ok(resp);
        }

    }
}
