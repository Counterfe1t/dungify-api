using Dungify.Core.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Dungify.Infrastructure.Services;

internal static class Extensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
        => services.AddScoped<IDiceRoller, DiceRoller>();
}
