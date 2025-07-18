using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Application.Catogery.Queries.GetAll;
using Trendo.Domain.Entities;
using Trendo.Domain.Repository;

namespace Trendo.Application.Catogery.Command.Update;

public class
    UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand.Request, GetAllCategoriesQuery.Response.CategoryDto>
{
    private readonly IRepository<Category> _repository;

    public UpdateCategoryHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<GetAllCategoriesQuery.Response.CategoryDto> Handle(UpdateCategoryCommand.Request request,
        CancellationToken cancellationToken)
    {

        var category = await _repository.Query()
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (category == null)
        {
            return null!;
        }


        category.Name = request.Name;
        category.Description = request.Description;


        await _repository.SaveChangesAsync();
        
        return await _repository.Query()
            .Where(c => c.Id == request.Id)
            .Select(GetAllCategoriesQuery.Response.CategoryDto.Selector())
            .FirstAsync(cancellationToken);
    }
}