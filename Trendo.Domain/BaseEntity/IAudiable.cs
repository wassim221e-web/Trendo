public interface IAuditable
{
    DateTime DateCreated { get; set; }
    DateTime? DateUpdated { get; set; }
    DateTime? DateDeleted { get; set; }
}