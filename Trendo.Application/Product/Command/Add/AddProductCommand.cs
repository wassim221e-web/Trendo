using MediatR;
using Microsoft.AspNetCore.Http;

namespace Trendo.Application.Product.Command.Add;
public class AddOrUpdateProductCommand
{
    public class Request : IRequest<Response>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public IFormFile Image { get; set; }
    }

    public class Response
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
