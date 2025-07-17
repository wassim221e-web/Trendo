using MediatR;
using Trendo.Application.Employee.Query.GetAllEmployee;

namespace Trendo.Application.Employee.Command.Add;

public class AddEmployeeCommand
{
    public class Request:IRequest<GetAllEmployeeQuery.Response.EmployeeRes>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        
        public Guid RoleId { get; set; }
    }
}
