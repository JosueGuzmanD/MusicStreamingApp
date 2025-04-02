using Core.Interfaces;

namespace Application.Interface;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents);

}