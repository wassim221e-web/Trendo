using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendo.Application.Product.Command.Add;
using Trendo.Application.Product.Command.Delete;
using Trendo.Application.Product.Queries.GetAll;
using Trendo.Application.Product.Queries.GetById;

namespace Trendo.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("GetAll")]
    
    public async Task<IActionResult> GetAll([FromQuery]GetAllProductsQuery.Request request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpPost("Add")]
    
    public async Task<IActionResult> Add([FromForm] AddOrUpdateProductCommand.Request request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpDelete("Delete")]
    
    public async Task<IActionResult> Delete([FromQuery] DeleteProductCommand.Request request)
    {
        await _mediator.Send(request);
        return Ok();
    }
    [HttpGet("GetById")]
    
    public async Task<IActionResult> GetById([FromQuery] GetByIdProductQuery.Request request)
    {
        return Ok(await _mediator.Send(request));
    }
}