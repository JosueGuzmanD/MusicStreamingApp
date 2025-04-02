using Core.Interfaces;

namespace Application.Interface;

public interface IDomainEventHandler<T> where T : IDomainEvent
{
    Task Handle(T domainEvent);
}