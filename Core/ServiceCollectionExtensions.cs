using Core.Interfaces;
using Core.Shared;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<IMediator, Mediator>();

        services.Scan(scan => scan
            .FromAssemblies(typeof(Mediator).Assembly)     
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());
        
        
        return services;
    }
    
}