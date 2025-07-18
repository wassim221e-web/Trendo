using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Repository;

namespace Trendo.Application.Product.Command.Delete;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand.Request>
{
    private readonly IRepository<Domain.Entities.Product> _repository;

    public DeleteProductHandler(IRepository<Domain.Entities.Product> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteProductCommand.Request request, CancellationToken cancellationToken)
    {
        var product = await _repository.TrackingQuery(true)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);

        if (product == null)
            throw new Exception("Product not found");

        _repository.Delete(product);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}