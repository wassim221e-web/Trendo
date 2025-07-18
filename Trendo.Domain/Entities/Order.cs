
using Trendo.Domain.BaseEntity;
using Trendo.Domain.Entities.Security;

namespace Trendo.Domain.Entities;

public class Order:IBaseEntity
{
    public Guid Id { get; set; }
    public int Number { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public DateTime DateCreated { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Order( Guid customerId, Guid productId, double price,int quantity)
    {
        CustomerId = customerId;
        ProductId = productId;
        Price = price;
        DateCreated = DateTime.UtcNow;
        Quantity = quantity;
    }
}