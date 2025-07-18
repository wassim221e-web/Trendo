using Trendo.Domain.BaseEntity;
using Trendo.Domain.Entities;
using System.Collections.Generic;

public class Product : IBaseEntity
{
    public Product() {}

    public Guid Id { get; set; }
    public int Number { get; set; }
    public string Name { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; }
    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

    public Product(string name, string imageUrl, string description, double price, Guid categoryId)
    {
        Name = name;
        ImageUrl = imageUrl;
        Description = description;
        Price = price;
        CategoryId = categoryId;
    }
}