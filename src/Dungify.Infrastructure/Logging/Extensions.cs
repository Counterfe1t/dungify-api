using Dungify.Application.Abstractions;
using Dungify.Infrastructure.Logging.Decorators;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Dungify.Infrastructure.Logging;

public static class Extensions
{
    public static IServiceCollection AddCustomLogging(this IServiceCollection services)
    {
        services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

        return services;
    }

    public static WebApplicationBuilder UseSerilog(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.WriteTo.Console();
        });

        return builder;
    }
}