using HomeService.Application.Commands.Categories;
using HomeService.Application.Commands.Requests;
using HomeService.Application.Commands.Services;
using HomeService.Application.DTOs.Categories;
using HomeService.Application.DTOs.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.API.Controllers.Services
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateServices([FromBody] AddServicesDto command)
        {
            var respons = await _mediator.Send(new CreateServicesCommand
            {
                Category = command
            });

            if(respons.IsSuccess == false)
            {
                return BadRequest();
            }

            return Ok(respons);
        }


        [HttpPut]

        public async Task<IActionResult> UpdateServices([FromBody] UpdateServicesDto command)
        {
            try
            {
                await _mediator.Send(new UpdateServicesCommand
                {
                    update = command
                });
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
                
           
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteServices([FromBody] DeleteServiceCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return NoContent();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices([FromQuery] bool isActive)
        {
            var results = await _mediator.Send(new GetAllServicesCommand { IsActive = isActive });
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReadServicesByIdDto>> GetRequest(int id)
        {
            var request = await _mediator.Send(new GetServiceByIdCommand { CategoryId = id });
            if (request == null)
            {
                return NotFound();
            }
            return Ok(request);
        }

    }
}
