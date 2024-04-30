using HomeService.Application.Commands.Categories;
using HomeService.Application.Commands.Customers;
using HomeService.Application.Commands.Services;
using HomeService.Application.DTOs.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HomeService.API.Controllers.Customer
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomersDto dto)
        {
            var command = new AddCustomersCommand { dto = dto };
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

        public async Task<IActionResult> UpdateCustomer([FromHeader] int Id,[FromBody] UpdateCustomersDto dto)
        {
            
            try
            {
                var command = new UpdateCustomerCommand { CustomerId = Id, Customer = dto };
                await _mediator.Send(command);
                return Ok(command);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer([FromBody] DeleteCustomerCommand command)
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
        public async Task<IActionResult> GetAllCustomers()
        {
            var results = await _mediator.Send(new GetAllCustomersCommand());
            return Ok(results);
        }

    }
}
