using MediatR;
using Microsoft.EntityFrameworkCore; // مهم للـ ToListAsync
using Trendo.Application.Employee.Query.GetAllEmployee;
using Trendo.Domain.Repository;

namespace Trendo.Application.Employee.Query.GetAllEmployee
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery.Request, GetAllEmployeeQuery.Response>
    {
        private readonly IRepository<Domain.Entities.Security.Employee> _repository;

        public GetAllEmployeeHandler(IRepository<Domain.Entities.Security.Employee> repository)
        {
            _repository = repository;
        }

        public async Task<GetAllEmployeeQuery.Response> Handle(GetAllEmployeeQuery.Request request,
            CancellationToken cancellationToken)
        {
            var employees = await _repository.Query()
                .Select(GetAllEmployeeQuery.Response.EmployeeRes.Selector)
                .ToListAsync(cancellationToken);

            return new GetAllEmployeeQuery.Response()
            {
                Count = employees.Count,
                Employees = employees
            };
        }
    }
}