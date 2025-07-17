using MediatR;
using Microsoft.EntityFrameworkCore;
using Trendo.Domain.Repository;

namespace Trendo.Application.Employee.Query.GetById;

public class GetByIdEmployeeHandler : IRequestHandler<GetByIdEmployeeQuery.Request, GetByIdEmployeeQuery.Response>
{
    private readonly IRepository<Domain.Entities.Security.Employee> _repository;

    public GetByIdEmployeeHandler(IRepository<Domain.Entities.Security.Employee> repository)
    {
        _repository = repository;
    }

    public async Task<GetByIdEmployeeQuery.Response> Handle(GetByIdEmployeeQuery.Request request, CancellationToken cancellationToken)
    {
        var employee = await _repository.Query()
            .Where(e => e.Id == request.Id)
            .Select(GetByIdEmployeeQuery.Response.Selector())
            .FirstOrDefaultAsync(cancellationToken);

        if (employee == null)
            throw new Exception("الموظف غير موجود");

        return employee;
    }
}