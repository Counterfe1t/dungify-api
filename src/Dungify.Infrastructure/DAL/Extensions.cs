using Dungify.Application.Abstractions;
using Dungify.Core.Repositories;
using Dungify.Infrastructure.DAL.Decorators;
using Dungify.Infrastructure.DAL.Repositories;
using Dungify.Infrastructure.DAL.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dungify.Infrastructure.DAL;

internal static class Extensions
{
    private const string DatabaseSectionName = "database";

    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<DatabaseOptions>(DatabaseSectionName);
        services.AddDbContext<DungifyDbContext>(x => x.UseSqlServer(options.ConnectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));

        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddHostedService<DatabaseInitializer>();

        return services;
    }
}