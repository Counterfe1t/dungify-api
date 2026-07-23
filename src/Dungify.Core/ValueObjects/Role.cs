using Dungify.Core.Exceptions;

namespace Dungify.Core.ValueObjects;

public record Role
{
    private static IEnumerable<string> Roles => ["admin", "dungeon-master", "player"];

    public string Value { get; }

    public Role(string value)
    {
        if (!Roles.Contains(value))
        {
            throw new InvalidRoleException(value);
        }

        Value = value;
    }

    public static implicit operator string(Role name)
        => name.Value;

    public static implicit operator Role(string value)
        => new(value);

    public static bool operator ==(Role name, string value)
        => name.Value == value;

    public static bool operator !=(Role name, string value)
        => name.Value != value;

    public static bool operator ==(string value, Role name)
        => name.Value == value;

    public static bool operator !=(string value, Role name)
        => name.Value != value;
}
