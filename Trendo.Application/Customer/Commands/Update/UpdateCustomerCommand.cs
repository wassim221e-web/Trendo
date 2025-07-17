using MediatR;
using Trendo.Application.Customer.Queries.GetAll;

namespace Trendo.Application.Customer.Commands.Update;

public class UpdateCustomerCommand
{
    public class Request : IRequest<Response>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }


    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }

    }
}