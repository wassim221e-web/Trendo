using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendo.Application.Order.Command.Add;
using Trendo.Application.Order.Command.Update;
using Trendo.Application.Order.Command.Delete;
using Trendo.Application.Order.Query.GetAll;

namespace Trendo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAll", Name = "GetAllOrders")]
    public async Task<IActionResult> GetAllOrders([FromQuery] GetAllOrdersQuery.Request request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("Create", Name = "CreateOrder")]
    public async Task<IActionResult> CreateOrder([FromQuery] AddOrderCommand.Request request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update", Name = "UpdateOrder")]
    public async Task<IActionResult> UpdateOrder([FromQuery] UpdateOrderCommand.Request request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Delete", Name = "DeleteOrder")]
    public async Task<IActionResult> DeleteOrder([FromQuery] DeleteOrderCommand.Request request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}