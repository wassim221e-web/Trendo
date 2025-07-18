
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendo.Application.Customer.Commands.Add;
using Trendo.Application.Customer.Commands.Update;
using Trendo.Application.Customer.Queries.GetAll;

namespace Trendo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCustomersQuery.Request request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> AddCustomer([FromBody] AddCustomerCommand.Request request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand.Request request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteCustomer([FromQuery] DeleteCustomerCommand.Request request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}