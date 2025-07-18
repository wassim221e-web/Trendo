using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trendo.Application.Catogery.Command.Add;
using Trendo.Application.Catogery.Command.Delete;
using Trendo.Application.Catogery.Command.Update;
using Trendo.Application.Catogery.Queries.GetAll;
using Trendo.Domain.Entities;
using Trendo.Domain.Repository;

namespace Trendo.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CategoryController : Controller
{
    private readonly IMediator _mediator;
    private readonly IRepository<Category> _repository;
    public CategoryController(IMediator mediator, IRepository<Category> repository)
    {
        _mediator = mediator;
        _repository = repository;
    }
    
    [HttpGet("GetAll")]
    
    public async Task<IActionResult> GetAllCategory([FromQuery]GetAllCategoriesQuery.Request request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpPost("Add")]
    
    public async Task<IActionResult> AddCategory([FromQuery]AddCategoryCommand.Request request)
    {
        return Ok(await _mediator.Send(request));
    }
    [HttpDelete("Delete")]
    
    public async Task<IActionResult>DeleteCategory([FromQuery]DeleteCategoryCommand.Request request)
    {
        await _mediator.Send(request);
        return Ok();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateCategory([FromQuery] UpdateCategoryCommand.Request request)
    {
        return Ok(await _mediator.Send(request));
    }
}