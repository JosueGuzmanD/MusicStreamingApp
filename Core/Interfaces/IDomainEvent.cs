namespace Core.Interfaces;

public interface IDomainEvent
{
    DateTime OcurredOn { get; }
}