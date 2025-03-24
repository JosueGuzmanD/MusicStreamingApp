using Core.Interfaces;

namespace Core.DomainEvents;

public sealed record SongPlayed(Guid UserId, Guid SongId, DateTime PlayedAt) : IDomainEvent
{
    public DateTime OcurredOn => PlayedAt;
}