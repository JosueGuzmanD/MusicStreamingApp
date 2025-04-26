using Infrastructure;

namespace Core.Interfaces;

public interface IMediator
{
    Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellation = default);
}