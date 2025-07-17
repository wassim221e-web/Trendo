using System.Linq.Expressions;
using MediatR;

namespace Trendo.Application.Employee.Query.GetById;

public class GetByIdEmployeeQuery
{
    public class Request : IRequest<Response>
    {
       public Guid Id { get; set; }
    }

    public class Response
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public static Expression<Func<Domain.Entities.Security.Employee, Response>> Selector() => c => new Response()
        {
        Id = c.Id,
        FirstName = c.FirstName,
        LastName = c.LastName,
        Email = c.Email,
        PhoneNumber = c.PhoneNumber
        };
    }
}