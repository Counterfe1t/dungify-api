using Dungify.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dungify.Infrastructure.DAL;

internal sealed class DungifyDbContext : DbContext
{
    public required DbSet<User> Users { get; set; }

    public DungifyDbContext(DbContextOptions<DungifyDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}