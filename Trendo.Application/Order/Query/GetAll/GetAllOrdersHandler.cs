using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Repository;

namespace Trendo.Application.Order.Query.GetAll;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery.Request, GetAllOrdersQuery.Response>
{
    private readonly IRepository<Domain.Entities.Order> _repository;

    public GetAllOrdersHandler(IRepository<Domain.Entities.Order> repository)
    {
        _repository = repository;
    }

    public async Task<GetAllOrdersQuery.Response> Handle(GetAllOrdersQuery.Request request,
        CancellationToken cancellationToken)
    {
        var orders = await _repository.Query()
            .Include(o => o.Product)
            .Include(o => o.Customer)
            .Select(GetAllOrdersQuery.Response.Selector())
            .ToListAsync(cancellationToken);

        return new GetAllOrdersQuery.Response
        {
            Count = orders.Count,
            Orders = orders
        };
    }
}