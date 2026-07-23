using Dungify.Application.Security;
using Dungify.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Dungify.Infrastructure.Security;

public sealed class PasswordManager(IPasswordHasher<User> passwordHasher) : IPasswordManager
{
    public string HashPassword(string password)
        => passwordHasher.HashPassword(default!, password);

    public bool ValidatePassword(string password, string hashedPassword)
        => passwordHasher.VerifyHashedPassword(default!, hashedPassword, password) is PasswordVerificationResult.Success;
}