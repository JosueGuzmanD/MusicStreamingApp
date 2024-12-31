namespace Core.Interfaces;

public class IEntity
{
    public Guid Id { get;  }
    public DateTime CreationDate { get;  }
    public DateTime UpdateDate { get;  }

}