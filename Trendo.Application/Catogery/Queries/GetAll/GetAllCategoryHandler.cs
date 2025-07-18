using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Entities;
using Trendo.Domain.Repository;

namespace Trendo.Application.Catogery.Queries.GetAll;

public class GetAllCategoriesHandler:IRequestHandler<GetAllCategoriesQuery.Request,GetAllCategoriesQuery.Response>
{
    private readonly IRepository<Category> _repository;

    public GetAllCategoriesHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<GetAllCategoriesQuery.Response> Handle(GetAllCategoriesQuery.Request request, CancellationToken cancellationToken)
    {
        var categories = await _repository.Query()
            .Select(GetAllCategoriesQuery.Response.CategoryDto.Selector())
            .ToListAsync(cancellationToken);
        return new GetAllCategoriesQuery.Response()
        {
            Count = categories.Count,
            Categories = categories
        };
    }
}