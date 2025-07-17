using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Repository;
using static Trendo.Application.Customer.Queries.GetById.GetByIdCustomerQuery;

namespace Trendo.Application.Customer.Queries.GetById;

public class GetByIdCustomerHandler : IRequestHandler<Request, Response>
{
    private readonly IRepository<Domain.Entities.Security.Customer> _repository;

    public GetByIdCustomerHandler(IRepository<Domain.Entities.Security.Customer> repository)
    {
        _repository = repository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        var customer = await _repository.Query()
            .Where(c => c.Id == request.Id)
            .Select(Response.Selector)
            .FirstOrDefaultAsync(cancellationToken);

        if (customer == null)
            throw new Exception("العميل غير موجود");

        return customer;
    }
}