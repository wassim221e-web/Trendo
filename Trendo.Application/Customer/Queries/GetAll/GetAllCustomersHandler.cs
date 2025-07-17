using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Repository;

namespace Trendo.Application.Customer.Queries.GetAll;

public class GetAllCustomersHandler:IRequestHandler<GetAllCustomersQuery.Request, GetAllCustomersQuery.Response>
{
    private readonly IRepository<Domain.Entities.Security.Customer> _repository;

    public GetAllCustomersHandler(IRepository<Domain.Entities.Security.Customer> repository)
    {
        _repository = repository;
    }


    public async Task<GetAllCustomersQuery.Response> Handle(GetAllCustomersQuery.Request request, CancellationToken cancellationToken)
    {
        var customers = await _repository.Query()
            .Select(c=>new GetAllCustomersQuery.Response.CustomerRes()
            {
                Id = c.Id,
                DateCreated = c.DateCreated,
                Email = c.Email,
                FullName = c.FirstName + " " + c.LastName,
                Number = c.Number,
                Role = "",
            })
            .Skip((request.PageIndex - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);
        return new GetAllCustomersQuery.Response()
        {
            Count = customers.Count,
            Customers = customers
        };
    }
}