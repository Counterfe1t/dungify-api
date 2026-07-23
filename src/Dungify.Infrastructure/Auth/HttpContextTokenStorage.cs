using Dungify.Application.Abstractions;
using Dungify.Application.DTO;
using Microsoft.AspNetCore.Http;

namespace Dungify.Infrastructure.Auth;

internal sealed class HttpContextTokenStorage(IHttpContextAccessor httpContextAccessor) : ITokenStorage
{
    private const string TokenKey = "jwt";

    public void Set(JwtDto jwt)
        => httpContextAccessor.HttpContext?.Items.TryAdd(TokenKey, jwt);

    public JwtDto? Get()
    {
        if (httpContextAccessor.HttpContext is null)
            return null;

        if (!httpContextAccessor.HttpContext.Items.TryGetValue(TokenKey, out var jwt))
            return null;

        return (JwtDto?)jwt;
    }
}