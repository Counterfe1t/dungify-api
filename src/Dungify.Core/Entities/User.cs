using Dungify.Core.ValueObjects;

namespace Dungify.Core.Entities;

public sealed class User : EntityBase
{
    public UserName Name { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }

    public Role Role { get; private set; }

    /// <summary>
    /// Empty constructor is required for EF Core property mapping.
    /// </summary>
    private User() { }

    public User(
        EntityId id,
        Date createdAt,
        UserName name,
        Email email,
        Password password,
        Role role) : base(id, createdAt)
    {
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }

    public void ChangeName(UserName name)
        => Name = name;

    public void ChangeEmail(Email email)
        => Email = email;

    public void ChangePassword(Password password)
        => Password = password;

    public void ChangeRole(Role role)
        => Role = role;
}