using HomeService.Application.Commands.Categories;
using HomeService.Application.Commands.Services;
using HomeService.Application.Commands.Workers;
using HomeService.Application.Commands.WorkSchedule;
using HomeService.Application.DTOs.Categories;
using HomeService.Application.DTOs.Workers;
using HomeService.Application.DTOs.WorkSchedule;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.API.Controllers.WorkSchedule
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkScheduleController : ControllerBase
    {
            private readonly IMediator _mediator;

            public WorkScheduleController(IMediator mediator)
            {
                _mediator = mediator;
            }

        [HttpPost]
        public async Task<IActionResult> CreateSchedules([FromBody] AddScheduleDto dto)
        {
            var respons = await _mediator.Send(new AddWorkScheduleCommand { scheduleDto = dto });

            return Ok(respons);

        }


            [HttpPut]

            public async Task<IActionResult> UpdateWorkSchedules([FromHeader] UpdateWorkScheduleCommand command)
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

            [HttpPut]
            public async Task<IActionResult> DeleteWorkSchedules([FromBody] DeleteScheduleCommand command)
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
            public async Task<IActionResult> GetAllWorkSchedules()
            {
                var results = await _mediator.Send(new GetAllScheduleCommand ());
                return Ok(results);
            }

            //[HttpGet("{id}")]
            //public async Task<ActionResult<>> GetRequest(int id)
            //{
            //    var request = await _mediator.Send(new  {  = id });
            //    if (request == null)
            //    {
            //        return NotFound();
            //    }
            //    return Ok(request);
            //}

        
    }
}
