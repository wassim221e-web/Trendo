namespace Trendo.Domain.BaseEntity;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }= DateTime.UtcNow;
    public DateTime? DateUpdated { get; set; }
    public DateTime? DateDeleted { get; set; }
    
}