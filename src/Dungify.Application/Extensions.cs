using Dungify.Application.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Dungify.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.Scan(s => s.FromAssemblies(typeof(ICommandHandler<>).Assembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
