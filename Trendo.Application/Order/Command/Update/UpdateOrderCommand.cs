using MediatR;

namespace Trendo.Application.Order.Command.Update;

public class UpdateOrderCommand
{
    public class Request:IRequest<Response>
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public double Price { get; set; } 
    }

    public class Response
    {
        public  bool Success { get; set; }
        public string Message { get; set; }
    }
    
    
}