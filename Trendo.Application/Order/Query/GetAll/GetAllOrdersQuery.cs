using System.Linq.Expressions;
using MediatR;

namespace Trendo.Application.Order.Query.GetAll;

public class GetAllOrdersQuery
{
    public class Request : IRequest<Response>
    {
        
    }

    public class Response
    {
        public int Count { get; set; }
        public List<OrdersRes> Orders { get; set; } = new();

        public class OrdersRes
        {
            public Guid Id { get; set; }
            public Guid CustomerId { get; set; }
            public string CustomerName { get; set; }
            public Guid ProductId { get; set; }
            public string ProductName { get; set; }
            public double Price { get; set; }
            public int Number { get; set; }
            public int Quantity { get; set; }
        }
        public static Expression<Func<Domain.Entities.Order, OrdersRes>> Selector() => order => new OrdersRes
        {
            Id = order.Id,
            Number = order.Number,
            CustomerName = order.Customer.FirstName+" "+order.Customer.LastName,
            CustomerId = order.CustomerId,
            ProductId = order.ProductId,
            ProductName = order.Product.Name,
            Price = order.Price,
            Quantity = order.Quantity,
        };
    }
}