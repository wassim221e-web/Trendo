using System.Linq.Expressions;
using MediatR;

namespace Trendo.Application.Order.Query.GetById;

public class GetByIdOrderQuery
{
    public class Request : IRequest<Response>
    {
        public Guid Id { get; set; }
    }

    public class Response
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public Domain.Entities.Product Product { get; set; }
        public double Price { get; set; }
        public static Expression<Func<Domain.Entities.Order, Response>> Selector() => order => new Response
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            ProductId = order.ProductId,
            Product = order.Product,
            Price = order.Price
        };

    
    }
}