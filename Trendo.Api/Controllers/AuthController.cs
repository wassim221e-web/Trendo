using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendo.Application.Auth.Command;

namespace Trendo.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand.Request request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromQuery] LoginCommand.Request request)
    {
        try
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            
            return Unauthorized(new { message = ex.Message });
        }
    }
}
