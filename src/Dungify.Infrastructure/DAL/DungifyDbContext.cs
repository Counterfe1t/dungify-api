using Dungify.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dungify.Infrastructure.DAL;

/// <summary>
/// To add new migration:
/// dotnet ef migrations add [<migration-name>] --project ./src/Dungify.Infrastructure/Dungify.Infrastructure.csproj --startup-project ./src/Dungify.Api/Dungify.Api.csproj --output-dir ./DAL/Migrations
/// </summary>
internal sealed class DungifyDbContext(DbContextOptions<DungifyDbContext> options) : DbContext(options)
{
    public required DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}