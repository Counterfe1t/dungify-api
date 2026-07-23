using Dungify.Core.Entities;
using Dungify.Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dungify.Infrastructure.DAL.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasConversion(x => x.Value, x => new EntityId(x))
            .IsRequired();
        builder.Property(u => u.CreatedAt)
            .HasConversion(x => x.Value, x => new Date(x))
            .IsRequired();
        builder.Property(u => u.ModifiedAt)
            .HasConversion(x => x!.Value, x => new Date(x));
        builder.HasIndex(u => u.Name).IsUnique();
        builder.Property(u => u.Name)
            .HasMaxLength(30)
            .HasConversion(x => x.Value, x => new UserName(x))
            .IsRequired();
        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.Email)
            .HasMaxLength(50)
            .HasConversion(x => x.Value, x => new Email(x))
            .IsRequired();
        builder.Property(u => u.Password)
            .HasConversion(x => x.Value, x => new Password(x))
            .IsRequired();
        builder.Property(u => u.Role)
            .HasMaxLength(30)
            .HasConversion(x => x.Value, x => new Role(x))
            .IsRequired();
    }
}