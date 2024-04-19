using HomeService.Application.Commands.Categories;
using HomeService.Application.Commands.Services;
using HomeService.Application.Commands.WorkUnits;
using HomeService.Application.DTOs.Categories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.API.Controllers.WorkUnit
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkUnitController : ControllerBase
    {
        public class ServicesController : ControllerBase
        {
            private readonly IMediator _mediator;

            public ServicesController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpPost]
            public async Task<IActionResult> CreateWorkUnit([FromBody] AddWorkUnitCommand command)
            {
                var respons = await _mediator.Send(command);

                if (respons.IsSuccess == false)
                {
                    return BadRequest(respons.Message);
                }

                return Ok(respons);
            }


            [HttpPut]

            public async Task<IActionResult> UpdateWorkUnit([FromBody] UpdateWorkUnitsCommand command)
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
            public async Task<IActionResult> DeleteWorkUnit([FromHeader] DeleteWorkUnitsCommand command)
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
            public async Task<IActionResult> GetAllWorkUnit()
            {
                var results = await _mediator.Send(new GetAllWorkUnitsCommand ());
                return Ok(results);
            }

            [HttpGet("{id}")]
            //public async Task<ActionResult<>> GetRequest(int id)
            //{
            //    var request = await _mediator.Send(new { CategoryId = id });
            //    if (request == null)
            //    {
            //        return NotFound();
            //    }
            //    return Ok(request);
            //}

        }
    }
}
