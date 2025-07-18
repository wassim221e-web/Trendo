using MediatR;

namespace Trendo.Application.Product.Command.Delete;

public class DeleteProductCommand
{
    public class Request:IRequest
    {
        public Guid Id { get; set; }
    }
}