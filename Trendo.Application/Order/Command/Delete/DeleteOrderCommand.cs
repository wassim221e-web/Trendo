
using MediatR;

namespace Trendo.Application.Order.Command.Delete;

public class DeleteOrderCommand
{
    public class Request : IRequest<Response>
    {
        public Guid Id { get; set; }
    }

    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
