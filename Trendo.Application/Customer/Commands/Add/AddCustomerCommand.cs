using MediatR;
using Trendo.Application.Customer.Queries.GetAll;

namespace Trendo.Application.Customer.Commands.Add;

public class AddCustomerCommand
{
    public class Request : IRequest<GetAllCustomersQuery.Response>, IRequest<GetAllCustomersQuery.Response.CustomerRes>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
       
    }
}