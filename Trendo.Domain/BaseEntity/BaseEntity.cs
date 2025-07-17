using Trendo.Domain.BaseEntity;

public abstract class BaseEntity : IBaseEntity, IAuditable
{
    public Guid Id { get; set; } = Guid.NewGuid();                 
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;   
    public DateTime? DateUpdated { get; set; }
    public DateTime? DateDeleted { get; set; }
}