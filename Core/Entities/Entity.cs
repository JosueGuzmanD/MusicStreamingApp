namespace Core.Entities;

public abstract class Entity
{
    public Guid Id { get; protected set; }
    public DateTime CreationDate { get; private set; }
    public DateTime UpdateDate { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime? DeletedDate { get; private set; }
    public Guid? CreatedBy { get; private set; }
    public Guid? UpdatedBy { get; private set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
        UpdateDate = DateTime.UtcNow;
        IsDeleted = false;
    }

    public void MarkAsDeleted(Guid? userId=null)
    {
        IsDeleted = true;
        DeletedDate = DateTime.UtcNow;
        UpdatedBy = userId;
    }
    public void UpdateAuditInfo(Guid? userId = null)
    {
        UpdateDate = DateTime.UtcNow;
        UpdatedBy = userId;
    }

    protected static T EnsureNotNull<T>(T value, string paramName)
    {
        ArgumentNullException.ThrowIfNull(value,paramName);
        return value;
    }

}