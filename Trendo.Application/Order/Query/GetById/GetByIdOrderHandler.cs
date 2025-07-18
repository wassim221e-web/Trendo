using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Repository;

namespace Trendo.Application.Order.Query.GetById;

public class GetByIdOrderHandler
{

    private readonly IRepository<Domain.Entities.Order> _repository;

    public GetByIdOrderHandler(IRepository<Domain.Entities.Order> repository)
    {
        _repository = repository;
    }

    public async Task<GetByIdOrderQuery.Response> Handle(GetByIdOrderQuery.Request request,
        CancellationToken cancellationToken)
    {
        var order = await _repository.Query()
            .Where(c => c.Id == request.Id)
            .Select(GetByIdOrderQuery.Response.Selector())
            .FirstAsync(cancellationToken);
        return order;

    }
}