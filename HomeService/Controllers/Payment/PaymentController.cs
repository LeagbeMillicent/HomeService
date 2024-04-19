using HomeService.Application.Commands.Payment;
using HomeService.Application.Commands.WorkSchedule;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.API.Controllers.Payment
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] AddPaymentcommand command)
        {
            var respons = await _mediator.Send(command);

            if (respons.IsSuccess == false)
            {
                return BadRequest(respons.Message);
            }

            return Ok(respons.Message);
        }
        [HttpPut]

        public async Task<IActionResult> UpdatePayment([FromHeader] UpdatePaymentCommand command)
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
        public async Task<IActionResult> DeletePayment([FromHeader] DeletePaymentCommand command)
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
        public async Task<IActionResult> GetAllPayment()
        {
            var results = await _mediator.Send(new GetAllPaymentCommad());
            return Ok(results);
        }




    }

}

