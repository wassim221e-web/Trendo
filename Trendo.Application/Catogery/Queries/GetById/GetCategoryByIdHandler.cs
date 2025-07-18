using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Application.Catogery.Queries.GetAll;
using Trendo.Domain.Entities;
using Trendo.Domain.Repository;

namespace Trendo.Application.Catogery.Queries.GetById;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery.Request, GetAllCategoriesQuery.Response.CategoryDto>
{
    private readonly IRepository<Category> _repository;

    public GetCategoryByIdHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<GetAllCategoriesQuery.Response.CategoryDto> Handle(GetCategoryByIdQuery.Request request, CancellationToken cancellationToken)
    {
        var category = await _repository.Query()
            .Where(c => c.Id == request.Id)
            .Select(GetAllCategoriesQuery.Response.CategoryDto.Selector())
            .FirstOrDefaultAsync(cancellationToken);

        if (category == null)
            throw new Exception("Category not found");

        return category;
    }
}