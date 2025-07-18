using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Entities;
using Trendo.Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Trendo.Application.Product.Queries.GetAll;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery.Request, GetAllProductsQuery.Response>
{
    private readonly IRepository<Product> _repository;

    public GetAllProductsHandler(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<GetAllProductsQuery.Response> Handle(GetAllProductsQuery.Request request, CancellationToken cancellationToken)
    {
        var products = await _repository.Query()
            .Include(p => p.Orders)
            .Include(p => p.Category)
            .Select(GetAllProductsQuery.Response.ProductRes.Selector())
            .ToListAsync(cancellationToken);

        return new GetAllProductsQuery.Response
        {
            Count = products.Count,
            Products = products
        };
    }
}