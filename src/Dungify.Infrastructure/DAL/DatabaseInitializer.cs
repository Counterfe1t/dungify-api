using Dungify.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dungify.Infrastructure.DAL;

internal sealed class DatabaseInitializer(IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        // Apply all necessary migrations on application start-up.
        using var scope = serviceProvider.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<DungifyDbContext>();
        dbContext.Database.Migrate();

        var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher<User>>();
        var password = passwordHasher.HashPassword(default!, "password");
        var users = await dbContext.Users.ToListAsync(cancellationToken);
        if (users.Count == 0)
        {
            await dbContext.Users.AddAsync(new(
                Guid.Parse("00000000-0000-0000-0000-000000002137"),
                DateTimeOffset.UtcNow,
                "admin",
                "admin@dungify.dev",
                password,
                "admin"), cancellationToken);
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
        => Task.CompletedTask;
}