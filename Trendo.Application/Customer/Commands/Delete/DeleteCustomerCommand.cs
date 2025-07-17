using MediatR;

namespace BuyZone.Application.Customer.Commands.Delete;

public class DeleteCustomerCommand
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