using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendo.Application.Employee.Command.Add;
using Trendo.Application.Employee.Command.Update;
using Trendo.Application.Employee.Command.Delete;
using Trendo.Application.Employee.Query.GetAllEmployee;
using Trendo.Application.Employee.Query.GetById;

namespace Trendo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetAll", Name = "GetAllEmployees")]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllEmployeeQuery.Request();
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("GetById", Name = "GetEmployeeById")]
    public async Task<IActionResult> GetById([FromQuery] GetByIdEmployeeQuery.Request request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPost("Create", Name = "CreateEmployee")]
    public async Task<IActionResult> Create([FromBody] AddEmployeeCommand.Request request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpPut("Update", Name = "UpdateEmployee")]
    public async Task<IActionResult> Update([FromBody] UpdateEmployeeCommand.Request request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    [HttpDelete("Delete", Name = "DeleteEmployee")]
    public async Task<IActionResult> Delete([FromQuery] DeleteEmployeeCommand.Request request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
}