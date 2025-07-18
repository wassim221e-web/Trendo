using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Entities;
using Trendo.Domain.Repository;

namespace Trendo.Application.Catogery.Command.Delete;

public class DeleteCategoryHandler:IRequestHandler<DeleteCategoryCommand.Request>
{
    private readonly IRepository<Category> _repository;

    public DeleteCategoryHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteCategoryCommand.Request request, CancellationToken cancellationToken)
    {
        var category = await _repository.Query()
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        if (category == null)
            throw new Exception("Category not found");
        _repository.Delete(category);
        await _repository.SaveChangesAsync();
    }
}