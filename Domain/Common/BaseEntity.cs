namespace exam_system.Domain.Common;

public abstract class BaseEntity: SoftDeletableEntity
{
    public Guid Id { get; set; }
}
