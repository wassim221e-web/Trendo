using Trendo.Domain.BaseEntity;

namespace Trendo.Domain.Entities;

public class Category:IBaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    private readonly List<Product> _products = new List<Product>();
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

    public Category(string name, string description)
    { 
        Name = name;
        Description = description;
    }
}