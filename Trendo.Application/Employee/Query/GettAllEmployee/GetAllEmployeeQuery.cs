using System.Linq.Expressions;
using MediatR;

namespace Trendo.Application.Employee.Query.GetAllEmployee
{
    public class GetAllEmployeeQuery
    {
        public class Request : IRequest<Response>
        {
        }

        public class Response
        {
            public int Count { get; set; }
            public List<EmployeeRes> Employees { get; set; }

            public class EmployeeRes
            {
                public Guid Id { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Email { get; set; }
                public string PhoneNumber { get; set; }

                
                public static Expression<Func<Domain.Entities.Security.Employee, EmployeeRes>> Selector =>
                    e => new EmployeeRes
                    {
                        Id = e.Id,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Email = e.Email ?? "",
                        PhoneNumber = e.PhoneNumber,
                    };
            }
        }
    }
}