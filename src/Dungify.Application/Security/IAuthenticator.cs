using Dungify.Application.DTO;

namespace Dungify.Application.Security;

public interface IAuthenticator
{
    /// <summary>
    /// Create JSON Web Token for the specified user.
    /// </summary>
    /// <param name="userId">Unique user identifier.</param>
    /// <param name="role">Role assigned to the user.</param>
    /// <returns><see cref="JwtDto" /> object model.</returns>
    JwtDto CreateToken(Guid userId, string role);
}