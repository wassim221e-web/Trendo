using MediatR;

namespace Trendo.Application.Product.Command.Update;

public class UpdateProductCommand
{
    public class Request : IRequest<Response>
    {
        public Guid Id { get; set; }              
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
    }

    public class Response
    {
        public bool Success { get; set; }         
        public string Message { get; set; }       
    }
}