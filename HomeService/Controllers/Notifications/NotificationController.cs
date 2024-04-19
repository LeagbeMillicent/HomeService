using HomeService.Application.Commands.Notification;
using HomeService.Application.Commands.Payment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.API.Controllers.Notifications
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        

            private readonly IMediator _mediator;

            public NotificationController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpPost]
            public async Task<IActionResult> AddNotification([FromBody] AddNotificationCommand command)
            {
                var respons = await _mediator.Send(command);

                if (respons.IsSuccess == false)
                {
                    return BadRequest(respons.Message);
                }

                return Ok(respons.Message);
            }
            [HttpPut]

            public async Task<IActionResult> UpdateNotification([FromHeader] updateNotificationCommand command)
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
            public async Task<IActionResult> DeleteNotification([FromHeader] DeleteNotificationCommand command)
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
            public async Task<IActionResult> GetAllNotification()
            {
                var results = await _mediator.Send(new GetAllNotificationCommand());
                return Ok(results);
            }




        
    }
}
