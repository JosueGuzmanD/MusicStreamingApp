using Core.Interfaces;
using Infrastructure;

namespace Core.Shared;

public class Mediator : IMediator
{
    private readonly IServiceProvider _provider;
    public Mediator(IServiceProvider provider) => _provider = provider;

    public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellation = default)
    {
        var handlerType = typeof(IRequestHandler<,>)
            .MakeGenericType(request.GetType(), typeof(TResponse));

        dynamic handler = _provider.GetService(handlerType)
                          ?? throw new InvalidOperationException($"No handler for {handlerType.Name}");

        return handler.Handle((dynamic)request, cancellation);
    }
}
